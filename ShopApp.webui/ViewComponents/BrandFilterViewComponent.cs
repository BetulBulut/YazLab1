using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete;
using Microsoft.AspNetCore.Mvc;
using ShopApp.webui.Models;


namespace shopapp.webui.ViewComponents
{
    public class BrandFilterViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()

        {
            //BrandFilterViewModel brandFilterViewModel;
            List<BrandFilterModel> cBox = new List<BrandFilterModel>();
            List<BrandFilterModel> cBox2 = new List<BrandFilterModel>();
            List<string> liste1 = new List<string>();
            List<string> liste2 = new List<string>();
            using (var context = new ShopContext())
            {

                cBox = (from p in context.Laptops
                        select new BrandFilterModel
                        {
                            IsSelected = false,
                            BrandName = p.Marka
                        }).ToList();
                foreach (var item in cBox)
                {
                    liste1.Add(item.BrandName);
                }
                liste2 = liste1.Distinct().ToList();
                foreach (var item in liste2)
                {
                    cBox2.Add(new BrandFilterModel
                    {
                        IsSelected = false,
                        BrandName = item

                    });
                }

                return View(cBox2);


            }



        }
    }
}