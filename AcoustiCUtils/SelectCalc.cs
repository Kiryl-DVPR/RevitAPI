using AcoustiCUtils.Library;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcoustiCUtils
{
    [Transaction(TransactionMode.Manual)]
    public class SelectCalc : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;//Обращаемся к приложению Revit
            UIDocument uidoc = uiapp.ActiveUIDocument; //Оращаемся к интерфейсу Revit
            Document doc = uidoc.Document;//Обращаемся к документу

            IList<Reference> selectedElementRefList = uidoc.Selection.PickObjects(ObjectType.Element, "Выберете элементы");

            const string BRAND_CODE = "AG";

            if (CodeFilter.FindElements(selectedElementRefList, BRAND_CODE, doc))
            {
                ConstrInfoPerType.GetInfo(CodeFilter.FilteredElementList, doc);

                var list = new List<Product>();

                var window = new ProductTable(list, ConstrInfoPerType.constructionInfo);

                var dispatcher = window.Dispatcher;

                var task = Task.Run(async () =>
                {

                    var postresponse = await REST.Requests.PostRequest("http://158.160.77.34:3005/api/v1/calcQuantity", ConstrInfoPerType.elementInfo);

                    string jsonStringProduct = await postresponse.Content.ReadAsStringAsync(); // записываем содержимое файла в строковую переменную

                    var response = JsonConvert.DeserializeObject<Response>(jsonStringProduct); // информацию из строковой переносим в список обьектов

                    var productList = response.data as List<Product>;

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
