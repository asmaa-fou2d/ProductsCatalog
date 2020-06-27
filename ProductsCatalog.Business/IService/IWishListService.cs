using ProductsCatalog.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Business.IService
{
    public interface IWishListService
    {
        /// <summary>
        /// Get all user wish list 
        /// </summary>
        /// <returns>list of user wish list</returns>
        List<WishListDto> GetAll(string userId);

        /// <summary>
        /// add to slideshow
        /// </summary>
        /// <param name="WishListDto">WishListDto Dto</param>
        void Add(WishListDto slideshowDto);

        /// <summary>
        /// Delete from wish list 
        /// </summary>
        /// <param name="WishListDto">WishListDto Dto</param>
        void Delete(WishListDto slideshowDto);
        
    }
}
