using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resume.MVC.Models;
using Microsoft.Extensions.Configuration;
using Resume.core;
using Resume.data;
namespace Resume.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            configuration = iConfig;
        }

        ResumeViewModel Model;

        public IActionResult Index()
        {           
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            string domain = configuration.GetSection("Domains")["API"].ToString();
            Model = new ResumeViewModel(domain, 1);
            return View(Model);
        }

        public IActionResult Privacy()
        {
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
