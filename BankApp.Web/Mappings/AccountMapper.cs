using BankApp.Web.Data.Entities;
using BankApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web.Mappings
{
    public class AccountMapper : IAccountMapper
    {
        public Account MapToAccount(AccountCreateModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                AppUserId = model.AppUserId,
                Balance = model.Balance,
            };
        }
    }
}
