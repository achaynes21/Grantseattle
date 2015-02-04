using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryERP.Models;
using InventoryERP.Service.Services.Services;
using InventoryERP.Service.Services.Services.Implementations;
using InventoryERP.Services;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Controllers
{
    [Authorize]
    public class PropertyListingController : Controller
    {
        //
        // GET: /PropertyListing/
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
       
        public PropertyListingController(IPropertyPurposeService propertyPurposeService,
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
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult MakePropertyPurpose()
        {
            var propertyPurposeRent = new PropertyPurpose();
            propertyPurposeRent.Name = "Rent";
            propertyPurposeRent.ProPurpose = PropertyPurpose.PropertyPurposeText.Rent;
            propertyPurposeRent.CreatedAt = DateTime.UtcNow;
            propertyPurposeRent.UpdatedAt = DateTime.UtcNow;
            propertyPurposeRent.Status = Propertys.PropertyStatusText.Active;

            var propertyPurposeSell = new PropertyPurpose();
            propertyPurposeSell.Name = "Sell";
            propertyPurposeSell.ProPurpose = PropertyPurpose.PropertyPurposeText.Sell;
            propertyPurposeSell.CreatedAt = DateTime.Now;
            propertyPurposeSell.UpdatedAt = DateTime.Now;
            propertyPurposeSell.Status = Propertys.PropertyStatusText.Active;

            IList<PropertyPurpose> propertyPurposes = new List<PropertyPurpose>();
            propertyPurposes.Add(propertyPurposeRent);
            propertyPurposes.Add(propertyPurposeSell);

            PropertyPurposeService.SavePropertyPurpose(propertyPurposes);
            return RedirectToAction("Index", new { message = "Internal Operation " });
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult MakePropertyLocation()
        {
            var propertyLocationCommercial = new PropertyLocationType();
            propertyLocationCommercial.Name = "Commercial";
            propertyLocationCommercial.ProLocationType = PropertyLocationType.PropertyLocationText.Commercial;
            propertyLocationCommercial.CreatedAt = DateTime.UtcNow;
            propertyLocationCommercial.UpdatedAt = DateTime.UtcNow;
            propertyLocationCommercial.Status = Propertys.PropertyStatusText.Active;

            var propertyLocationResidential = new PropertyLocationType();
            propertyLocationResidential.Name = "Residential";
            propertyLocationResidential.ProLocationType = PropertyLocationType.PropertyLocationText.Residential;
            propertyLocationResidential.CreatedAt = DateTime.UtcNow;
            propertyLocationResidential.UpdatedAt = DateTime.UtcNow;
            propertyLocationResidential.Status = Propertys.PropertyStatusText.Active;

            var propertyLocationFarm = new PropertyLocationType();
            propertyLocationFarm.Name = "Rural";
            propertyLocationFarm.ProLocationType = PropertyLocationType.PropertyLocationText.Rural;
            propertyLocationFarm.CreatedAt = DateTime.UtcNow;
            propertyLocationFarm.UpdatedAt = DateTime.UtcNow;
            propertyLocationFarm.Status = Propertys.PropertyStatusText.Active;

            IList<PropertyLocationType> locationTypes = new List<PropertyLocationType>();
            locationTypes.Add(propertyLocationCommercial);
            locationTypes.Add(propertyLocationResidential);
            locationTypes.Add(propertyLocationFarm);

            PropertyLocationService.SavePropertyLocation(locationTypes);
            return RedirectToAction("Index", new { message = "Internal Operation " });
        }

        [HttpGet]
        public ActionResult CreatePropertyType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePropertyType(PropertyType propertyTypeObj)
        {
            try
            {
                if (propertyTypeObj.Name != null)
                {
                    propertyTypeObj.CreatedAt = DateTime.UtcNow;
                    propertyTypeObj.UpdatedAt = DateTime.UtcNow;
                    propertyTypeObj.Status = Propertys.PropertyStatusText.Active;
                    PropertyTypeService.Save(propertyTypeObj);
                    ViewBag.SuccessMessage = "Property Type SuccessFully Added";
                    return View();
                }
                ViewBag.ErrorMessage = "Please add a valid Property Type";
                return View();
            }
            catch
            {
                ViewBag.ErrorMessage = "Please add a valid Property Type";
                return View();
            }
        }
        public ActionResult PropertyTypeList()
        {
            var model = PropertyTypeService.GetList();
            return View(model);
        }

        [HttpGet]
        public ActionResult PropertyTypeDetails(string id)
        {
            var model = PropertyTypeService.GetById(id);
            return View(model);
        }
        // GET: Agent/Delete/5
        public ActionResult PropertyTypeDelete(string id)
        {
            var model = PropertyTypeService.GetById(id);
            return View(model);
        }

        public ActionResult PropertyTypeEdit(string id)
        {
            var model = PropertyTypeService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult PropertyTypeEdit(PropertyType newModelObj)
        {
            var oldModelObj = PropertyTypeService.GetById(newModelObj.Id);
            oldModelObj.Name = newModelObj.Name;
            oldModelObj.Description = newModelObj.Description;
            oldModelObj.UpdatedAt = DateTime.UtcNow;
            PropertyTypeService.Save(oldModelObj);
            ViewBag.SuccessMessage = "Update Successfully";
            return View();
        }
        // POST: Agent/Delete/5
        [HttpPost]
        public ActionResult PropertyTypeDelete(PropertyType agentPropertyType)
        {
            try
            {
                // TODO: Add delete logic here

                PropertyTypeService.Delete(agentPropertyType);
                return RedirectToAction("PropertyTypeList", "PropertyListing");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult PropertyRegistration()
        {
            try
            {
                var propertyType = new SelectList(PropertyTypeService.GetList(), "Id", "Name");
                var agent = new SelectList(AgentService.GetAgentList(), "Id", "FirstName");
                var propertyLocation = new SelectList(PropertyLocationService.GetList(), "Id", "Name");
                var propertyPurpose = new SelectList(PropertyPurposeService.GetList(), "Id", "Name");
                ViewBag.PROTYPE = propertyType;
                ViewBag.ALLAGENT = agent;
                ViewBag.PROLOCATION = propertyLocation;
                ViewBag.PROPURPOSETYPE = propertyPurpose;
                return View();
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        [HttpPost]
        public ActionResult PropertyRegistration(PropertyModelView propertyModelView, string PROTYPE = "",
            string ALLAGENT = "", string PROLOCATION = "", string PROPURPOSETYPE = "")
        {
            PropertyType propertyType = PropertyTypeService.GetById(PROTYPE);
            Agent agent = AgentService.GetAgentById(ALLAGENT);
            PropertyLocationType propertyLocationType = PropertyLocationService.GetById(PROLOCATION);
            PropertyPurpose propertyPurpose = PropertyPurposeService.GetById(PROPURPOSETYPE);
            //Agent agent = null;
            propertyModelView.PropertyType = propertyType;
            propertyModelView.Agent = agent;
            propertyModelView.PropertyLocationType = propertyLocationType;
            propertyModelView.PropertyPurposeType = propertyPurpose;

            PropertyModelView sPropertyModelView = propertyModelView;
            Session["propertyModelView"] = sPropertyModelView;
            TempData["propertyModelView"] = sPropertyModelView;
            return View("PropertyDetailsModelView");
        }
        [HttpPost]
        public ActionResult GetPropertyModelView(PropertyDetailsModelView propertyDetailsModelView)
        {
            Session["propertyDetailsModelView"] = propertyDetailsModelView;
            TempData["propertyDetailsModelView"] = propertyDetailsModelView;
            return View("PropertyImagesModelView");
        }
        public string Thumbnail(int width, int height, string fileName, string filePath)
        {
            var thumbImageFile = Path.Combine(Server.MapPath("~/Images/Thumb"), fileName);
            //thumbImageFile += ".png";
            using (var srcImage = Image.FromFile(filePath))
            using (var newImage = new Bitmap(width, height))
            using (var graphics = Graphics.FromImage(newImage))
            using (var stream = new MemoryStream())
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(srcImage, new Rectangle(0, 0, width, height));
                newImage.Save(stream, ImageFormat.Png);
                newImage.Save(thumbImageFile, ImageFormat.Png);
                return thumbImageFile;
            }
        }
        [HttpPost]
        public ActionResult FinallyPropertySave(HttpPostedFileBase file,
            PropertyImagesModelView propertyImagesModelView)
        {
            string thumbImageFile = "";
            //file = propertyImagesModelView.ImgFile;
            if (file != null && file.ContentLength > 0)
            {
                var validImageType = new string[] { ".png", ".PNG", ".jpg", ".JPG", ".bmp", ".BMP", ".jpeg", ".JPEG", ".gif", ".GIF" };
                //string defaultFileUrl = System.Web.Hosting.HostingEnvironment.MapPath("~/ImageUpload/");
                string defaultFileUrl = System.IO.Path.GetFileName(file.FileName);
                foreach (string vit in validImageType)
                {
                    if (file.FileName.EndsWith(vit))
                    {
                        var fileName = DateTime.Now.DayOfYear + file.FileName;
                        string filePath = System.IO.Path.Combine(
                                   Server.MapPath("/Images/PropertyImages/"), defaultFileUrl);
                        //array.Add(filePath);
                        var fileInfo = new FileInfo(filePath);
                        if (fileInfo.Exists)
                        {
                            filePath = System.IO.Path.Combine(
                                   Server.MapPath("/Images/PropertyImages"), Guid.NewGuid().ToString().Substring(0, 10) + defaultFileUrl);
                            file.SaveAs(filePath);
                            thumbImageFile = Thumbnail(100, 100, fileName, filePath);
                            array.Add(filePath);
                            break;
                        }
                        file.SaveAs(filePath);
                        thumbImageFile = Thumbnail(120, 80, fileName, filePath);
                        array.Add(filePath);
                        break;
                    }
                }

            }
            sPropertyModelView = (PropertyModelView)Session["propertyModelView"];
            //vendorModelView = (VendorModelView)Session["vendorModelView"];
            propertyDetailsModelView = (PropertyDetailsModelView)Session["propertyDetailsModelView"];
            IList<Propertys> propertiesList = new List<Propertys>();

            var propertyDetails = new PropertyDetails();
            var propertys = new Propertys();

            bool isPropertyExits = PropertyRegistrationService.IsPropertyExits(sPropertyModelView.Title, sPropertyModelView.Price);
            if (isPropertyExits == false)
            {
                //property table
                propertys.Agent = sPropertyModelView.Agent;
                propertys.PropertyType = sPropertyModelView.PropertyType;
                propertys.PropertyLocationType = sPropertyModelView.PropertyLocationType;
                propertys.PropertyPurpose = sPropertyModelView.PropertyPurposeType;
                //propertys.PropertyDetails = propertyDetails; //presave
                propertys.CreatedAt = DateTime.UtcNow;
                propertys.IsEstablished = sPropertyModelView.IsEstablished;
                propertys.IsPriceDisplay = sPropertyModelView.IsPriceDisplay;
                propertys.Location = propertyDetailsModelView.StreetAddress1 + " " + propertyDetailsModelView.StreetAddress2;
                propertys.UpdatedAt = DateTime.UtcNow;
                propertys.Price = sPropertyModelView.Price;
                propertys.PriceText = sPropertyModelView.PriceinText;
                propertys.Name = sPropertyModelView.Title;
                propertys.Status = Propertys.PropertyStatusText.Active;
                propertys.Name = sPropertyModelView.Title;

                //images set 
                IList<PropertyImages> propertyImageses = new List<PropertyImages>();
                foreach (var pImage in array)
                {
                    propertyImages = new PropertyImages();
                    propertyImages.CreatedAt = DateTime.UtcNow;
                    propertyImages.UpdatedAt = DateTime.UtcNow;
                    //propertyImages.Imagedescription = propertyImagesModelView.Imagedescription;
                    propertyImages.ImageUrl = pImage;
                    propertyImages.ThumbUrl = thumbImageFile;
                    //propertyImages.Property = propertys;
                    propertyImageses.Add(propertyImages);
                }

                propertys.PropertyImageses = propertyImageses;
                propertiesList.Add(propertys);

                //property details 
                propertyDetails.Unit = propertyDetailsModelView.Unit;
                propertyDetails.StreetAddress1 = propertyDetailsModelView.StreetAddress1;
                propertyDetails.StreetAddress2 = propertyDetailsModelView.StreetAddress2;
                propertyDetails.Suberb = propertyDetailsModelView.Suberb;
                propertyDetails.Municipility = propertyDetailsModelView.Municipility;
                propertyDetails.BedCount = propertyDetailsModelView.BedCount;
                propertyDetails.BathCount = propertyDetailsModelView.BathCount;
                propertyDetails.AreaCount = propertyDetailsModelView.AreaCount;
                propertyDetails.ParkingCount = propertyDetailsModelView.ParkingCount;
                //propertyDetails. = WebSecurity.CurrentUserId;
                propertyDetails.CreatedAt = DateTime.UtcNow;
                propertyDetails.IsHideStreetAddress = propertyDetailsModelView.IsHideStreetAddress;
                propertyDetails.IsHideStreetView = propertyDetailsModelView.IsHideStreetView;
                propertyDetails.UpdatedAt = DateTime.UtcNow;
                //propertyDetails.Property = propertys;
                propertys.PropertyDetails = propertyDetails;
                PropertyRegistrationService.Save(propertys);
                //PropertyDeteilsSevice.Save(propertyDetails);
                //foreach (var images in propertyImageses)
                //{

            }
            else
            {
                IList<PropertyImages> propertyImageses = new List<PropertyImages>();
                propertyImages = new PropertyImages();
                Propertys propertyGetFromDb = PropertyRegistrationService.GetIdenticalPropertyByTitleAndPriceAndEstablished(sPropertyModelView.Title, sPropertyModelView.Price);
                foreach (var pImage in array)
                {
                    propertyImages.CreatedAt = DateTime.UtcNow;
                    propertyImages.UpdatedAt = DateTime.UtcNow;
                    //propertyImages.Imagedescription = propertyImagesModelView.Imagedescription;
                    propertyImages.ImageUrl = pImage;
                    propertyImages.ThumbUrl = thumbImageFile;
                    //propertyImages.Property = propertyGetFromDb;
                    propertyImageses.Add(propertyImages);
                }
                PropertyRegistrationService.UpdatePropertyAndPropertyImages(propertyGetFromDb, propertyImages);
            }
            var propertiesId = propertys.Id;
            // PropertyRegistration.SaveAllRelatedToProperty( propertyDetails, propertys);
            ViewBag.SuccessMessage = "Property Uploaded Successfully";
            return RedirectToAction("Index", new { message = "Property Saved Successfully" });
        }

    }
}