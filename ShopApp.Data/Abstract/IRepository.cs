using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data
{
    public interface IRepository<T>
    {
        T GetById(string id);

        List<T> GetAll();

        void Create(T entity);

        void Update(T entity);
        void Delete(T entity);
    }
}