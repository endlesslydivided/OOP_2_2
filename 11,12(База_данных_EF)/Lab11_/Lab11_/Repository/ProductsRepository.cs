using Lab11_.Classes;
using Lab11_.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_.Repository
{
    class ProductsRepository : IRepository<Products>
    {
        private ApplicationContext db;

        public ProductsRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(Products item)
        {
            db.Products.Add(item);
        }

        public void Delete(int id)
        {
            Products Products = db.Products.Find(id);
            if (Products != null)
                db.Products.Remove(Products);
        }


        public Products GetItem(int id)
        {
            return db.Products.Find(id);
        }
        public Products GetProductsByEmail(string name)
        {
            return db.Products.Select(x=>x).Where(x=>x.ProductName.Equals(name)).FirstOrDefault();
        }

        public IEnumerable<Products> GetItemList()
        {
            return db.Products;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Products item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
