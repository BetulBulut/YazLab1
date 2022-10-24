using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity
{
    public class LaptopSite
    {
        public int SiteId { get; set; }
        public string LaptopId { get; set; }
        public int Puan { get; set; }
        public int Price { get; set; }
        public string ImgUrl { get; set; }
        public string Details { get; set; }

        public Laptop Laptop { get; set; }
        public Site Site { get; set; }
    }
}