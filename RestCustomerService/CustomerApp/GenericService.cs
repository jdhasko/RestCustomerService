using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClassLibrary;

namespace CustomerApp
{
   static public  class GenericService<T> 
   {


       public static async Task<List<T>> GetAll(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string message = await client.GetStringAsync(url);
                List<T> tList = JsonConvert.DeserializeObject<List<T>>(message);
                return  tList;
            }
        }

        public static async Task<T> GetOne(string url, int ID)
        {
            using (HttpClient client = new HttpClient())
            {
                string message = await client.GetStringAsync(url + "/" + ID);
                T Object = JsonConvert.DeserializeObject<T>(message);
                return Object;
            }
        }

        public static async Task<HttpResponseMessage> Delete(string url, int ID)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.DeleteAsync(url + "/" +ID);
                return message;
            }
        }

    }
}
