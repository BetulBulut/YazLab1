using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.webui.Models
{

    public class LaptopCardModel
    {
        public List<int> Price { get; set; }
        public List<int> SiteId { get; set; }
        public List<int> Puan { get; set; }
        public List<string> link { get; set; }

        public string ModelAdi { get; set; }
        public string ImgUrl { get; set; }
    }
}