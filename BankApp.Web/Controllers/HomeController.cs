using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IAppUserRepository _appUserRepository;
        private readonly IAppUserMapper _appUserMapper;
        private readonly IUow _uow;
        public HomeController(IUow uow, IAppUserMapper appUserMapper)
        {
            _uow = uow;
            _appUserMapper = appUserMapper;
        }
        public IActionResult Index()
        {
            var users = _uow.GetRepository<AppUser>().GetAll();
            return View(_appUserMapper.MapToAppUserList(users));
        }
    }
}
