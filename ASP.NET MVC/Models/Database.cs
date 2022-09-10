using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC.Models
{
    public static class Database
    {
        private static List<Product> PRODUCTS;
        private static List<User> USERS;
        private static int ID = 6;//5 adet ürün aşağıda eklendiği için 5 ten başlatıyoruz
        static Database()
        {
            PRODUCTS = new List<Product>()
            {
                new Product(){UrunId=1,UrunAdi="sweat",UrunAciklama="L beden çok üzel",UrunFiyat=63,UrunResim="/images/products/pr1.jpg"},
                new Product(){UrunId=2,UrunAdi="tracksuit",UrunAciklama="L beden çok üzel",UrunFiyat=99,UrunResim="/images/products/pr2.jpg"},
                new Product(){UrunId=3,UrunAdi="pat",UrunAciklama="L beden çok üzel",UrunFiyat=120,UrunResim="/images/products/pr3.jpeg"},
                new Product(){UrunId=4,UrunAdi="kazak",UrunAciklama="L beden çok üzel",UrunFiyat=119,UrunResim="/images/products/pr4.jpg"},
                new Product(){UrunId=5,UrunAdi="tshirt",UrunAciklama="L beden çok üzel",UrunFiyat=87,UrunResim="/images/products/pr5.jpg"}
            };
            USERS = new List<User>()
            {
                new User(){UserId=0,UserAdi="Admin",UserEmail="admin@gmail.com",UserPassword="admin123",Role="A"},
                 new User(){UserId=1,UserAdi="Ahmet Kaya",UserEmail="ahmetkaya@gmail.com",UserPassword="1234",Role="U"},
                 new User(){UserId=1,UserAdi="Selma Bağcan",UserEmail="selmabagcan@gmail.com",UserPassword="1234",Role="U"},
                 new User(){UserId=1,UserAdi="Barış Manço",UserEmail="barismanco@gmail.com",UserPassword="1234",Role="U"}
            };
        }
        public static List<Product> Products
        {
            get
            {
                return PRODUCTS;
            }
        }
        public static List<User> Users
        {
            get
            {
                return USERS;
            }
        }
        public static void AddProduct(Product pr)
        {
            pr.UrunId = ID++;
            PRODUCTS.Add(pr);
        }
        public static void AddUser(User us)
        {
            USERS.Add(us);
        }
    }
}