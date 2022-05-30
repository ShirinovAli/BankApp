using BankApp.Web.Data.Interfaces;
using BankApp.Web.Mappings;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IAppUserMapper _appUserMapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMapper _accountMapper;
        public AccountController(IAppUserRepository appUserRepository, IAppUserMapper appUserMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        {
            _appUserRepository = appUserRepository;
            _appUserMapper = appUserMapper;
            _accountRepository = accountRepository;
            _accountMapper = accountMapper;
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var userInfo = _appUserRepository.GetById(id);
            return View(_appUserMapper.MapToAppUser(userInfo));
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _accountRepository.Create(_accountMapper.MapToAccount(model));
            return RedirectToAction("Index", "Home");
        }
    }
}
