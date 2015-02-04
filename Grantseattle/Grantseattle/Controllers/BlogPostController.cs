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
    public class BlogPostController : Controller
    {
        protected IAgentService AgentService { get; private set; }
        protected IAccountService AccountService { get; private set; }
        protected IBlogCategoryService BlogCategoryService { get; private set; }
        protected IBlogPostService BlogPostService { get; private set; }

        public BlogPostController(IAgentService agentService, IAccountService accountService,
            IBlogCategoryService blogCategoryService, IBlogPostService blogPostService)
        {
            AgentService = agentService;
            AccountService = accountService;
            BlogCategoryService = blogCategoryService;
            BlogPostService = blogPostService;
        }
        //
        // GET: /BlogPost/
        public ActionResult Index()
        {
            var blogList = BlogPostService.GetList();
            return View(blogList);
        }

        //
        // GET: /BlogPost/Details/5
        public ActionResult Details(string id)
        {
            var model = BlogPostService.GetById(id);
            return View(model);
            
        }

        //
        // GET: /BlogPost/Create
        public ActionResult Create(string message ="")
        {
            var category = new SelectList(BlogCategoryService.GetList(), "Id", "Name");
            if (!String.IsNullOrEmpty(message))
            {
                ViewBag.SuccessMessage = message;
            }
            var model = new BlogContent();
            ViewBag.Category = category;
            return View(model);
            
        }

        //
        // POST: /BlogPost/Create
        [HttpPost]
        public ActionResult Create(BlogContent blogContent, string Category = "")
        {
            try
            {
                var category = BlogCategoryService.GetById(Category);
                blogContent.BlogCategory = category;
                var userId = HttpContextHelper.Current.UserId;
                var user = AccountService.GetUserById(userId);
                blogContent.Member = user;
                blogContent.CreatedAt = DateTime.UtcNow;
                blogContent.Status = Propertys.PropertyStatusText.Active;
                //blogContent.BlogCategory.BlogContents.Add(blogContent); 
                BlogPostService.Save(blogContent);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        //
        // GET: /BlogPost/Edit/5
        public ActionResult Edit(string id)
        {
            var model = BlogPostService.GetById(id);
            return View(model);
        }

        //
        // POST: /BlogPost/Edit/5
        [HttpPost]
        public ActionResult Edit(BlogContent blogContent)
        {
            try
            {
                // TODO: Add update logic here
                blogContent.UpdatedAt = DateTime.UtcNow;
                blogContent.Status = Propertys.PropertyStatusText.Active;
                BlogPostService.Save(blogContent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BlogPost/Delete/5
        public ActionResult Delete(string id)
        {
            var model = BlogPostService.GetById(id);
            return View(model);
        }

        //
        // POST: /BlogPost/Delete/5
        [HttpPost]
        public ActionResult Delete(BlogContent blogContent)
        {
            try
            {
                // TODO: Add delete logic here
                blogContent.Status = Propertys.PropertyStatusText.Delete;
                BlogPostService.Delete(blogContent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
