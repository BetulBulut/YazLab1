using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity;

namespace ShopApp.Data.Abstract
{
    public interface ILaptopRepository : IRepository<Laptop>
    {
        List<string> GetBrands();
        List<Laptop> GetSearchResult(string q);

    }
}