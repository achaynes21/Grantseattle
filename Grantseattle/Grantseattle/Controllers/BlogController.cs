using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryERP.Service.Services.Services;
using InventoryERP.Services;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {

        protected IAgentService AgentService { get; private set; }
        protected IAccountService AccountService { get; private set; }
        protected IBlogCategoryService BlogCategoryService { get; private set; }
        protected IBlogPostService BlogPostService { get; private set; }
        public BlogController(IAgentService agentService, IAccountService accountService,
            IBlogCategoryService blogCategoryService, IBlogPostService blogPostService)
        {
            AgentService = agentService;
            AccountService = accountService;
            BlogCategoryService = blogCategoryService;
            BlogPostService = blogPostService;
        }

        // GET: Blog
        public ActionResult Index()
        {
            var blogList = BlogCategoryService.GetList();
            return View(blogList);

        }

        // GET: Blog/Details/5
        public ActionResult Details(string id)
        {
            var model = BlogCategoryService.GetById(id);
            return View(model);
        }

        // GET: Blog/Create
        public ActionResult Create(string message = "")
        {
            if (!String.IsNullOrEmpty(message))
            {
                ViewBag.SuccessMessage = "Blog Category Added";
            }
            var model = new BlogCategory();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BlogCategory category)
        {
            try
            {
                category.CreatedAt = DateTime.UtcNow;
                category.Status = Propertys.PropertyStatusText.Active;
                BlogCategoryService.Save(category);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
        // GET: Blog/Edit/5
        public ActionResult Edit(string id)
        {
            var model = BlogCategoryService.GetById(id);
            return View(model);

        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(BlogCategory category)
        {
            try
            {
                // TODO: Add update logic here
                category.UpdatedAt = DateTime.UtcNow;
                category.Status = Propertys.PropertyStatusText.Active;
                BlogCategoryService.Save(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var model = BlogCategoryService.GetById(id);
            return View(model);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(BlogCategory category)
        {
            try
            {
                // TODO: Add delete logic here
                category.Status = Propertys.PropertyStatusText.Delete;
                BlogCategoryService.Delete(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
