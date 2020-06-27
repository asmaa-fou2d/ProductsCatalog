using ProductsCatalog.Business.DTOs;
using ProductsCatalog.Business.IService;
using ProductsCatalog.Data;
using ProductsCatalog.Data.Entities;
using ProductsCatalog.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Business.Service
{
    public class WishListService : IWishListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(WishListDto slideshowDto)
        {
            try
            {
                _unitOfWork.WishListRepository.Add(AutoMapper.Mapper.Map<WishList>(slideshowDto));
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {

            }
        }

        public void Delete(WishListDto slideshowDto)
        {
            _unitOfWork.WishListRepository.Remove(AutoMapper.Mapper.Map<WishList>(slideshowDto));
        }

        public List<WishListDto> GetAll(string userId)
        {
            return AutoMapper.Mapper.Map<List<WishListDto>>(_unitOfWork.WishListRepository.GetAll(p => p.UserId == userId,"Product"));
        }
    }
}
