using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity
{
    public class Site
    {


        public int Id { get; set; }
        public string Name { get; set; }

        public List<LaptopSite> LaptopSites { get; set; }
    }
}