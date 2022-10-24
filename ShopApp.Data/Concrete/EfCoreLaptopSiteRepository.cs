using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data.Abstract;

namespace BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete
{
    public class EfCoreLaptopSiteRepository : EfCoreGenericRepository<LaptopSite, ShopContext>, ILaptopSiteRepository
    {
        private ILaptopRepository _laptopRepository;
        public EfCoreLaptopSiteRepository(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;

        }
        public int GetCountByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<Laptop> GetLaptops()
        {
            throw new NotImplementedException();
        }

        // public List<Laptop> GetLaptops()
        // {
        //     using(var context=new ShopContext())
        //     {
        //         var ap =  (from p in context.Laptops
        //               join e in context.LaptopSites on p.Id equals e.LaptopId
        //               select new 
        //                         { 
        //                             ImgUrl=e.ImgUrl,
        //                             Details=e.Details,
        //                             Marka=p.Marka,
        //                             Price=e.Price,
        //                             Puan=e.Puan

        //                         }).ToList();
        //     }


        // }




        // }



        LaptopSite ILaptopSiteRepository.GetProductDetails(string url)
        {
            throw new NotImplementedException();
        }

        List<LaptopSite> ILaptopSiteRepository.GetProductsByCategory(string name, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        List<LaptopSite> ILaptopSiteRepository.GetSearchResult(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}