using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity
{
    public class Laptop
    {

        public string ModelAdı { get; set; }
        public string Id { get; set; }
        public string Marka { get; set; }
        public string IsletimSistemi { get; set; }
        public string IslemciTipi { get; set; }
        public string Islemci_nesli { get; set; }
        public string Ram { get; set; }
        public string DiskBoyutu { get; set; }
        public string DiskTuru { get; set; }
        public string EkranBoyutu { get; set; }

        public List<LaptopSite> LaptopSites { get; set; }
    }
}