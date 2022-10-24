using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete;
using Microsoft.AspNetCore.Mvc;
using ShopApp.webui.Models;

namespace shopapp.webui.ViewComponents
{
    public class ScreenFilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new ShopContext())
            {
                List<ScreenFilterModel> cBox = new List<ScreenFilterModel>();
                List<ScreenFilterModel> cBox2 = new List<ScreenFilterModel>();
                List<string> liste1 = new List<string>();
                List<string> liste2 = new List<string>();
                cBox = (from p in context.Laptops
                        select new ScreenFilterModel
                        {
                            IsSelected = false,
                            ScreenName = p.EkranBoyutu
                        }).ToList();

                foreach (var item in cBox)
                {
                    liste1.Add(item.ScreenName);
                }
                liste2 = liste1.Distinct().ToList();
                foreach (var item in liste2)
                {
                    cBox2.Add(new ScreenFilterModel
                    {
                        IsSelected = false,
                        ScreenName = item

                    });
                }

                return View(cBox2);
            }
        }
    }
}