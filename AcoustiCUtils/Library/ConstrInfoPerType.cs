using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AcoustiCUtils
{
    internal static class ConstrInfoPerType
    {
        public static List<Constr> elementInfo = new List<Constr>(); // Создание списка для помещения информации об элементах (Стены, потолки, полы...)

        public static List<Construction> constructionInfo = new List<Construction>();

        public static void GetInfo(List<Element> _CodeListFilter,Document doc)
        {
            int index = 1; //Счётчик для id элемента
            int indexConstr = 1;

            elementInfo.Clear();
            constructionInfo.Clear();

            foreach (Element element in _CodeListFilter)
            {
                if (element is Wall wallAg)
                {

                    var wallCode = wallAg.WallType.LookupParameter("Шифр конструкции").AsString().ToString();

                    var lenX_ = wallAg.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                    var lenZ_ = wallAg.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM);
                    var area_ = wallAg.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);

                    var lenX = ((int)UnitUtils.ConvertFromInternalUnits(lenX_.AsDouble(), UnitTypeId.Millimeters));
                    var lenZ = ((int)UnitUtils.ConvertFromInternalUnits(lenZ_.AsDouble(), UnitTypeId.Millimeters));
                    var area = ((int)UnitUtils.ConvertFromInternalUnits(area_.AsDouble(), UnitTypeId.SquareMeters));

                    elementInfo.Add(new Constr() { Code = wallCode, LenX = lenX, LenZ = lenZ });

                    var ConstrRef = constructionInfo.Find((el) => el.Code == wallCode);

                    if (ConstrRef != null)
                    {
                        ConstrRef.Quantity += area;
                    }
                    else
                    {
                        constructionInfo.Add(new Construction() 
                        { 
                            Id = indexConstr++, Name = element.Name, Code = wallCode, Units = "м.кв.",Quantity = area, Weight = "20 кг/ед.",
                        });
                    }

                  

                    index++;

                }
                else if (element is Ceiling ceilingElement)
                {
                    var idCeiling = ceilingElement.GetTypeId();
                    var ceilingType = doc.GetElement(idCeiling);

                    var ceilingCode = ceilingType.LookupParameter("Шифр конструкции").AsString().ToString();

                    var area_ = ceilingElement.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);//Достаём свойства объекта (Площадь)
                    var area = ((int)UnitUtils.ConvertFromInternalUnits(area_.AsDouble(), UnitTypeId.SquareMillimeters));//Конвертация в "мм2"

                    var perimeter_ = ceilingElement.get_Parameter(BuiltInParameter.HOST_PERIMETER_COMPUTED);//Достаём свойства объекта (Периметр)
                    var perimeter = ((int)UnitUtils.ConvertFromInternalUnits(perimeter_.AsDouble(), UnitTypeId.Millimeters));//Конвертация в "мм"

                    elementInfo.Add(new Constr() { Code = ceilingCode, Area = area, Perimeter = perimeter });//Добавляем свойства в список свойств

                    index++;

                }
                else if (element is Floor floorAg)
                {
                    var floorCode = floorAg.FloorType.LookupParameter("Шифр конструкции").AsString().ToString();

                    var area_ = floorAg.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);
                    var perimeter_ = floorAg.get_Parameter(BuiltInParameter.HOST_PERIMETER_COMPUTED);

                    var area = ((int)UnitUtils.ConvertFromInternalUnits(area_.AsDouble(), UnitTypeId.Millimeters));
                    var perimeter = ((int)UnitUtils.ConvertFromInternalUnits(perimeter_.AsDouble(), UnitTypeId.Millimeters));

                    elementInfo.Add(new Constr() { Code = floorCode, Area = area, Perimeter = perimeter });

                    index++;
                }
            }

        }

    }
}
