using BankApp.Web.Data.Entities;
using BankApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Web.Mappings
{
    public class AppUserMapper :IAppUserMapper
    {
        public List<AppUserModel> MapToAppUserList(List<AppUser> users)
        {
            return users.Select(x => new AppUserModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Name
            }).ToList();
        }

        public AppUserModel MapToAppUser(AppUser user)
        {
            return new AppUserModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}
