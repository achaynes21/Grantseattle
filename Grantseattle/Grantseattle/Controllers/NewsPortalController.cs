using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryERP.Core;
using InventoryERP.ModelBuilders;
using InventoryERP.Models;
using InventoryERP.Service.Services.Services;
using InventoryERP.Services;
using InventoryERP.Services.Implementations;
using InventoryERP.Web.ModelBuilders;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Controllers
{
    [Authorize]
    public class NewsPortalController : Controller
    {
        //
        // GET: /NewsPortal/
        protected INewsPortalService NewsPortalService { get; private set; }
        protected IAccountService AccountService { get; private set; }

        public NewsPortalController(INewsPortalService newsPortalService, IAccountService accountService)
        {
            NewsPortalService = newsPortalService;
            AccountService = accountService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PublishNews()
        {
            var model = new EditNewsPortal();
            return View(model);
        }
        public static string GetFilePath(string fileNamePart, string fileName)
        {
            string filePath = "";
            try
            {
                filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/" + fileName);
            }
            catch (Exception ex) { }

            return filePath;
        }
        [HttpPost]
        public ActionResult PublishNews(EditNewsPortal model)
        {
            try
            {
                var validImageTypes = new string[]
                {
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
                if (model.UploadImage == null || model.UploadImage.ContentLength == 0)
                {
                    ModelState.AddModelError("ImageUrl", "This field is required");
                }
                else if (!validImageTypes.Contains(model.UploadImage.ContentType))
                {
                    ModelState.AddModelError("ImageUrl", "Please choose either a GIF, JPG or PNG image.");
                }
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                if (model.UploadImage != null && model.UploadImage.ContentLength > 0)
                {
                    var fileName = model.UploadImage.FileName;
                    var dir = new DirectoryInfo(GetFilePath("GrantSeattle", ""));
                    var fileInfo = new FileInfo(dir.ToString() + fileName);
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }
                    model.UploadImage.SaveAs(dir.ToString() + fileName);
                    model.ImageUrl = dir.ToString() + fileName;
                    
                }
                var userId = HttpContextHelper.Current.UserId;
                NewsEditModelBuilder.Save(NewsPortalService, model, AccountService, userId);
                return RedirectToAction("NewsList");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [HttpGet]
        public ActionResult NewsList()
        {
            var newsList = NewsPortalService.GetNewsList();
            return View(newsList);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var model = NewsPortalService.GetNewsById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(News newModelObj)
        {
            var oldModelObj = NewsPortalService.GetNewsById(newModelObj.Id);
            oldModelObj.Heading = newModelObj.Heading;
            oldModelObj.Source = newModelObj.Source;
            oldModelObj.NewsDescription = newModelObj.NewsDescription;
            oldModelObj.UpdatedAt = DateTime.UtcNow;
            NewsPortalService.Save(oldModelObj);
            ViewBag.SuccessMessage = "Update Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var model = NewsPortalService.GetNewsById(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var model = NewsPortalService.GetNewsById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(News news)
        {
            NewsPortalService.Delete(news);
            return RedirectToAction("NewsList", "NewsPortal");
        }
    }
}