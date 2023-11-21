using Luceed.ClientApp.Models;
using Luceed.ClientApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Luceed.ClientApp.Controllers
{
    public class HomeController : Controller
    {
        QueryInputData qid = new QueryInputData();
        DataViewModel dvm = new DataViewModel();
        
        public ActionResult Index()
        {
            ViewBag.CurrentException = GlobalVariables.CurrentException;
            ViewBag.Query1 = dvm.Query1Models;
            ViewBag.Query2 = dvm.Query2Models;
            ViewBag.Query3 = dvm.Query3Models;
            return View(qid);
        }


        [HttpPost]
        public ActionResult Index([Bind(Include = "FieldQ1F1, FieldQ2F1, FieldQ2F2, FieldQ2F3, FieldQ3F1, FieldQ3F2, FieldQ3F3")] QueryInputData inputData, string submitButton)
        {

            ViewBag.CurrentException = GlobalVariables.CurrentException;
            switch (submitButton)
            {
                case "Query1":
                    ApiService apiss = new ApiService();
                    var list = Task.Run(async () => await apiss.GetQuery1DataAsync(inputData.FieldQ1F1));
                    list.Wait();
                    List<Query1Model> newList = new List<Query1Model>();
                    foreach (var item in list.Result)
                    {
                        newList.Add(item);
                    }
                    ViewBag.Query1 = newList;
                    break;
                case "Query2":
                    ApiService apiss2 = new ApiService();
                    var list2 = Task.Run(async () => await apiss2.GetQuery2DataAsync(inputData));
                    list2.Wait();
                    List<Query2Model> newList2 = new List<Query2Model>();
                    foreach (var item in list2.Result)
                    {
                        newList2.Add(item);
                    }
                    ViewBag.Query2 = newList2;
                    break;
                case "Query3":
                    ApiService apiss3 = new ApiService();
                    var list3 = Task.Run(async () => await apiss3.GetQuery3DataAsync(inputData));
                    list3.Wait();
                    List<Query3Model> newList3 = new List<Query3Model>();
                    foreach (var item in list3.Result)
                    {
                        newList3.Add(item);
                    }
                    ViewBag.Query3 = newList3;
                    break;



            }


            return View();
        }


    }
}