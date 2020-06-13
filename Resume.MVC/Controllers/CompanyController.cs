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
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
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
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Company company;
            using (WebClient webClient = new WebClient())
            {
                JsonSerializerOptions JSO = new JsonSerializerOptions();
                JSO.PropertyNameCaseInsensitive = true;
                string str = webClient.DownloadString(domain + "api/company/" + id);
                company = JsonSerializer.Deserialize<Company>(str, JSO);
            }
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
               using (WebClient webClient = new WebClient())
                {
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    JsonSerializerOptions JSO = new JsonSerializerOptions();
                    JSO.PropertyNameCaseInsensitive = true;
                    webClient.UploadString(domain + "api/company/", "Post", JsonSerializer.Serialize<Company>(company));

                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                string thisEx = ex.ToString();
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Company company;
            using (WebClient webClient = new WebClient())
            {
                JsonSerializerOptions JSO = new JsonSerializerOptions();
                JSO.PropertyNameCaseInsensitive = true;
                string str = webClient.DownloadString(domain + "api/company/" + id);
                company = JsonSerializer.Deserialize<Company>(str, JSO);
            }
            return View(company);
        
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Company company)
        {
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    JsonSerializerOptions JSO = new JsonSerializerOptions();
                    JSO.PropertyNameCaseInsensitive = true;
                    webClient.UploadString(domain + "api/company/" + company.ID, "Put", JsonSerializer.Serialize<Company>(company));

                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                string thisEx = ex.ToString();
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Company company;
            using (WebClient webClient = new WebClient())
            {
                JsonSerializerOptions JSO = new JsonSerializerOptions();
                JSO.PropertyNameCaseInsensitive = true;
                string str = webClient.DownloadString(domain + "api/company/" + id);
                company = JsonSerializer.Deserialize<Company>(str, JSO);
            }
            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Company company)
        {
            ViewData["IP"] = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                // TODO: Add delete logic here
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    JsonSerializerOptions JSO = new JsonSerializerOptions();
                    JSO.PropertyNameCaseInsensitive = true;
                    webClient.UploadString(domain + "api/company/" + company.ID, "Delete", JsonSerializer.Serialize<Company>(company));

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}