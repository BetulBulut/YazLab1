using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete;
using ShopApp.webui.Models;

namespace shopapp.webui.ViewComponents
{
    public class OSFilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new ShopContext())
            {
                List<OSFilterModel> cBox = new List<OSFilterModel>();
                List<OSFilterModel> cBox2 = new List<OSFilterModel>();
                List<string> liste1 = new List<string>();
                List<string> liste2 = new List<string>();

                cBox = (from p in context.Laptops
                        select new OSFilterModel
                        {
                            IsSelected = false,
                            OSName = p.IsletimSistemi
                        }).ToList();
                foreach (var item in cBox)
                {
                    liste1.Add(item.OSName);
                }
                liste2 = liste1.Distinct().ToList();
                foreach (var item in liste2)
                {
                    cBox2.Add(new OSFilterModel
                    {
                        IsSelected = false,
                        OSName = item

                    });
                }

                return View(cBox2);

            }

        }
    }
}