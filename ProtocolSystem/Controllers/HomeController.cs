using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProtocolSystem.Models;

namespace ProtocolSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }
        [Authorize(Roles = "Citizen")]
        public IActionResult About()
        {
            return View();
        }
    }
}
