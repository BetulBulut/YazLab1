using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity;
using ShopApp.Data.Abstract;

namespace ShopApp.Data.Concrete
{
    public class EfCoreLaptopRepository : EfCoreGenericRepository<Laptop, ShopContext>, ILaptopRepository
    {
        // public List<string> GetBrands()
        // {
        //     List<string> Brands=new List<string>();
        //     using(var context=new ShopContext())
        //     {
        //        var ap=(from p in context.Laptops
        //                 select new{
        //                     p.Marka
        //                 }).ToList();
        //                 return ap;
        //     }
        // }
        public List<string> GetBrands()
        {
            throw new NotImplementedException();
        }

        public List<Laptop> GetSearchResult(string q)
        {
            using (var context = new ShopContext())
            {
                var products = context.Laptops
                                    .Where(i => i.ModelAdı.ToLower().Contains(q.ToLower())).AsQueryable();
                return products.ToList();
            }
        }
    }
}