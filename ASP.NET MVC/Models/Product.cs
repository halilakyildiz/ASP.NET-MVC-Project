using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC.Models
{
    public class Product
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }
        public double UrunFiyat  { get; set; }
        public string UrunResim { get; set; }
    }
}