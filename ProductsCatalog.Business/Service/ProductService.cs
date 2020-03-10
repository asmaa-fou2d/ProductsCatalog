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
        public List<ProductDto> GetAllProducts()
        {
            return Mapper.Map<List<ProductDto>>(_unitOfWork.Products.GetAll());
        }

        /// <inheritdoc />
        public void Creare(ProductDto productDto)
        {
            _unitOfWork.Products.Add(Mapper.Map<Product>(productDto));
            _unitOfWork.Complete();
        }

        /// <inheritdoc />
        public ProductDto GetProduct(int id)
        {
            return Mapper.Map<ProductDto>(_unitOfWork.Products.Get(id));
        }

        /// <inheritdoc />
        public void Update(ProductDto productDto)
        {
            //var list = new List<int>();
            //list.Add(1);
            //list.Remove(1);
            //list.Find(1);
            var pro = _unitOfWork.Products.Get(productDto.Id);
            _unitOfWork.Products.Remove(pro);
            _unitOfWork.Products.Add(Mapper.Map<Product>(productDto));
            _unitOfWork.Complete();
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            _unitOfWork.Products.Remove(_unitOfWork.Products.Get(id));
            _unitOfWork.Complete();
        }
    }
}
