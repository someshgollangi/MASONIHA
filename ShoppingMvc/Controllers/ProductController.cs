using ShoppingCore.Entities;
using ShoppingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShoppingMvc.Infrastructure;

namespace ShoppingMvc.Controllers
{
    [CAuthentication]
    public class ProductController : Controller
    {
        ShoppingClient sc = new ShoppingClient();
        List<Products> pro = new List<Products>();
        // GET: Product
         public async Task<ActionResult> Index()
        {
             HttpResponseMessage res = await sc.GetClient().GetAsync("api/Product/Get");
             if(res.IsSuccessStatusCode)
             {
                 var Prores = res.Content.ReadAsStringAsync().Result;
                 pro = JsonConvert.DeserializeObject<List<Products>>(Prores);
             }
             return View(pro);
        }
    }
}