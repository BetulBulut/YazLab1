using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Data.Abstract;
using ShopApp.webui.Models;
using X.PagedList;

namespace ShopApp.webui.Controllers
{
    public class CompareController : Controller
    {
        private ILaptopRepository _laptopRepository;
        public CompareController(ILaptopRepository laptopRepository)
        {
            this._laptopRepository = laptopRepository;
        }
        public IActionResult List(int page = 1)
        {
            const int pageSize = 4;
            // using (var context = new ShopContext())
            // {
            //     List<LaptopModel> laptopModels = new List<LaptopModel>();
            //     LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
            //     laptopListViewModel.Laptops = (from p in context.Laptops
            //                                    join e in context.LaptopSites on p.Id equals e.LaptopId
            //                                    select new LaptopModel
            //                                    {

            //                                        SiteId = e.SiteId,
            //                                        ImgUrl = e.ImgUrl,
            //                                        Marka = p.Marka,
            //                                        Price = e.Price,
            //                                        ModelAdi = p.ModelAdı,
            //                                        Puan = e.Puan


            //                                    }).ToList();

            //     laptopModels = laptopListViewModel.Laptops.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //     var laptopListViewModel2 = new LaptopListViewModel()
            //     {
            //         PageInfo = new PageInfo()
            //         {
            //             TotalItems = laptopListViewModel.Laptops.Count(),
            //             CurrentPage = page,
            //             ItemsPerPage = pageSize,

            //         },
            //         Laptops = laptopModels
            //     };

            using (var context2 = new ShopContext())
            {
                List<LaptopCardModel> laptopCardModels = new List<LaptopCardModel>();
                List<LaptopCardModel> laptopCardModels2 = new List<LaptopCardModel>();
                SiteViewListModel siteViewListModel = new SiteViewListModel();
                LaptopListViewModel laptopListViewModel3 = new LaptopListViewModel();
                laptopListViewModel3.Laptops = (from p in context2.Laptops
                                                select new LaptopModel
                                                {
                                                    Marka = p.Marka,
                                                    Id = p.Id,
                                                    ModelAdi = p.ModelAdı,
                                                }).ToList();

                siteViewListModel.siteModels = (from s in context2.LaptopSites
                                                select new SiteModel
                                                {
                                                    SiteId = s.SiteId,
                                                    Price = s.Price,
                                                    puan = s.Puan,
                                                    link = s.Details,
                                                    LaptopId = s.LaptopId,
                                                    ImgUrl = s.ImgUrl,
                                                }).ToList();



                for (int i = 0; i < laptopListViewModel3.Laptops.Count(); i++)
                {
                    LaptopCardModel laptopCardModel = new LaptopCardModel();
                    laptopCardModel.link = new List<string>();
                    laptopCardModel.Price = new List<int>();
                    laptopCardModel.Puan = new List<int>();
                    laptopCardModel.SiteId = new List<int>();
                    LaptopCardModelListViewModel laptopCardModelListViewModel = new LaptopCardModelListViewModel();




                    for (int j = 0; j < siteViewListModel.siteModels.Count(); j++)
                    {
                        if (laptopListViewModel3.Laptops[i].Id == siteViewListModel.siteModels[j].LaptopId)
                        {

                            laptopCardModel.ImgUrl = siteViewListModel.siteModels[j].ImgUrl;
                            laptopCardModel.link.Add(siteViewListModel.siteModels[j].link);
                            laptopCardModel.ModelAdi = laptopListViewModel3.Laptops[i].ModelAdi;
                            laptopCardModel.Price.Add(siteViewListModel.siteModels[j].Price);
                            laptopCardModel.SiteId.Add(siteViewListModel.siteModels[j].SiteId);
                            laptopCardModel.Puan.Add(siteViewListModel.siteModels[j].puan);




                        }
                    }
                    laptopCardModels.Add(laptopCardModel);

                }

                laptopCardModels2 = laptopCardModels.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                var laptopCardListViewModel = new LaptopCardModelListViewModel()
                {
                    pageInfo = new PageInfo()
                    {
                        TotalItems = laptopCardModels.Count(),
                        CurrentPage = page,
                        ItemsPerPage = pageSize,

                    },
                    laptopCardModels = laptopCardModels2,
                };



                return View(laptopCardListViewModel);


            }

        }


        [HttpPost]

        public IActionResult BrandFilterList(List<BrandFilterModel> model)
        {
            LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
            SiteViewListModel siteViewListModel = new SiteViewListModel();
            List<LaptopCardModel> laptopCardModels = new List<LaptopCardModel>();
            List<string> names = new List<string>();
            int counter = 0;

            using (var context2 = new ShopContext())
            {

                LaptopModel laptopModel = new LaptopModel();
                List<LaptopModel> brandLaptops = new List<LaptopModel>();

                foreach (var item2 in model)
                {
                    if (item2.IsSelected)
                    {
                        counter++;
                        laptopListViewModel.Laptops = (from p in context2.Laptops
                                                       where p.Marka == item2.BrandName
                                                       select new LaptopModel
                                                       {
                                                           Marka = p.Marka,
                                                           ModelAdi = p.ModelAdı,
                                                           Id = p.Id,

                                                       }).ToList();

                        siteViewListModel.siteModels = (from s in context2.LaptopSites
                                                        select new SiteModel
                                                        {
                                                            SiteId = s.SiteId,
                                                            Price = s.Price,
                                                            puan = s.Puan,
                                                            link = s.Details,
                                                            LaptopId = s.LaptopId,
                                                            ImgUrl = s.ImgUrl,
                                                        }).ToList();



                        for (int i = 0; i < laptopListViewModel.Laptops.Count; i++)
                        {
                            LaptopCardModel laptopCardModel = new LaptopCardModel();
                            laptopCardModel.link = new List<string>();
                            laptopCardModel.Price = new List<int>();
                            laptopCardModel.Puan = new List<int>();
                            laptopCardModel.SiteId = new List<int>();
                            for (int j = 0; j < siteViewListModel.siteModels.Count(); j++)
                            {
                                if (laptopListViewModel.Laptops[i].Id == siteViewListModel.siteModels[j].LaptopId)
                                {

                                    laptopCardModel.ImgUrl = siteViewListModel.siteModels[j].ImgUrl;
                                    laptopCardModel.link.Add(siteViewListModel.siteModels[j].link);
                                    laptopCardModel.ModelAdi = laptopListViewModel.Laptops[i].ModelAdi;
                                    laptopCardModel.Price.Add(siteViewListModel.siteModels[j].Price);
                                    laptopCardModel.SiteId.Add(siteViewListModel.siteModels[j].SiteId);
                                    laptopCardModel.Puan.Add(siteViewListModel.siteModels[j].puan);




                                }
                            }
                            laptopCardModels.Add(laptopCardModel);

                        }


                    }

                }
                if (counter == 0)
                {
                    return RedirectToAction("List");
                }
                foreach (var item in laptopCardModels)
                {
                    System.Console.WriteLine(item.ModelAdi);
                }
                return View(laptopCardModels);
            }
        }
        [HttpPost]
        public IActionResult OSFilterList(List<OSFilterModel> model)
        {
            LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
            SiteViewListModel siteViewListModel = new SiteViewListModel();
            List<LaptopCardModel> laptopCardModels = new List<LaptopCardModel>();
            List<string> names = new List<string>();
            int counter = 0;

            using (var context2 = new ShopContext())
            {

                LaptopModel laptopModel = new LaptopModel();

                foreach (var item2 in model)
                {
                    if (item2.IsSelected)
                    {
                        counter++;
                        laptopListViewModel.Laptops = (from p in context2.Laptops
                                                       where p.IsletimSistemi == item2.OSName
                                                       select new LaptopModel
                                                       {
                                                           Marka = p.Marka,
                                                           ModelAdi = p.ModelAdı,
                                                           Id = p.Id,

                                                       }).ToList();

                        siteViewListModel.siteModels = (from s in context2.LaptopSites
                                                        select new SiteModel
                                                        {
                                                            SiteId = s.SiteId,
                                                            Price = s.Price,
                                                            puan = s.Puan,
                                                            link = s.Details,
                                                            LaptopId = s.LaptopId,
                                                            ImgUrl = s.ImgUrl,
                                                        }).ToList();



                        for (int i = 0; i < laptopListViewModel.Laptops.Count; i++)
                        {
                            LaptopCardModel laptopCardModel = new LaptopCardModel();
                            laptopCardModel.link = new List<string>();
                            laptopCardModel.Price = new List<int>();
                            laptopCardModel.Puan = new List<int>();
                            laptopCardModel.SiteId = new List<int>();
                            for (int j = 0; j < siteViewListModel.siteModels.Count(); j++)
                            {
                                if (laptopListViewModel.Laptops[i].Id == siteViewListModel.siteModels[j].LaptopId)
                                {

                                    laptopCardModel.ImgUrl = siteViewListModel.siteModels[j].ImgUrl;
                                    laptopCardModel.link.Add(siteViewListModel.siteModels[j].link);
                                    laptopCardModel.ModelAdi = laptopListViewModel.Laptops[i].ModelAdi;
                                    laptopCardModel.Price.Add(siteViewListModel.siteModels[j].Price);
                                    laptopCardModel.SiteId.Add(siteViewListModel.siteModels[j].SiteId);
                                    laptopCardModel.Puan.Add(siteViewListModel.siteModels[j].puan);




                                }
                            }
                            laptopCardModels.Add(laptopCardModel);

                        }


                    }

                }
                if (counter == 0)
                {
                    return RedirectToAction("List");
                }
                foreach (var item in laptopCardModels)
                {
                    System.Console.WriteLine(item.ModelAdi);


                }




                return View(laptopCardModels);


            }
        }
        [HttpPost]
        public IActionResult ScreenFilterList(List<ScreenFilterModel> model)
        {
            LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
            SiteViewListModel siteViewListModel = new SiteViewListModel();
            List<LaptopCardModel> laptopCardModels = new List<LaptopCardModel>();
            List<string> names = new List<string>();
            int counter = 0;

            using (var context2 = new ShopContext())
            {

                LaptopModel laptopModel = new LaptopModel();

                foreach (var item2 in model)
                {
                    if (item2.IsSelected)
                    {
                        counter++;
                        laptopListViewModel.Laptops = (from p in context2.Laptops
                                                       where p.EkranBoyutu == item2.ScreenName
                                                       select new LaptopModel
                                                       {
                                                           Marka = p.Marka,
                                                           ModelAdi = p.ModelAdı,
                                                           Id = p.Id,

                                                       }).ToList();

                        siteViewListModel.siteModels = (from s in context2.LaptopSites
                                                        select new SiteModel
                                                        {
                                                            SiteId = s.SiteId,
                                                            Price = s.Price,
                                                            puan = s.Puan,
                                                            link = s.Details,
                                                            LaptopId = s.LaptopId,
                                                            ImgUrl = s.ImgUrl,
                                                        }).ToList();



                        for (int i = 0; i < laptopListViewModel.Laptops.Count; i++)
                        {
                            LaptopCardModel laptopCardModel = new LaptopCardModel();
                            laptopCardModel.link = new List<string>();
                            laptopCardModel.Price = new List<int>();
                            laptopCardModel.Puan = new List<int>();
                            laptopCardModel.SiteId = new List<int>();
                            for (int j = 0; j < siteViewListModel.siteModels.Count(); j++)
                            {
                                if (laptopListViewModel.Laptops[i].Id == siteViewListModel.siteModels[j].LaptopId)
                                {

                                    laptopCardModel.ImgUrl = siteViewListModel.siteModels[j].ImgUrl;
                                    laptopCardModel.link.Add(siteViewListModel.siteModels[j].link);
                                    laptopCardModel.ModelAdi = laptopListViewModel.Laptops[i].ModelAdi;
                                    laptopCardModel.Price.Add(siteViewListModel.siteModels[j].Price);
                                    laptopCardModel.SiteId.Add(siteViewListModel.siteModels[j].SiteId);
                                    laptopCardModel.Puan.Add(siteViewListModel.siteModels[j].puan);




                                }
                            }
                            laptopCardModels.Add(laptopCardModel);

                        }


                    }

                }
                if (counter == 0)
                {
                    return RedirectToAction("List");
                }
                foreach (var item in laptopCardModels)
                {
                    System.Console.WriteLine(item.ModelAdi);


                }




                return View(laptopCardModels);


            }
        }
        public IActionResult ProcessorFilterList(List<ProcessorFilterModel> model)
        {
            LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
            SiteViewListModel siteViewListModel = new SiteViewListModel();
            List<LaptopCardModel> laptopCardModels = new List<LaptopCardModel>();
            List<string> names = new List<string>();
            int counter = 0;

            using (var context2 = new ShopContext())
            {

                LaptopModel laptopModel = new LaptopModel();

                foreach (var item2 in model)
                {
                    if (item2.IsSelected)
                    {
                        counter++;
                        laptopListViewModel.Laptops = (from p in context2.Laptops
                                                       where p.IslemciTipi == item2.ProcessorName
                                                       select new LaptopModel
                                                       {
                                                           Marka = p.Marka,
                                                           ModelAdi = p.ModelAdı,
                                                           Id = p.Id,

                                                       }).ToList();

                        siteViewListModel.siteModels = (from s in context2.LaptopSites
                                                        select new SiteModel
                                                        {
                                                            SiteId = s.SiteId,
                                                            Price = s.Price,
                                                            puan = s.Puan,
                                                            link = s.Details,
                                                            LaptopId = s.LaptopId,
                                                            ImgUrl = s.ImgUrl,
                                                        }).ToList();



                        for (int i = 0; i < laptopListViewModel.Laptops.Count; i++)
                        {
                            LaptopCardModel laptopCardModel = new LaptopCardModel();
                            laptopCardModel.link = new List<string>();
                            laptopCardModel.Price = new List<int>();
                            laptopCardModel.Puan = new List<int>();
                            laptopCardModel.SiteId = new List<int>();
                            for (int j = 0; j < siteViewListModel.siteModels.Count(); j++)
                            {
                                if (laptopListViewModel.Laptops[i].Id == siteViewListModel.siteModels[j].LaptopId)
                                {

                                    laptopCardModel.ImgUrl = siteViewListModel.siteModels[j].ImgUrl;
                                    laptopCardModel.link.Add(siteViewListModel.siteModels[j].link);
                                    laptopCardModel.ModelAdi = laptopListViewModel.Laptops[i].ModelAdi;
                                    laptopCardModel.Price.Add(siteViewListModel.siteModels[j].Price);
                                    laptopCardModel.SiteId.Add(siteViewListModel.siteModels[j].SiteId);
                                    laptopCardModel.Puan.Add(siteViewListModel.siteModels[j].puan);




                                }
                            }
                            laptopCardModels.Add(laptopCardModel);

                        }


                    }

                }
                if (counter == 0)
                {
                    return RedirectToAction("List");
                }
                foreach (var item in laptopCardModels)
                {
                    System.Console.WriteLine(item.ModelAdi);


                }




                return View(laptopCardModels);

            }
        }
        public IActionResult Search(string q)
        {
            //LaptopListViewModel laptopListViewModel=new LaptopListViewModel();
            using (var context = new ShopContext())
            {
                SiteViewListModel siteViewListModel = new SiteViewListModel();
                List<LaptopCardModel> laptopCardModels = new List<LaptopCardModel>();
                LaptopListViewModel laptopListViewModel = new LaptopListViewModel()
                {
                    laptops = _laptopRepository.GetSearchResult(q),
                };
                siteViewListModel.siteModels = (from s in context.LaptopSites
                                                select new SiteModel
                                                {
                                                    SiteId = s.SiteId,
                                                    Price = s.Price,
                                                    puan = s.Puan,
                                                    link = s.Details,
                                                    LaptopId = s.LaptopId,
                                                    ImgUrl = s.ImgUrl,
                                                }).ToList();



                for (int i = 0; i < laptopListViewModel.laptops.Count; i++)
                {
                    LaptopCardModel laptopCardModel = new LaptopCardModel();
                    laptopCardModel.link = new List<string>();
                    laptopCardModel.Price = new List<int>();
                    laptopCardModel.Puan = new List<int>();
                    laptopCardModel.SiteId = new List<int>();
                    for (int j = 0; j < siteViewListModel.siteModels.Count(); j++)
                    {
                        if (laptopListViewModel.laptops[i].Id == siteViewListModel.siteModels[j].LaptopId)
                        {

                            laptopCardModel.ImgUrl = siteViewListModel.siteModels[j].ImgUrl;
                            laptopCardModel.link.Add(siteViewListModel.siteModels[j].link);
                            laptopCardModel.ModelAdi = laptopListViewModel.laptops[i].ModelAdı;
                            laptopCardModel.Price.Add(siteViewListModel.siteModels[j].Price);
                            laptopCardModel.SiteId.Add(siteViewListModel.siteModels[j].SiteId);
                            laptopCardModel.Puan.Add(siteViewListModel.siteModels[j].puan);
                        }
                    }
                    laptopCardModels.Add(laptopCardModel);

                }
                return View(laptopCardModels);


            }

        }











        public IActionResult GetLaptopsByPuan(int page = 1)
        {
            const int pageSize = 4;
            using (var context = new ShopContext())
            {
                List<LaptopModel> laptopModels = new List<LaptopModel>();
                LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
                laptopListViewModel.Laptops = (from p in context.Laptops
                                               join e in context.LaptopSites on p.Id equals e.LaptopId
                                               orderby e.Puan descending
                                               select new LaptopModel
                                               {
                                                   ImgUrl = e.ImgUrl,
                                                   Details = e.Details,
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
        public IActionResult GetLaptopsByLowPrice(int page = 1)
        {
            const int pageSize = 4;
            using (var context = new ShopContext())
            {
                List<LaptopModel> laptopModels = new List<LaptopModel>();
                LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
                laptopListViewModel.Laptops = (from p in context.Laptops
                                               join e in context.LaptopSites on p.Id equals e.LaptopId
                                               orderby e.Price
                                               select new LaptopModel
                                               {
                                                   ImgUrl = e.ImgUrl,
                                                   Details = e.Details,
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
        public IActionResult GetLaptopsByHighPrice(int page = 1)
        {
            const int pageSize = 4;
            using (var context = new ShopContext())
            {
                List<LaptopModel> laptopModels = new List<LaptopModel>();
                LaptopListViewModel laptopListViewModel = new LaptopListViewModel();
                laptopListViewModel.Laptops = (from p in context.Laptops
                                               join e in context.LaptopSites on p.Id equals e.LaptopId
                                               orderby e.Price descending
                                               select new LaptopModel
                                               {
                                                   ImgUrl = e.ImgUrl,
                                                   Details = e.Details,
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
