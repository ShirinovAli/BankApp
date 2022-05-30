using BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _context;
        public AccountController(BankContext context)
        {
            _context = context;
        }
        public IActionResult Create(int id)
        {
            var userInfo = _context.AppUsers.SingleOrDefault(x => x.Id == id);
            return View(userInfo);
        }
    }
}
