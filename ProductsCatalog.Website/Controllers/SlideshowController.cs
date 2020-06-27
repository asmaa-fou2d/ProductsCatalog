using AutoMapper;
using ProductsCatalog.Business.DTOs;
using ProductsCatalog.Business.IService;
using ProductsCatalog.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsCatalog.Website.Controllers
{
    public class SlideshowController : Controller
    {
        private readonly ISlideshowService _slideshowService;

        public SlideshowController(ISlideshowService slideshowService)
        {
            _slideshowService = slideshowService;
        }

        public ActionResult Index(int? categoryId)
        {
            var result = Mapper.Map<List<SlideshowViewModel>>(_slideshowService.GetAll());
            return View(result);
        }

        public ActionResult Create()
        {
            return View("SlideshowForm", new SlideshowViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SlideshowViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("SlideshowForm", viewModel);
            }
            if (file != null)
            {
                viewModel.Photo = UploadPhoto(file);
            }
            _slideshowService.Creare(Mapper.Map<SlideshowDto>(viewModel));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var slideshowViewModel = Mapper.Map<SlideshowViewModel>(_slideshowService.GetById(Id));
            return View("SlideshowForm", slideshowViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SlideshowViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("SlideshowForm", viewModel);
            }
            if (file != null)
            {
                viewModel.Photo = UploadPhoto(file);
            }
            _slideshowService.Update(Mapper.Map<SlideshowDto>(viewModel));
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int Id)
        {
            _slideshowService.Delete(Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private string UploadPhoto(HttpPostedFileBase file)
        {
            string fileName = "";
            fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + Guid.NewGuid() +
            Path.GetExtension(file.FileName);
            file.SaveAs(Path.Combine(Server.MapPath("~/Uploads"), fileName));
            return fileName;
        }
    }
}