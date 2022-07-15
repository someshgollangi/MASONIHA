using ShoppingCore.Entities;
using ShoppingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingMvc.Infrastructure;


namespace ShoppingMvc.Controllers
{
    public class ItemController : Controller
    {
        ShoppingClient sc = new ShoppingClient();
        public async Task<ActionResult> Index()
        {
            var res = await sc.GetClient().GetAsync("api/Item/Get");
            if (res.IsSuccessStatusCode)
            {
                var i = res.Content.ReadAsStringAsync().Result;
                var items = JsonConvert.DeserializeObject<List<SubCategories>>(i);
                return View(items);
            }
            return View();
        }
        public async Task<ActionResult> Details(int id)
        {
            var res = await sc.GetClient().GetAsync("api/Item/Get/" + id.ToString());
            if(res.IsSuccessStatusCode)
            {
                var i= res.Content.ReadAsStringAsync().Result;
                var item = JsonConvert.DeserializeObject<SubCategories>(i);
                return View(item);
            }
            return View();

        }
        public async Task<ActionResult> ItemList(int pid)
        {
            var res = await sc.GetClient().GetAsync("api/Item/ItemList/"+pid.ToString());
            if(res.IsSuccessStatusCode)
            {
                var i= res.Content.ReadAsStringAsync().Result;
                var items = JsonConvert.DeserializeObject<List<SubCategories>>(i);
                return View(items);
            }
            return View();
            
        }
        [HttpPost]
        public async Task<ActionResult> Search(string name)
        {
            var res = await sc.GetClient().GetAsync("api/Item/Search/"+name.ToString());
            if(res.IsSuccessStatusCode)
            {
                var i = res.Content.ReadAsStringAsync().Result;
                var items = JsonConvert.DeserializeObject<List<SubCategories>>(i);
                return View(items);
            }
            return RedirectToAction("Index");
        }
    }
}