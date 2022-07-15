using ShoppingCore.Entities;
using ShoppingMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ShoppingMvc.Controllers
{
    public class AccountController : Controller
    {
        ShoppingClient sc = new ShoppingClient();
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                User_tbl user = new User_tbl { UserName = username, Password = password };
                var res = await sc.GetClient().PostAsJsonAsync("api/Account/Login", user);
                if (res.IsSuccessStatusCode)
                {
                    var u = res.Content.ReadAsStringAsync().Result;
                    var userres = JsonConvert.DeserializeObject<User_tbl>(u);
                    if (userres != null)
                    {
                        Session["UserName"] = user.UserName;
                        Session["UserID"] = user.UserID;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View();
                    }
                }
            }
           
             return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(User_tbl user)
        {
            var res = await sc.GetClient().PostAsJsonAsync("api/Account/Register",user);
            if(res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View();
            /* try
             {
                 if (ModelState.IsValid)
                 {
                     using (var context = new Context())
                     {
                         User_tbl user1 = context.user_Tbls
                         .Where(u => u.UserID == user.UserID && u.Password == user.Password)
                         .FirstOrDefault();

                         if (user1 != null)
                         {
                             Session["UserName"] = user.UserName;
                             ModelState.AddModelError("", "User Already Exists");
                             return View(user);
                         }

                         else
                         {
                             user.RoleId = 2;
                             context.user_Tbls.Add(user);
                             context.SaveChanges();
                             return RedirectToAction("Index", "Home");
                             using (var db = new Context())
                             {
                                 var newUser = db.user_Tbls.Create();
                                 newUser.UserID = user.UserID;
                                 newUser.UserName = user.UserName;
                                 newUser.Email = user.Email;
                                 newUser.MobileNumber = user.MobileNumber;
                                 newUser.Password = user.Password;
                                 newUser.ConfirmPassword = user.ConfirmPassword;
                                 newUser.RoleId = 2;
                                 db.user_Tbls.Add(newUser);
                                 db.SaveChanges();
                                 return RedirectToAction("Index", "Home");
                             }
                         }
                     }
                 }

             }
             catch (DbEntityValidationException e)
             {
                 foreach (var eve in e.EntityValidationErrors)
                 {
                     Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                     eve.Entry.Entity.GetType().Name, eve.Entry.State);
                     foreach (var ve in eve.ValidationErrors)
                     {
                         Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                         ve.PropertyName, ve.ErrorMessage);
                     }
                 }
                 throw;
             }
             return View();
            */
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["UserName"] = string.Empty;
            Session["UserID"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }
        private bool IsValid(string username, string password)
        {
            //var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new Context())
            {
                var user = db.user_Tbls.FirstOrDefault(u => u.UserName == username);
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }
    }
}