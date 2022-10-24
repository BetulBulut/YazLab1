using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity;

namespace BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data
{
    public interface ILaptopSiteRepository : IRepository<LaptopSite>
    {

        LaptopSite GetProductDetails(string url);
        List<LaptopSite> GetProductsByCategory(string name, int page, int pageSize);
        List<LaptopSite> GetSearchResult(string searchString);

        int GetCountByCategory(string category);
        List<Laptop> GetLaptops();

    }
}