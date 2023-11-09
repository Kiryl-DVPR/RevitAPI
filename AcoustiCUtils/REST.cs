using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AcoustiCUtils;
using AcoustiCUtils.Library;
using Autodesk.Revit.UI;
using Newtonsoft.Json;

namespace REST
{
    public static class Requests
    {

        private static string Host = "http://158.160.77.34:3005/api/v1/calcQuantity";

        public static async Task<HttpResponseMessage> PostRequest(string address, List<Constr> content)
        {
            

            HttpClient client = new HttpClient();

            client.Timeout = TimeSpan.FromSeconds(5);

            try
            {
                //Uri uri = new Uri(address);

                JsonContent contenJson = JsonContent.Create(content);

                var response = await client.PostAsync(address, contenJson);

                return response;


            }
            catch (Exception x)
            {
                Console.WriteLine("Ошибка" + x.ToString());
            }
            finally
            {
                client.Dispose();
            }

            return null;


        }

        public static async Task<HttpResponseMessage> GetRequest(string address)
        {
            HttpClient client = new HttpClient();

            try
            {
                //Uri uri = new Uri(address);

                return await client.GetAsync(address);
            }
            catch (Exception x)
            {
                Console.WriteLine("Ошибка" + x.ToString());
            }
            finally
            {
                client.Dispose();
            }

            return null;



        }

        public static async Task<List<Product>> GetCaclcProduct(List<Constr> constr)
        {

            var postresponse = await PostRequest(Host, constr);

            string jsonStringProduct = await postresponse.Content.ReadAsStringAsync(); // записываем содержимое файла в строковую переменную

            var response = JsonConvert.DeserializeObject<Response>(jsonStringProduct); // информацию из строковой переносим в список обьектов

            return response.data;
        }
    }


}
