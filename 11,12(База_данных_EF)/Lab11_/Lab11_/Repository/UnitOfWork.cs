using Lab11_.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_.Repository
{
    class UnitOfWork : IDisposable
    {
        private ApplicationContext db = new ApplicationContext();
        private ProductsRepository productsRepository;
        private UsersRepository usersRepository;

        public ProductsRepository Products
        {
            get
            {
                if (productsRepository == null)
                    productsRepository = new ProductsRepository(db);
                return productsRepository;
            }
        }

        public UsersRepository Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new UsersRepository(db);
                return usersRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
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
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
