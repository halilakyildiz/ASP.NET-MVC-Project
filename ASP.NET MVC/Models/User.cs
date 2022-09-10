using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserAdi { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string Role { get; set; }
    }
}