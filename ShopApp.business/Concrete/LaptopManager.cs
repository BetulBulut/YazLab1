using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.business.Abstract;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity;
using ShopApp.Data.Abstract;

namespace BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.business.Concrete
{
    public class LaptopManager : ILaptopService
    {
        private ILaptopRepository laptopRepository;
        public void Create(Laptop entity)
        {
            laptopRepository.Create(entity);
        }

        public void Delete(Laptop entity)
        {
            laptopRepository.Delete(entity);
        }

        public List<Laptop> GetAll()
        {
            return laptopRepository.GetAll();
        }

        public Laptop GetById(string id)
        {
            return laptopRepository.GetById(id);
        }

        public void Update(Laptop entity)
        {
            laptopRepository.Update(entity);
        }
    }
}