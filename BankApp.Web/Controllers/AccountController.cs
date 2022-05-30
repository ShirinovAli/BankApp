using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Mappings;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IAppUserRepository _appUserRepository;
        //private readonly IAppUserMapper _appUserMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;
        //public AccountController(IAppUserRepository appUserRepository, IAppUserMapper appUserMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        //{
        //    _appUserRepository = appUserRepository;
        //    _appUserMapper = appUserMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}

        private readonly IGenericRepository<Account> _accountRepository;
        private readonly IGenericRepository<AppUser> _appUserRepository;

        public AccountController(IGenericRepository<Account> accountRepository,
                                 IGenericRepository<AppUser> appUserRepository)
        {
            _accountRepository = accountRepository;
            _appUserRepository = appUserRepository;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var userInfo = _appUserRepository.GetById(id);
            return View(new AppUserModel
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _accountRepository.Create(new Account
            {
                AccountNumber = model.AccountNumber,
                AppUserId = model.AppUserId,
                Balance = model.Balance
            });
            return RedirectToAction("Index", "Home");
        }
    }
}
