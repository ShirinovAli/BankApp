using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _context;
        public AccountRepository(BankContext context)
        {
            _context = context;
        }
        public void Create(AppUser appUser)
        {
            _context.AppUsers.Add(appUser);
            _context.SaveChanges();
        }
    }
}
