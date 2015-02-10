using InventoryERP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RGD.CatalogMSB.WebUI.ControllersApi
{
    public class ImagenesController : Controller
    {

        [HttpPost]
        public async Task<JsonResult> PostUpload(HttpPostedFileBase image, string imageType)
        {
            byte[] content = new byte[image.ContentLength];
            await image.InputStream.ReadAsync(content, 0, image.ContentLength);
            if (string.IsNullOrWhiteSpace(imageType))
                imageType = "unknow";
            var fileName = image.FileName;
            var filePath = HttpContext.Server.MapPath("/Images/Upload/" + imageType + "/" + fileName);
            if (System.IO.File.Exists(filePath))
                throw new InvalidOperationException("File previously exists...!");

            var stream = System.IO.File.Create(filePath);
            await stream.WriteAsync(content, 0, content.Length);

            return Json(new Imagen()
            {
                FileName = fileName,
                ImageType = imageType
            });
        }

        public FileResult Image(string id, string type)
        {
            var filePath = HttpContext.Server.MapPath("~/Images/Upload/" + type + "/" + id);
            if (!System.IO.File.Exists(filePath))
                throw new FileNotFoundException("File not found", id);

            return File(filePath, null);
        }

        public JsonResult ImageTypes(string type)
        {
            var folderPath = HttpContext.Server.MapPath("~/Images/Upload/" + type);
            FileInfo info = new FileInfo(folderPath);
            IList<TinymceObject> list = new List<TinymceObject>();
            if (info.Exists)
            {
                var files = info.Directory.EnumerateFiles();
                foreach (var file in files)
                {
                    list.Add(new TinymceObject()
                    {
                        title = file.Name,
                        value = file.Name
                    });
                }
            }
            return Json(list);
        }
    }

    internal class TinymceObject
    {
        public string title { get; set; }
        public string value { get; set; }
    }
}
