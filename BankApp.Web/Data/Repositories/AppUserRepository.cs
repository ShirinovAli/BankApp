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
        public List<AppUser> GetAllUsers()
        {
            return _context.AppUsers.ToList();
        }
        public AppUser GetById(int id)
        {
            return _context.AppUsers.SingleOrDefault(x => x.Id == id);
        }
        public void Create(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
            _context.SaveChanges();
        }
    }
}
