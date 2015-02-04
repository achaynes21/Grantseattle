using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryERP.Core;
using InventoryERP.Service.Services.Services;
using InventoryERP.Service.Services.Services.Implementations;
using InventoryERP.Services;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        protected INewsPortalService NewsPortalService { get; private set; }
        protected IAccountService AccountService { get; private set; }
        protected IBlogPostService BlogPostService { get; private set; }
        protected IBlogCategoryService BlogCategoryService { get; private set; }
        protected IAgentService AgentService { get; private set; }

        protected IPropertyPurposeService PropertyPurposeService { get; private set; }
        protected IPropertyLocationService PropertyLocationService { get; private set; }
        protected IPropertyTypeService PropertyTypeService { get; private set; }
        protected IPropertyRegistration PropertyRegistration { get; private set; }
        protected IContactUsService ContactUsService { get; private set; }
        public ClientController(
            INewsPortalService newsPortalService, 
            IAccountService accountService, 
            IBlogPostService blogPostService,
            IBlogCategoryService blogCategoryService, 
            IAgentService agentService,
            IPropertyTypeService propertyTypeService,
            IPropertyLocationService propertyLocationService,
            IPropertyPurposeService propertyPurposeService,
            IPropertyRegistration propertyRegistration,
            IContactUsService contactUsService)

        {
            NewsPortalService = newsPortalService;
            AccountService = accountService;
            BlogPostService = blogPostService;
            BlogCategoryService = blogCategoryService;
            AgentService = agentService;
            PropertyTypeService = propertyTypeService;
            PropertyLocationService = propertyLocationService;
            PropertyPurposeService = propertyPurposeService;
            PropertyRegistration = propertyRegistration;
            ContactUsService = contactUsService;
        }
        // GET: Client
        //[AllowAnonymous]
        public ActionResult Index()
        {
            var propertyType = new SelectList(PropertyTypeService.GetList(), "Id", "Name").ToList();
            var agent = new SelectList(AgentService.GetAgentList(), "Id", "FirstName");
            var propertyLocation = new SelectList(PropertyLocationService.GetList(), "Id", "Name");
            var propertyPurpose = new SelectList(PropertyPurposeService.GetList(), "Id", "Name");

            IList<Propertys> pList = PropertyRegistration.GetList();
            ViewBag.PropertyList = pList;
            ViewBag.PROTYPE = propertyType;
            ViewBag.ALLAGENT = agent;
            ViewBag.PROLOCATION = propertyLocation;
            ViewBag.PROPURPOSETYPE = propertyPurpose;

            return View();
        }
        [HttpGet]
        public ActionResult AboutUs()
        {
            return View("Aboutus");
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUsPost(ContactUs contactUs)
        {
            contactUs.CreatedAt = DateTime.UtcNow;
            contactUs.UpdatedAt = DateTime.UtcNow;
            contactUs.Status = Propertys.PropertyStatusText.Active;
            ContactUsService.Save(contactUs);
            ViewBag.SuccessMessage = "Thank You for feedback";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult News()
        {
            var newsList = NewsPortalService.GetNewsList();
            return View(newsList);
            
        }
        [HttpGet]
        public ActionResult Blog()
        {
            var blogList = BlogPostService.GetList();
            ViewBag.category =BlogCategoryService.GetList();
            return View(blogList);
        }
        [HttpGet]
        public ActionResult OurService()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MyFavourite()
        {
            var userId = HttpContextHelper.Current.UserId;
            var user = AccountService.GetUserById(userId);
            ViewBag.PropertyList = user.Propertyses;
            return PartialView("_MyFavourite");
            //return View("Index");
        }
        [HttpPost]
        public ActionResult AddToFavourite(string pId)
        {
            try
            {
                if (!String.IsNullOrEmpty(pId))
                {
                    var list = new List<Propertys>();
                    var property = PropertyRegistration.GetById(pId);
                    var userId = HttpContextHelper.Current.UserId;
                    var user = AccountService.GetUserById(userId);
                    list.Add(property);
                    var ss = property;
                    user.Propertyses.Add(ss); 
                    AccountService.SaveMember(user);
                    //return PartialView("_MyFavourite");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return Json("");
        }
        //[HttpPost]

    }
}
