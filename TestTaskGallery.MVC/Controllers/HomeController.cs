using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
//using TestTaskGallery.Core.Entities;
//using TestTaskGallery.Core.Repositories;
using TestTaskGallery.MVC.Models;

namespace TestTaskGallery.MVC.Controllers
{
    public class HomeController : Controller
    {
        //private IUploadFileRepository _uploadFileRepository;

        private IMapper _mapper = null;
        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null) _mapper = MapperConfig.GetConfiguration().CreateMapper();
                return _mapper;
            }
        }

        public HomeController(IUploadFileRepository uploadFileRepository)
        {
            _uploadFileRepository = uploadFileRepository;
        }

        public ActionResult Index()
        {
            var res = _uploadFileRepository.Start();
            return View(Mapper.Map<IEnumerable<Models.UserModel>>(res));
        }

        public JsonResult GetAllProducts()
        {
            var res = _uploadFileRepository.Start();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Upload(Object obj)
        {
            //if (upload != null && upload.ContentLength > 0)
            //{
            //    var avatar = new UploadFileModel();
            //    using (var reader = new System.IO.BinaryReader(upload.InputStream))
            //    {
            //        avatar.Photo = reader.ReadBytes(upload.ContentLength);
            //    }
            //    var res = _uploadFileRepository.Start().FirstOrDefault();
            //    res.UploadFiles = new Collection<UploadFile> { Mapper.Map<TestTaskGallery.Core.Entities.UploadFile>(avatar) };
            //}
            
            return Json("ok", JsonRequestBehavior.AllowGet);
        }  

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}