using AutoMapper;
using ProductsCatalog.Business.DTOs;
using ProductsCatalog.Business.IService;
using ProductsCatalog.Data;
using ProductsCatalog.Data.Entities;
using System.Collections.Generic;

namespace ProductsCatalog.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <inheritdoc />
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public List<ProductDto> GetAll(int? categoryId)
        {
            if (categoryId == null)
            {
                return Mapper.Map<List<ProductDto>>(_unitOfWork.ProductRepository.GetAll(null,"Category"));
            }
            else
            {
                return Mapper.Map<List<ProductDto>>(_unitOfWork.ProductRepository.GetAll(p => p.CategoryId == categoryId, "Category"));
            }
        }

        /// <inheritdoc />
        public void Creare(ProductDto productDto)
        {
            _unitOfWork.ProductRepository.Add(Mapper.Map<Product>(productDto));
            _unitOfWork.Complete();
        }

        /// <inheritdoc />
        public ProductDto GetById(int id)
        {
            return Mapper.Map<ProductDto>(_unitOfWork.ProductRepository.Get(id));
        }

        /// <inheritdoc />
        public void Update(ProductDto productDto)
        {
            //var list = new List<int>();
            //list.Add(1);
            //list.Remove(1);
            //list.Find(1);
            var pro = _unitOfWork.ProductRepository.Get(productDto.Id);
            _unitOfWork.ProductRepository.Remove(pro);
            _unitOfWork.ProductRepository.Add(Mapper.Map<Product>(productDto));
            _unitOfWork.Complete();
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            _unitOfWork.ProductRepository.Remove(_unitOfWork.ProductRepository.Get(id));
            _unitOfWork.Complete();
        }
    }
}
