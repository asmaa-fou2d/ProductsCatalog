using AutoMapper;
using ProductsCatalog.Business.DTOs;
using ProductsCatalog.Business.IService;
using ProductsCatalog.Data;
using ProductsCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Business.Service
{
    public class SlideshowService : ISlideshowService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SlideshowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Creare(SlideshowDto slideshowDto)
        {
            _unitOfWork.SlideshowRepository.Add(Mapper.Map<Slideshow>(slideshowDto));
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            _unitOfWork.SlideshowRepository.Remove(_unitOfWork.SlideshowRepository.Get(id));
            _unitOfWork.Complete();
        }

        public List<SlideshowDto> GetAll()
        {
            return Mapper.Map<List<SlideshowDto>>(_unitOfWork.SlideshowRepository.GetAll());
        }

        public SlideshowDto GetById(int id)
        {
            return Mapper.Map<SlideshowDto>(_unitOfWork.SlideshowRepository.Get(id));
        }

        public void Update(SlideshowDto slideshowDto)
        {
            var slide = _unitOfWork.SlideshowRepository.Get(slideshowDto.Id);
            _unitOfWork.SlideshowRepository.Remove(slide);
            _unitOfWork.SlideshowRepository.Add(Mapper.Map<Slideshow>(slideshowDto));
            _unitOfWork.Complete();
        }
    }
}
