using BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankContext _context;
        public HomeController(BankContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.AppUsers.ToList();
            return View(users);
        }
    }
}
