using FirewallRuleManagement.Helpers;
using FirewallRuleManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirewallRuleManagement.Controllers
{
    public class FilterController : Controller
    {
       
        // GET: FilterController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("host") == null)
                return RedirectToAction("Login", "Creds");
            SSH ssh = new SSH(HttpContext.Session.GetString("host"), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"));
            if (ssh.IsConnected())
            {
                string result = ssh.PrintFilter();
                List<Filter> filters = new FilterHelper().GetFilters(result);
                return View(filters);
            }
            else
            {
                return RedirectToAction("Login", "Creds");
            }
        }

        // GET: FilterController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("host") == null)
                return RedirectToAction("Login", "Creds");
            SSH ssh = new SSH(HttpContext.Session.GetString("host"), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"));
            if (ssh.IsConnected())
            {
                string result = ssh.PrintFilter();
                List<Filter> filters = new FilterHelper().GetFilters(result);
                return View(filters[id]);
            }
            else
            {
                return RedirectToAction("Login", "Creds");
            }
        }
        // GET: FilterController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("host") == null)
                return RedirectToAction("Login", "Creds");
            SSH ssh = new SSH(HttpContext.Session.GetString("host"), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"));
            if (ssh.IsConnected())
            {
                string result = ssh.PrintInterfaces();
                Filter filter = new Filter();
                filter.InterfaceItems =new FilterHelper().GetNames(result);
                return View(filter);
            }
            else
            {
                return RedirectToAction("Login", "Creds");
            }
        }

        // POST: FilterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < collection.Count; i++)
            {
                string key = collection.Keys.ElementAt(i);
                if (key == "Disabled")
                {
                    dict[key] = collection[key].ToString().Split(',')[0];
                }
                else
                {
                    dict[key] = collection[key];
                }
            }
            Filter filter = JsonConvert.DeserializeObject<Filter>(JsonConvert.SerializeObject(dict));
            try
            {
                if (HttpContext.Session.GetString("host") == null)
                    return RedirectToAction("Login", "Creds");
                SSH ssh = new SSH(HttpContext.Session.GetString("host"), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"));
                if (ssh.IsConnected())
                {
                    FilterCommand command = new FilterCommand().BaseCommand().Add()
                        .AddChain(filter.Chain).AddAction(filter.Action).AddComment(filter.Comment)
                        .AddSrcAddress(filter.SrcAddress).AddDstAddress(filter.DstAddress)
                        .AddProtocol(filter.Protocol).AddSrcPort(filter.SrcPort).AddDstPort(filter.DstPort)
                        .AddInInterface(filter.InInterface).AddOutInterface(filter.OutInterface)
                        .AddSrcAddressList(filter.SrcAddressList).AddDstAddressList(filter.DstAddressList)
                        .AddLimit(filter.Limit).SetDisabled(filter.Disabled.ToString());
                    ssh.FilterRule(command);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Login", "Creds");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: FilterController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("host") == null)
                return RedirectToAction("Login", "Creds");
            SSH ssh = new SSH(HttpContext.Session.GetString("host"), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"));
            if (ssh.IsConnected())
            {
                string result = ssh.PrintFilter();
                List<Filter> filters = new FilterHelper().GetFilters(result);
                result = ssh.PrintInterfaces();
                filters[id].InterfaceItems = new FilterHelper().GetNames(result);
                return View(filters[id]);
            }
            else
            {
                return RedirectToAction("Login", "Creds");
            }
        }

        // POST: FilterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for(int i = 0; i < collection.Count; i++)
            {
                string key = collection.Keys.ElementAt(i);
                if (key == "Disabled")
                {
                    dict[key] =collection[key].ToString().Split(',')[0];
                }
                else
                {
                    dict[key] = collection[key];
                }
            }
            Filter filter = JsonConvert.DeserializeObject<Filter>(JsonConvert.SerializeObject(dict));
            try
            {
                if (HttpContext.Session.GetString("host") == null)
                    return RedirectToAction("Login", "Creds");
                SSH ssh = new SSH(HttpContext.Session.GetString("host"), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"));
                if (ssh.IsConnected())
                {
                    FilterCommand command =new FilterCommand().BaseCommand().Update(id)
                        .AddChain(filter.Chain ).AddAction(filter.Action ).AddComment(filter.Comment )
                        .AddSrcAddress(filter.SrcAddress ).AddDstAddress(filter.DstAddress )
                        .AddProtocol(filter.Protocol ).AddSrcPort(filter.SrcPort ).AddDstPort(filter.DstPort )
                        .AddInInterface(filter.InInterface ).AddOutInterface(filter.OutInterface )
                        .AddSrcAddressList(filter.SrcAddressList).AddDstAddressList(filter.DstAddressList)
                        .AddLimit(filter.Limit ).SetDisabled(filter.Disabled.ToString());
                    ssh.FilterRule(command);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Login", "Creds");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: FilterController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("host") == null)
                return RedirectToAction("Login", "Creds");
            SSH ssh = new SSH(HttpContext.Session.GetString("host"), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"));
            if (ssh.IsConnected())
            {
                string result = ssh.PrintFilter();
                List<Filter> filters = new FilterHelper().GetFilters(result);
                return View(filters[id]);
            }
            else
            {
                return RedirectToAction("Login", "Creds");
            }
        }

        // POST: FilterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            id =int.Parse( collection["id"]);
            try
            {
                if (HttpContext.Session.GetString("host") == null)
                    return RedirectToAction("Login", "Creds");
                SSH ssh = new SSH(HttpContext.Session.GetString("host"), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"));
                if (ssh.IsConnected())
                {
                    FilterCommand command = new FilterCommand().BaseCommand().Remove(id);
                    string result = ssh.FilterRule(command);
                    Console.WriteLine(result);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Login", "Creds");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
