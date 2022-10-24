using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete;
using Microsoft.AspNetCore.Mvc;
using ShopApp.webui.Models;

namespace shopapp.webui.ViewComponents
{
    public class ProcessorFilterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new ShopContext())
            {
                List<ProcessorFilterModel> cBox = new List<ProcessorFilterModel>();
                List<ProcessorFilterModel> cBox2 = new List<ProcessorFilterModel>();
                List<string> liste1 = new List<string>();
                List<string> liste2 = new List<string>();
                cBox = (from p in context.Laptops
                        select new ProcessorFilterModel
                        {
                            IsSelected = false,
                            ProcessorName = p.IslemciTipi
                        }).ToList();


                foreach (var item in cBox)
                {
                    liste1.Add(item.ProcessorName);
                }
                liste2 = liste1.Distinct().ToList();
                foreach (var item in liste2)
                {
                    cBox2.Add(new ProcessorFilterModel
                    {
                        IsSelected = false,
                        ProcessorName = item

                    });
                }

                return View(cBox2);
            }
        }
    }
}