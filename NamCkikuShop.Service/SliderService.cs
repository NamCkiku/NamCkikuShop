using NamCkikuShop.Entities.Models;
using NamCkikuShop.Repository.Infrastructure;
using NamCkikuShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamCkikuShop.Service
{
    public interface ISliderService
    {
        void Add(Slide slide);
        void Update(Slide slide);
        void Delete(int id);
        IEnumerable<Slide> GetAll();
        IEnumerable<Slide> GetSlide();
        //IEnumerable<Footer> GetAllPaging(int page, int pageSize, out int totalRow);
        //Footer GetByID(int id);
        //IEnumerable<Footer> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class SliderService : ISliderService
    {
        ISlideRepository _slideRepository;
        IUnitOfWork _IUnitOfWork;
        public SliderService(ISlideRepository slideRepository, IUnitOfWork IUnitOfWork)
        {
            this._slideRepository = slideRepository;
            this._IUnitOfWork = IUnitOfWork;
        }
        public void Add(Slide slide)
        {
            _slideRepository.Add(slide);
        }

        public void Delete(int id)
        {
            _slideRepository.Delete(id);
        }

        public IEnumerable<Slide> GetAll()
        {
            return _slideRepository.GetAll(new string[] { "PostCategory" });
        }

        //public IEnumerable<Footer> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        //{
        //    return _footerRepository.GetMultiPaging(out totalRow, page, pageSize);
        //}

        //public IEnumerable<Footer> GetAllPaging(int page, int pageSize, out int totalRow)
        //{
        //    return _footerRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        //}

        public Slide GetByID(int id)
        {
            return _slideRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _IUnitOfWork.Commit();
        }

        public void Update(Slide slide)
        {
            _slideRepository.Update(slide);
        }
        public IEnumerable<Slide> GetSlide()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }
    }
}
