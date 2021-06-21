using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using FirewallRuleManagement.Models;

namespace FirewallRuleManagement.Controllers
{
    public class CredsController : Controller
    {
       
        // GET: CredsController/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: CredsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Creds creds)
        {
            if (creds.Password == null)
                creds.Password = "";
            SSH ssh = new SSH(creds.IpAddress, creds.Username, creds.Password);
            if(ssh.IsConnected())
            {
                HttpContext.Session.SetString("host",creds.IpAddress);
                HttpContext.Session.SetString("user",creds.Username);
                HttpContext.Session.SetString("pass",creds.Password);
                return RedirectToAction("Index", "Filter");
            }
            else
            {
                return View(nameof(Login));
            }
        }

       
    }
}
