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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var result = Mapper.Map<List<CategoryViewModel>>(_categoryService.GetAll());
            return View(result);
        }


        public ActionResult Create()
        {
            return View("CategoryForm", new CategoryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm", viewModel);
            }
            if (file != null)
            {
                viewModel.Photo = UploadPhoto(file);
            }
            _categoryService.Creare(Mapper.Map<CategoryDto>(viewModel));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var categoryViewModel = Mapper.Map<CategoryViewModel>(_categoryService.GetById(Id));
            return View("CategoryForm", categoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CategoryViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm", viewModel);
            }
            if (file != null)
            {
                viewModel.Photo = UploadPhoto(file);
            }
            _categoryService.Update(Mapper.Map<CategoryDto>(viewModel));
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int Id)
        {
            _categoryService.Delete(Id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private string UploadPhoto(HttpPostedFileBase file)
        {
            string fileName = "";
            fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + Guid.NewGuid() +
            Path.GetExtension(file.FileName);
            file.SaveAs(Path.Combine(Server.MapPath("~/Uploads/Category"), fileName));
            return fileName;
        }

    }
}