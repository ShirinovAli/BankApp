using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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

        //private readonly IGenericRepository<Account> _accountRepository;
        //private readonly IGenericRepository<AppUser> _appUserRepository;

        //public AccountController(IGenericRepository<Account> accountRepository,
        //                         IGenericRepository<AppUser> appUserRepository)
        //{
        //    _accountRepository = accountRepository;
        //    _appUserRepository = appUserRepository;
        //}

        private readonly IUow _uow;
        public AccountController(IUow uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var userInfo = _uow.GetRepository<AppUser>().GetById(id);
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
            _uow.GetRepository<Account>().Create(new Account
            {
                AccountNumber = model.AccountNumber,
                AppUserId = model.AppUserId,
                Balance = model.Balance
            });
            _uow.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int appUserId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accounts = query.Where(x => x.AppUserId == appUserId).ToList();

            var user = _uow.GetRepository<AppUser>().GetById(appUserId);
            ViewBag.FullName = user.Name + " " + user.Surname;

            var listModel = new List<AccountListModel>();

            foreach (var account in accounts)
            {
                listModel.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    AppUserId = appUserId,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }
            return View(listModel);
        }

        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accounts = query.Where(x => x.Id != accountId).ToList();

            ViewBag.SenderId = accountId;

            var list = new List<AccountListModel>();

            foreach (var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    AppUserId = account.AppUserId,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }
            return View(new SelectList(list, "Id", "AccountNumber"));
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            var senderAccount = _uow.GetRepository<Account>().GetById(model.SenderId);

            senderAccount.Balance -= model.Amount;
            _uow.GetRepository<Account>().Update(senderAccount);

            var account = _uow.GetRepository<Account>().GetById(model.AccountId);
            account.Balance += model.Amount;
            _uow.GetRepository<Account>().Update(account);
            _uow.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
