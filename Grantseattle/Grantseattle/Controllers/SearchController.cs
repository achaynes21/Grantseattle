using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryERP.Models;
using InventoryERP.Service.Services.Services;
using InventoryERP.Services;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Controllers
{
    public class SearchController : Controller
    {
         protected IAccountService AccountService { get; private set; }
        protected IPropertyPurposeService PropertyPurposeService { get; private set; }
        protected IPropertyLocationService PropertyLocationService { get; private set; }
        protected IPropertyTypeService PropertyTypeService { get; private set; }
        protected IPropertyRegistration PropertyRegistrationService { get; private set; }
        protected IAgentService AgentService { get; private set; }
        protected IPropertyDeteilsSevice PropertyDeteilsSevice { get; private set; }
        List<string> array = new List<String>();
        PropertyImages propertyImages;
        PropertyModelView sPropertyModelView;
        PropertyDetailsModelView propertyDetailsModelView;

        public SearchController(IPropertyPurposeService propertyPurposeService,
            IPropertyLocationService propertyLocationService, IAccountService accountService,
            IPropertyTypeService propertyTypeService, IAgentService agentService,
            IPropertyRegistration propertyRegistrationService, IPropertyDeteilsSevice propertyDeteilsSevice)
        {
            PropertyPurposeService = propertyPurposeService;
            PropertyLocationService = propertyLocationService;
            AccountService = accountService;
            PropertyTypeService = propertyTypeService;
            AgentService = agentService;
            PropertyRegistrationService = propertyRegistrationService;
            PropertyDeteilsSevice = propertyDeteilsSevice;
        }
        public ActionResult RentPropertySearch(string cityName="", string location="", string propType="",
            string bed="", string minPrice="", string maxPrice="", string generalSearch="")
        {
            var propertyList = PropertyRegistrationService.GetPropertyBySearchingCriter(cityName, location, propType, bed, minPrice, maxPrice, generalSearch);
            ViewBag.PropertyList = propertyList;
            return PartialView("_SearchResult");
        }
        public ActionResult PropertySearch(string cityName="", string location="", string propType="",
            string agentName="", string generalSearch="")
        {
            var propertyList = PropertyRegistrationService.GetPropertyBySearchingCriteriaAgent(cityName, location, propType, agentName, generalSearch);
            ViewBag.PropertyList = propertyList;
            return PartialView("_SearchResult");
        }
        //
        // GET: /Search/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Search/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Search/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Search/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Search/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
