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
    public interface IFooterService
    {
        void Add(Footer post);
        void Update(Footer post);
        void Delete(int id);
        IEnumerable<Footer> GetAll();
        //IEnumerable<Footer> GetAllPaging(int page, int pageSize, out int totalRow);
        //Footer GetByID(int id);
        //IEnumerable<Footer> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class FooterService : IFooterService
    {
        IFooterRepository _footerRepository;
        IUnitOfWork _footerIUnitOfWork;
        public FooterService(IFooterRepository footerRepository, IUnitOfWork footerIUnitOfWork)
        {
            this._footerRepository = footerRepository;
            this._footerIUnitOfWork = footerIUnitOfWork;
        }
        public void Add(Footer post)
        {
            _footerRepository.Add(post);
        }

        public void Delete(int id)
        {
            _footerRepository.Delete(id);
        }

        public IEnumerable<Footer> GetAll()
        {
            return _footerRepository.GetAll(new string[] { "PostCategory" });
        }

        //public IEnumerable<Footer> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        //{
        //    return _footerRepository.GetMultiPaging(out totalRow, page, pageSize);
        //}

        //public IEnumerable<Footer> GetAllPaging(int page, int pageSize, out int totalRow)
        //{
        //    return _footerRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        //}

        public Footer GetByID(int id)
        {
            return _footerRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _footerIUnitOfWork.Commit();
        }

        public void Update(Footer post)
        {
            _footerRepository.Update(post);
        }
    }
}
