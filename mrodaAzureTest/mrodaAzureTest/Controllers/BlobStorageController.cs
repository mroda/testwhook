using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using mrodaAzureTest.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mrodaAzureTest.Controllers
{
    public class BlobStorageController : Controller
    {
        BlobStorageService service = new BlobStorageService();
        // GET: BlobStorage
        public ActionResult Index()
        {
            
            return View(service.GetBlobItems());
        }

       
        [HttpPost]
        public ActionResult ImageUpload()
        {
            var file = Request.Files["file"];
            if (file == null || file.ContentLength==0)
                ViewBag.UploadMessage = "Failed to upload image";
            else
                service.UploadFile(file);
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string filename)
        {
            service.Delete(filename);
            return RedirectToAction("Index");
        }
    }
}