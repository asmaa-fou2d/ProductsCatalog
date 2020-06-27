using AutoMapper;
using ProductsCatalog.Business.IService;
using ProductsCatalog.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsCatalog.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlideshowService _slideshowService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(ISlideshowService slideshowService, IProductService productService, ICategoryService categoryService)
        {
            _slideshowService = slideshowService;
            _productService = productService;
            _categoryService = categoryService;
        }


        public ActionResult Slideshow()
        {
            var slideshow = Mapper.Map<List<SlideshowViewModel>>(_slideshowService.GetAll());
            return PartialView("_Slideshow", slideshow);
        }

        public ActionResult ShowLeftSideMenu()
        {
            var categories = Mapper.Map<List<CategoryViewModel>>(_categoryService.GetAll());
            return PartialView("_LeftSideNavBar", categories);
        }

        public ActionResult Index()
        {
            var products = Mapper.Map<List<ProductViewModel>>(_productService.GetRandomProducts());
            return View(products);
        }
        public ActionResult ViewProducts(int? categoryId)
        {
            var products = Mapper.Map<List<ProductViewModel>>(_productService.GetAll(categoryId));
            return View(products);
        }
    }
}