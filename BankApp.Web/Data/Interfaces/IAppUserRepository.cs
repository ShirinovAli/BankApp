using BankApp.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web.Data.Interfaces
{
    public interface IAppUserRepository
    {
        public List<AppUser> GetAllUsers();
        public AppUser GetById(int id);
        public void Create(AppUser appUser);
    }
}
