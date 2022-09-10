using ASP.NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Web.Security;

namespace ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.products = Database.Products;
            ViewBag.users = Database.Users;
            return View();
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string name_surname,string mail,string password,string password_repeat)
        {
           Database.AddUser(new User() { UserId = 1, UserAdi = name_surname, UserEmail = mail, UserPassword = password,Role="U" });            
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string mail, string password)
        {
            List<User> ur = Database.Users.Where(i => i.UserEmail == mail && i.UserPassword == password).ToList();
            if (ur.Count != 0)
            {
                FormsAuthentication.SetAuthCookie(ur[0].UserEmail, false);
                if(ur[0].Role.Equals("U"))// Rol kullanıcı ise kullanıcı sayfasına
                    return RedirectToAction("UserHome", "Home");
                if (ur[0].Role.Equals("A"))// Rol admin ise admin paneline yönlendir. Sayfalara yetkisi olan kullanıcı erişebiliyor.
                    return RedirectToAction("AdminProducts", "Home");
            }
            ViewBag.Mesaj = "Hatalı bilgi girdiniz";
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Home");
        }
        public ActionResult ProductList(int id)
        {
            List<Product> pr = Database.Products.Where(i => i.UrunId == id).ToList();
            return View(pr[0]);
        }

        [HttpGet]
        [Authorize(Roles = "A")]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "A")]
        public ActionResult AddProduct(HttpPostedFileBase file,string urunAd, string urunBilgi, string urunFiyat)
        {

            string path = "",pic="";
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                path = System.IO.Path.Combine(Server.MapPath("~/images/products"), pic);
                // file is uploaded
                file.SaveAs(path);

            }
            // after successfully uploading redirect the user
            Database.AddProduct(new Product() { UrunId = 1, UrunAdi = urunAd, UrunAciklama = urunBilgi, UrunFiyat =Convert.ToDouble(urunFiyat),UrunResim= "/images/products/" + pic });
            return View();
        }

        [Authorize]
        [Authorize(Roles = "A")]
        public ActionResult AdminProducts()
        {
            List<Product> products = Database.Products;
            return View(products);
        }
        [Authorize]
        [Authorize(Roles = "A")]
        public ActionResult AdminUsers()
        {
            List<User> users = Database.Users;
            return View(users);
        }
        [Authorize]
        [Authorize(Roles = "A")]
        public ActionResult AdminAccount()
        {
            return View();
        }
        [Authorize(Roles="U")]
        public ActionResult UserHome()
        {
            return View(Database.Users);
        }
    }
}
