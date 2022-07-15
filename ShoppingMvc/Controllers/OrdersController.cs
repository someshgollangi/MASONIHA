using Newtonsoft.Json;
using ShoppingCore.Entities;
using ShoppingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShoppingMvc.Infrastructure;
namespace ShoppingMvc.Controllers
{
    [CAuthentication]
    public class OrdersController : Controller
    {
        // GET: Orders
        ShoppingClient sc = new ShoppingClient();
        public async Task<ActionResult> Index()
        {
            var res = await sc.GetClient().GetAsync("api/Orders/Get");
            if (res.IsSuccessStatusCode)
            {
                var i = res.Content.ReadAsStringAsync().Result;
                var orders = JsonConvert.DeserializeObject<List<Orders>>(i);
                if (orders.Count() != 0)
                    ViewBag.Total = orders.Sum(x => x.OrderPrice);
                return View(orders);
            }
            return View();
        }
        public async Task<ActionResult> Details(int id)
        {
            var res = await sc.GetClient().GetAsync("api/Orders/Get/" + id.ToString());
            if (res.IsSuccessStatusCode)
            {
                var i = res.Content.ReadAsStringAsync().Result;
                var item = JsonConvert.DeserializeObject<Orders>(i);
                return View(item);
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            var res = await sc.GetClient().DeleteAsync("api/Orders/Delete/"+ id.ToString());
            if(res.IsSuccessStatusCode)
            {
                var i = res.Content.ReadAsStringAsync().Result;
                var item = JsonConvert.DeserializeObject<Orders>(i);
                return View(item);
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> AddToCart(int id)
        {
            var res = await sc.GetClient().GetAsync("api/Orders/AddToCart/" + id.ToString());
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Checkout(int total)
        {
            ViewBag.Total = total;
            return View();
        }
        public async Task<ActionResult> ConfirmCheckout()
        {
            var res = await sc.GetClient().GetAsync("api/Orders/ConfirmCheckout");
            if (res.IsSuccessStatusCode)
            {
                return View();
            }
            return RedirectToAction("Index");

        }



    }
}