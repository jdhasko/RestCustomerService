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

        public static async Task<HttpResponseMessage> Post(string url,T newT)
        {
            using (HttpClient client = new HttpClient())
            {
                string ObjectJson = JsonConvert.SerializeObject(newT);
                var data = new StringContent(ObjectJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync(url,data);
                return message;
            }
        }

        public static async Task<HttpResponseMessage> Put(string url, T newT)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(newT);
                var data = new StringContent(json, Encoding.UTF8,"application/json");
                HttpResponseMessage message = await client.PutAsync(url, data);
                return message;
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
