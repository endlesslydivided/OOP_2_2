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
    class UsersRepository : IRepository<Users>
    {
        private ApplicationContext db;

        public UsersRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(Users item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            Users Users = db.Users.Find(id);
            if (Users != null)
                db.Users.Remove(Users);
        }


        public Users GetItem(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<Users> GetItemList()
        {
            return db.Users;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Users item)
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
