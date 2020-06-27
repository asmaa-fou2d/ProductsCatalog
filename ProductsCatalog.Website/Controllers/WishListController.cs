using Microsoft.AspNet.Identity;
using ProductsCatalog.Business.DTOs;
using ProductsCatalog.Business.IService;
using ProductsCatalog.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsCatalog.Website.Controllers
{
    public class WishListController : Controller
    {
        readonly private IWishListService _wishListService;

        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        // GET: WishList
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var wishlist = AutoMapper.Mapper.Map<List<WishListViewModel>>(_wishListService.GetAll(userId));
            return View(wishlist);
        }

        [HttpPost]
        public JsonResult AddToWishList(int productId)
        {
            var userId = User.Identity.GetUserId();
            _wishListService.Add(AutoMapper.Mapper.Map<WishListDto>(new { userId = userId, productId = productId, productName = "", productPrice = 0, productPhoto = "" }));
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}