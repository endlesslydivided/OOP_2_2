using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class CustomerRepository : IRepository<Customer>
    {
        private ShopBase db;

        public CustomerRepository(ShopBase context)
        {
            this.db = context;
        }

        public void Create(Customer item)
        {
            db.Customers.Add(item);
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer != null)
                db.Customers.Remove(customer);
        }


        public Customer GetItem(int id)
        {
            return db.Customers.Find(id);
        }
        public Customer GetCustomerByEmail(string email)
        {
            return db.Customers.Select(x=>x).Where(x=>x.Email.Equals(email)).FirstOrDefault();
        }

        public IEnumerable<Customer> GetItemList()
        {
            return db.Customers;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Customer item)
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
