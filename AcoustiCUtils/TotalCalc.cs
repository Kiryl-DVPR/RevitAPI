﻿using AcoustiCUtils;
using AcoustiCUtils.Library;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace AcoustiCUtils
{
    [Transaction(TransactionMode.Manual)]
    public class TotalCalc : IExternalCommand
    {
        public  Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;//Обращаемся к приложению Revit
            UIDocument uidoc = uiapp.ActiveUIDocument; //Оращаемся к интерфейсу Revit
            Document doc = uidoc.Document;//Обращаемся к проекту Revit

            var allElementsInDocList = new FilteredElementCollector(doc) //Сортирует все элементы в документе
               //.WhereElementIsCurveDriven()
               .WhereElementIsNotElementType()
               .Cast<Element>()
               .ToList();

            const string BRAND_CODE = "AG";

            if (CodeFilter.FindElements(allElementsInDocList, BRAND_CODE))
            {

                ConstrInfoPerType.GetInfo(CodeFilter.FilteredElementList, doc);

                var list = new List<Product>();

                var window = new ProductTable(list, ConstrInfoPerType.constructionInfo);

                var dispatcher = window.Dispatcher;

                var task = Task.Run(async () =>
                {

                    var productList = await REST.Requests.GetCaclcProduct(ConstrInfoPerType.elementInfo);


                    dispatcher.BeginInvoke(new Action(() =>
                    {
                        window.UpdateListOfItems(productList); 
                    }));

                });
                task.Wait();

                window.ShowDialog();

            }

            else TaskDialog.Show("AG продукты", "Продукты AG не найдены");

            return Result.Succeeded;      

        }

    }
}
