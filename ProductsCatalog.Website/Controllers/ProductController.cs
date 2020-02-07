using AutoMapper;
using ProductsCatalog.Business.IService;
using ProductsCatalog.Website.DTOs;
using ProductsCatalog.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsCatalog.Website.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var result = Mapper.Map<List<ProductViewModel>>(_productService.GetAllProducts());
            return View(result);
        }

        public ActionResult Create()
        {
            var productViewModel = new ProductViewModel();
            return View("ProductForm", productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductForm", viewModel);
            }
            if (file != null)
            {
                viewModel.Photo = UploadPhoto(file);
            }
            _productService.CreareOrUpdate(Mapper.Map<ProductDto>(viewModel));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var productViewModel = Mapper.Map<ProductViewModel>(_productService.GetProduct(Id));
            return View("ProductForm", productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductForm", viewModel);
            }
            if (file != null)
            {
                viewModel.Photo = UploadPhoto(file);
            }
            _productService.CreareOrUpdate(Mapper.Map<ProductDto>(viewModel));
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int Id)
        {
            bool result = _productService.Delete(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
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