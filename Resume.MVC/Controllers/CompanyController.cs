using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Resume.core;

namespace Resume.MVC.Controllers
{
    public class CompanyController : Controller
    {

        private IConfiguration configuration;
        private string domain;
        public CompanyController(IConfiguration iConfig)
        {            
            configuration = iConfig;
            domain = configuration.GetSection("Domains")["API"].ToString();
        }

      
        // GET: Company
        public ActionResult Index()
        {
            
            IEnumerable<Company> company;
            using(WebClient webClient = new WebClient())
            {
                JsonSerializerOptions JSO = new JsonSerializerOptions();
                JSO.PropertyNameCaseInsensitive = true;
                string str = webClient.DownloadString(domain + "api/company/");
                company = JsonSerializer.Deserialize<IEnumerable<Company>>(str, JSO);
            }
            return View(company);
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<Company> company;
            using (WebClient webClient = new WebClient())
            {
                JsonSerializerOptions JSO = new JsonSerializerOptions();
                JSO.PropertyNameCaseInsensitive = true;
                string str = webClient.DownloadString(domain + "api/company/" + id);
                company = JsonSerializer.Deserialize<IEnumerable<Company>>(str, JSO);
            }
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Company/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}