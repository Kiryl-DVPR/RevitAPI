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
using Autodesk.Revit.UI;
using Newtonsoft.Json;

namespace REST
{
    public static class Requests
    {

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
    }
}
