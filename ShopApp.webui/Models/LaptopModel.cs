using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.webui.Models
{
    public class LaptopModel
    {
        public string Id { get; set; }
        public string ImgUrl { get; set; }
        public string Marka { get; set; }
        public int SiteId { get; set; }
        public int Price { get; set; }
        public int Puan { get; set; }
        public string ModelAdi { get; set; }
        public string Details { get; set; }
        public SiteModel siteModel { get; set; }
    }
}