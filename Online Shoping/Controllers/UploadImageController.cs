using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Online_Shoping.Controllers
{
    public class UploadImageController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        IWebHostEnvironment webHostEnvironment;

        public UploadImageController(IWebHostEnvironment webHostEnvironment)//injection controller
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult uploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult uploadImage(IFormFile Image)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
                fileStream.Close();
            }



            return View();
        }
    }
}
