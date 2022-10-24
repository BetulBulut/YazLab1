using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity;

namespace BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.business.Abstract
{
    public interface ILaptopService
    {
        Laptop GetById(string id);

        List<Laptop> GetAll();

        void Create(Laptop entity);

        void Update(Laptop entity);
        void Delete(Laptop entity);
    }

}
