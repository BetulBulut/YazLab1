using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.webui.Models
{

    public class LaptopCardModelListViewModel
    {
        public PageInfo pageInfo { get; set; }
        public List<LaptopCardModel> laptopCardModels { get; set; }
    }
}