using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApp.Data.Abstract;
using ShopApp.webui.Models;

namespace ShopApp.webui.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult List()
        {
            using (var context = new ShopContext())
            {
                List<LaptopModel> laptopModels = new List<LaptopModel>();
                LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
                laptopListViewModel.Laptops = (from p in context.Laptops
                                               join e in context.LaptopSites on p.Id equals e.LaptopId
                                               select new LaptopModel
                                               {
                                                   ImgUrl = e.ImgUrl,

                                                   Marka = p.Marka,
                                                   Price = e.Price,
                                                   Puan = e.Puan


                                               }).ToList();


                return View(laptopListViewModel);

            }







        }
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using (var context = new ShopContext())
            {
                List<LaptopModel> laptopModels = new List<LaptopModel>();
                //LaptopModel laptopModel;
                LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
                laptopListViewModel.Laptops = (from p in context.Laptops
                                               where p.Id == id
                                               join e in context.LaptopSites on p.Id equals e.LaptopId
                                               select new LaptopModel
                                               {
                                                   ImgUrl = e.ImgUrl,
                                                   Marka = p.Marka,
                                                   Price = e.Price,
                                                   Puan = e.Puan,
                                                   ModelAdi = p.ModelAdı


                                               }).ToList();

                if (laptopListViewModel.Laptops != null)
                    foreach (var item in laptopListViewModel.Laptops)
                    {
                        return View(item);
                    }
                return NotFound();


            }
        }
    }
}