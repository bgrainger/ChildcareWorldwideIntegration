﻿using System.Diagnostics;
using System.Threading.Tasks;
using ChildcareWorldwide.Denari.Api;
using ChildcareWorldwide.Integration.Manager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChildcareWorldwide.Integration.Manager.Controllers
{
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> m_logger;

        public HomeController(ILogger<HomeController> logger)
        {
            m_logger = logger;
        }

        public IActionResult Index()
        {
            return View(GetPageViewModel(pageTitle: "Integration Dashboard", HttpContext.User));
        }

        [HttpGet("/Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
