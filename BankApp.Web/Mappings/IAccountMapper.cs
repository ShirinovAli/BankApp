using BankApp.Web.Data.Entities;
using BankApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web.Mappings
{
    public interface IAccountMapper
    {
        public Account MapToAccount(AccountCreateModel model);
    }
}
