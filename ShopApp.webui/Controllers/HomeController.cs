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


namespace ShopApp.Controllers
{
    public class HomeController : Controller
    {
        private ILaptopSiteRepository _laptopSiteRepository;
        public HomeController(ILaptopSiteRepository laptopSiteRepository)
        {
            _laptopSiteRepository = laptopSiteRepository;
        }
        private ILaptopRepository _laptopRepository;
        // public HomeController(ILaptopRepository laptopRepository)
        // {
        //     _laptopRepository = laptopRepository;

        // }
        public IActionResult Index(int page = 1)
        {
            const int pageSize = 4;
            using (var context = new ShopContext())
            {
                List<LaptopModel> laptopModels = new List<LaptopModel>();
                LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
                laptopListViewModel.Laptops = (from p in context.Laptops
                                               join e in context.LaptopSites on p.Id equals e.LaptopId
                                               select new LaptopModel
                                               {
                                                   Id = e.LaptopId,
                                                   ImgUrl = e.ImgUrl,

                                                   Marka = p.Marka,
                                                   Price = e.Price,
                                                   ModelAdi = p.ModelAdı,
                                                   Puan = e.Puan


                                               }).ToList();
                laptopModels = laptopListViewModel.Laptops.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var laptopListViewModel2 = new LaptopListViewModel()
                {
                    PageInfo = new PageInfo()
                    {
                        TotalItems = laptopListViewModel.Laptops.Count(),
                        CurrentPage = page,
                        ItemsPerPage = pageSize,

                    },
                    Laptops = laptopModels
                };
                return View(laptopListViewModel2);
            }







        }





    }
}
