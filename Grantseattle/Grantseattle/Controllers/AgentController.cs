using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryERP.Service.Services.Services;
using InventoryERP.Services;
using InventoryERP.Web.Controllers;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {

        protected IAgentService AgentService { get; private set; }
        protected IAccountService AccountService { get; private set; }

        public AgentController(IAgentService agentService, IAccountService accountService)
        {
            AgentService = agentService;
            AccountService = accountService;
        }

        // GET: Agent
        public ActionResult Index()
        {
            var model = new Agent();
            return View(model);
        }

        // GET: Agent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        // GET: Agent/Create
        public ActionResult Create()
        {
            var model = new Agent();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Agent agentObj, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    if (Request.Files.Count > 0)
                    {
                        if (file.ContentLength > 0)
                        {
                            var validImageType = new string[] { ".png", ".PNG", ".jpg", ".JPG", ".bmp", ".BMP", ".jpeg", ".JPEG", ".gif", ".GIF" };
                            string defaultFileUrl = System.Web.Hosting.HostingEnvironment.MapPath("/Images/Agent/");

                            foreach (string vit in validImageType)
                            {
                                if (file.FileName.EndsWith(vit))
                                {
                                    var fileName = file.FileName;
                                    string filePath = defaultFileUrl + fileName;
                                    var fileInfo = new FileInfo(filePath);
                                    if (fileInfo.Exists)
                                    {
                                        filePath = defaultFileUrl + Guid.NewGuid().ToString().Substring(0, 10) + fileName;
                                        file.SaveAs(filePath);
                                    }
                                    else
                                    {
                                        file.SaveAs(filePath);
                                    }
                                    agentObj.ImageUrl = filePath;
                                    agentObj.UpdatedAt = DateTime.UtcNow;
                                    agentObj.CreatedAt = DateTime.UtcNow;
                                    agentObj.Status = Propertys.PropertyStatusText.Active;
                                    AgentService.Save(agentObj);
                                    //ViewBag.SuccessMessage = "Agent SuccessFully Added";
                                    return RedirectToAction("AgentList");
                                    //return View();
                                }
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Invalid Agent Pic";
                            return View();
                        }
                    }
                }
                ViewBag.ErrorMessage = "Please Select Agent Pic";
                return View();
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Invalid Agent Pic";
                return View();
            }
        }

        public ActionResult AgentList()
        {
            var model = AgentService.GetAgentList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(string id)
        {
            var model = AgentService.GetAgentById(id);
            return View(model);
        }
        // GET: Agent/Delete/5
        public ActionResult Delete(string id)
        {
            var model = AgentService.GetAgentById(id);
            return View(model);
        }

        // POST: Agent/Delete/5
        [HttpPost]
        public ActionResult Delete(Agent agent)
        {
            try
            {
                // TODO: Add delete logic here

                AgentService.Delete(agent);
                return RedirectToAction("AgentList", "Agent");
            }
            catch
            {
                return View();
            }
        }

        // POST: Agent/Create
        // GET: Agent/Edit/5
        public ActionResult Edit(string id)
        {
            var agent = AgentService.GetAgentById(id);
            return View(agent);
        }

        // POST: Agent/Edit/5
        [HttpPost]
        public ActionResult Edit(Agent newModelObj)
        {
            try
            {
                // TODO: Add update logic here
                var oldModelObj = AgentService.GetAgentById(newModelObj.Id);
                oldModelObj.LastName = newModelObj.LastName;
                oldModelObj.FirstName = newModelObj.FirstName;
                oldModelObj.Email = newModelObj.Email;
                oldModelObj.Address1 = newModelObj.Address1;
                oldModelObj.Address2 = newModelObj.Address2;
                oldModelObj.ContactNo = newModelObj.ContactNo;
                oldModelObj.Remarks = newModelObj.Remarks;
                oldModelObj.UpdatedAt = DateTime.UtcNow;
                AgentService.Save(oldModelObj);
                ViewBag.SuccessMessage = "Update Successfully";
                return View();
            }
            catch
            {
                return View();
            }
        }

       
    }
}
