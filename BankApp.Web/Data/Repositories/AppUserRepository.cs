using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Web.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly BankContext _context;
        public AppUserRepository(BankContext context)
        {
            _context = context;
        }
        public List<AppUser> GetAll()
        {
            return _context.Set<AppUser>().ToList();
        }
        public AppUser GetById(int id)
        {
            return _context.AppUsers.SingleOrDefault(x => x.Id == id);
        }
        public void Create(AppUser appUser)
        {
            _context.Set<AppUser>().Add(appUser);
            _context.SaveChanges();
        }
        public void Remove(AppUser appUser)
        {
            _context.Set<AppUser>().Remove(appUser);
            _context.SaveChanges();
        }
    }
}
