using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.webui.Models
{
    public class SiteModel
    {
        public int SiteId { get; set; }
        public string link { get; set; }
        public int puan { get; set; }
        public int Price { get; set; }
        public string LaptopId { get; set; }
        public string ImgUrl { get; set; }
    }
}