using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IAppUserMapper _appUserMapper;
        public HomeController(IAppUserRepository appUserRepository, IAppUserMapper appUserMapper)
        {
            _appUserRepository = appUserRepository;
            _appUserMapper = appUserMapper;
        }
        public IActionResult Index()
        {
            var users = _appUserRepository.GetAllUsers();
            return View(_appUserMapper.MapToAppUserList(users));
        }
    }
}
