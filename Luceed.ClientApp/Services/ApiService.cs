using Luceed.ClientApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Luceed.ClientApp.Services
{
    public class ApiService
    {
       
        public async Task<List<Query1Model>> GetQuery1DataAsync(string itemDescription)
        {
            var credentials = new NetworkCredential("luceed_mb", "7e5y2Uza");
            var handler = new HttpClientHandler { Credentials = credentials };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");

            try
            {

                var task = Task.Run(() => client.GetAsync("http://apidemo.luceed.hr/datasnap/rest/artikli/naziv/" + itemDescription));
                task.Wait();
                var response = task.Result;
                HttpContent content = response.Content;
                string data = await content.ReadAsStringAsync();
                //dynamic d = JObject.Parse(data).Children().Children();
                JToken jobject = JObject.Parse(data);
                List<Query1Model> newList = new List<Query1Model>();
                var jtokenArray = jobject.Children().Children().Children().Children().Children().Children().ToArray();
                foreach (var item in jtokenArray)
                {
                    Query1Model nm = new Query1Model();
                    nm.ArtiklUid = item["artikl_uid"].ToString();
                    nm.NazivArtikla = item["naziv"].ToString();
                    newList.Add(nm);
                }

                return newList;
            }
            catch (Exception ex)
            {
                GlobalVariables.CurrentException = ex.Message + " at " + DateTime.Now + " in GetQuery1Data";
                return new List<Query1Model>();
            }

            
        }


        public async Task<List<Query2Model>> GetQuery2DataAsync(QueryInputData inputData)
        {
            var credentials = new NetworkCredential("luceed_mb", "7e5y2Uza");
            var handler = new HttpClientHandler { Credentials = credentials };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");

            try
            {
                var neki = inputData.FieldQ2F2.ToShortDateString();
                var task = Task.Run(() => client.GetAsync("http://apidemo.luceed.hr/datasnap/rest/mpobracun/placanja/" + inputData.FieldQ2F1 + "/" + inputData.FieldQ2F2.ToShortDateString() + "/" + inputData.FieldQ2F3.ToShortDateString()));
                task.Wait();
                var response = task.Result;
                HttpContent content = response.Content;
                string data = await content.ReadAsStringAsync();
                //dynamic d = JObject.Parse(data).Children().Children();
                JToken jobject = JObject.Parse(data);
                List<Query2Model> newList = new List<Query2Model>();
                var jtokenArray = jobject.Children().Children().Children().Children().Children().Children().ToArray();
                foreach (var item in jtokenArray)
                {
                    Query2Model nm = new Query2Model();
                    nm.VrstePlacanjaUid = item["vrste_placanja_uid"].ToString();
                    nm.Naziv = item["naziv"].ToString();
                    nm.Iznos = decimal.Parse(item["iznos"].ToString());
                    newList.Add(nm);
                }

                return newList;
            }
            catch (Exception ex)
            {
                GlobalVariables.CurrentException = ex.Message + " at " + DateTime.Now + " in GetQuery2Data";
                return new List<Query2Model>();
            }


        }


        public async Task<List<Query3Model>> GetQuery3DataAsync(QueryInputData inputData)
        {
            var credentials = new NetworkCredential("luceed_mb", "7e5y2Uza");
            var handler = new HttpClientHandler { Credentials = credentials };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");

            try
            {

                var task = Task.Run(() => client.GetAsync("http://apidemo.luceed.hr/datasnap/rest/mpobracun/artikli/" + inputData.FieldQ3F1 + "/" + inputData.FieldQ3F2.ToShortDateString() + "/" + inputData.FieldQ3F3.ToShortDateString()));
                task.Wait();
                var response = task.Result;
                HttpContent content = response.Content;
                string data = await content.ReadAsStringAsync();
                //dynamic d = JObject.Parse(data).Children().Children();
                JToken jobject = JObject.Parse(data);
                List<Query3Model> newList = new List<Query3Model>();
                var jtokenArray = jobject.Children().Children().Children().Children().Children().Children().ToArray();
                foreach (var item in jtokenArray)
                {
                    Query3Model nm = new Query3Model();
                    nm.ArtiklUid = item["artikl_uid"].ToString();
                    nm.NazivArtikla = item["naziv_artikla"].ToString();
                    nm.Kolicina = decimal.Parse(item["kolicina"].ToString());
                    nm.Iznos = decimal.Parse(item["iznos"].ToString());
                    nm.Usluga = char.Parse(item["iznos"].ToString());
                    newList.Add(nm);
                }

                return newList;
            }
            catch (Exception ex)
            {
                GlobalVariables.CurrentException = ex.Message + " at " + DateTime.Now + " in GetQuery3Data";
                return new List<Query3Model>();
            }


        }
    }
}