using BankApp.Web.Data.Entities;
using BankApp.Web.Models;
using System.Collections.Generic;

namespace BankApp.Web.Mappings
{
    public interface IAppUserMapper
    {
        public List<AppUserModel> MapToAppUserList(List<AppUser> users);
        public AppUserModel MapToAppUser(AppUser user);
    }
}
