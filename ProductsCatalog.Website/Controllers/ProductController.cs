﻿using AutoMapper;
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

    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index(int? categoryId)
        {
            var result = Mapper.Map<List<ProductViewModel>>(_productService.GetAll(categoryId));
            return View(result);
        }

        public ActionResult Create()
        {
            var product = new ProductViewModel
            {
                CategoriesList = Mapper.Map<List<CategoryViewModel>>(_categoryService.GetAll())
            };
            return View("ProductForm", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CategoriesList = Mapper.Map<List<CategoryViewModel>>(_categoryService.GetAll());
                return View("ProductForm", viewModel);
            }
            if (file != null)
            {
                viewModel.Photo = UploadPhoto(file);
            }
            _productService.Creare(Mapper.Map<ProductDto>(viewModel));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var productViewModel = Mapper.Map<ProductViewModel>(_productService.GetById(Id));
            productViewModel.CategoriesList = Mapper.Map<List<CategoryViewModel>>(_categoryService.GetAll());
            return View("ProductForm", productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductViewModel viewModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CategoriesList = Mapper.Map<List<CategoryViewModel>>(_categoryService.GetAll());
                return View("ProductForm", viewModel);
            }
            if (file != null)
            {
                viewModel.Photo = UploadPhoto(file);
            }
            _productService.Update(Mapper.Map<ProductDto>(viewModel));
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int Id)
        {
            _productService.Delete(Id);
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