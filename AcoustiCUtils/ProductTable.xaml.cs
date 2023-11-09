using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD = System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Controls.Primitives;
using System.Windows;
using Window = System.Windows.Window;
using Autodesk.Revit.ApplicationServices;
using System.Windows.Forms;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace AcoustiCUtils
{
    public partial class ProductTable : Window
    {

        private List<Product> _productsList = new List<Product>();
        private List<Construction> _constructionsList = new List<Construction>();
        public ProductTable(List<Product> productsList, List<Construction> construction)
        {
            InitializeComponent();
            ProductsListTable.ItemsSource = productsList;
            ConstrListTable.ItemsSource = construction;

            _productsList = productsList;
            _constructionsList = construction;
         
        }

        public void UpdateListOfItems(List<Product> products)
        {
            ProductsListTable.ItemsSource = products;
        }

        private void Button_Click(object sender, SD.RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            Worksheet sheet2 = (Worksheet)workbook.Sheets.Add();
            

            sheet1.Name = "Материалы";
            sheet2.Name = "Конструкции";

            //Ширина столбцов спецификации при выводе в Excel:
            sheet1.Columns[1].ColumnWidth = 4;
            sheet1.Columns[2].ColumnWidth = 50;
            sheet1.Columns[3].ColumnWidth = 7;
            sheet1.Columns[4].ColumnWidth = 7;
            sheet1.Columns[5].ColumnWidth = 10;
            sheet1.Columns[6].ColumnWidth = 20;

            //Ширина столбцов спецификации при выводе в Excel:
            sheet2.Columns[1].ColumnWidth = 4;
            sheet2.Columns[2].ColumnWidth = 60;
            sheet2.Columns[3].ColumnWidth = 10;
            sheet2.Columns[4].ColumnWidth = 7;
            sheet2.Columns[5].ColumnWidth = 7;
            sheet2.Columns[6].ColumnWidth = 10;
            sheet2.Columns[7].ColumnWidth = 20;

            //Заголовки таблицы материалов
            for (int j = 0; j < ProductsListTable.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1]; // Создаём ячейки в Excel
                sheet1.Cells[1, j + 1].Font.Bold = true; // Стиль ячейки в Excel

                myRange.Value2 = ProductsListTable.Columns[j].Header; //Записываем в Excel содержимое таблицы MaterialTableAG
              
            }
            //Данные из списка материалов
            for (int i = 0; i < ProductsListTable.Columns.Count; i++)
            {
                for (int j = 0; j < _productsList.Count; j++)
                {
                    
                        Range myRange = (Range)sheet1.Cells[j + 2, i+1]; //Создаём ячейку в Excel файле

                        switch (i)
                        {
                            case 0: myRange.Value2 = 0; break;
                            case 1: myRange.Value2 = _productsList[j].Name; break;
                            case 2: myRange.Value2 = _productsList[j].Units; break;
                            case 3: myRange.Value2 = _productsList[j].Quantity; break;
                            case 4: myRange.Value2 = _productsList[j].Code; break;
                            default: break;
                        };
                }
            }

            //Заголовки таблицы конструкций
            for (int j = 0; j < ConstrListTable.Columns.Count; j++)
            {
                Range myRange = (Range)sheet2.Cells[1, j + 1]; // Создаём ячейки в Excel
                sheet2.Cells[1, j + 1].Font.Bold = true; // Стиль ячейки в Excel

                myRange.Value2 = ConstrListTable.Columns[j].Header; //Записываем в Excel содержимое таблицы MaterialTableAG

            }
            //Данные из списка конструкций
            for (int i = 0; i < ConstrListTable.Columns.Count; i++)
            {
                for (int j = 0; j < _constructionsList.Count; j++)
                {
                    
                        Range myRange = (Range)sheet2.Cells[j + 2, i+1]; //Создаём ячейку в Excel файле

                        switch (i)
                        {
                            case 0: myRange.Value2 = _constructionsList[j].Id; break;
                            case 1: myRange.Value2 = _constructionsList[j].Name; break;
                            case 2: myRange.Value2 = _constructionsList[j].Code; break;
                            case 3: myRange.Value2 = _constructionsList[j].Units; break;
                            case 4: myRange.Value2 = _constructionsList[j].Quantity; break;
                            case 5: myRange.Value2 = _constructionsList[j].Weight; break;
                            case 6: myRange.Value2 = _constructionsList[j].Description; break;
                            default: break;
                        };
                    

                }
            }
        }

       
        private void Button_ClickCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Clean(object sender, RoutedEventArgs e)
        {
           SD.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
