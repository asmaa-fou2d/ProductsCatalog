using AutoMapper;
using ProductsCatalog.Business.DTOs;
using ProductsCatalog.Business.IService;
using ProductsCatalog.Data;
using ProductsCatalog.Data.Entities;
using System;
using System.Collections.Generic;

namespace ProductsCatalog.Business.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Creare(CategoryDto categoryDto)
        {
            _unitOfWork.CategoryRepository.Add(Mapper.Map<Category>(categoryDto));
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            _unitOfWork.CategoryRepository.Remove(_unitOfWork.CategoryRepository.Get(id));
            _unitOfWork.Complete();
        }

        public List<CategoryDto> GetAll()
        {
           return (Mapper.Map<List<CategoryDto>>(_unitOfWork.CategoryRepository.GetAll()));
        }

        public CategoryDto GetById(int id)
        {
            return Mapper.Map<CategoryDto>(_unitOfWork.CategoryRepository.Get(id));
        }

        public void Update(CategoryDto CategoryDto)
        {
            var categpry = _unitOfWork.CategoryRepository.Get(CategoryDto.Id);
            _unitOfWork.CategoryRepository.Remove(categpry);
            _unitOfWork.CategoryRepository.Add(Mapper.Map<Category>(CategoryDto));
            _unitOfWork.Complete();
        }
    }
}
