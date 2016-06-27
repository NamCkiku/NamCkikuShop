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
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory post);
        void Update(PostCategory post);
        PostCategory Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentID(int parentID);
        PostCategory GetByID(int id);
        void SaveChanges();
    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _IUnitOfWork;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork IUnitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._IUnitOfWork = IUnitOfWork;
        }

        public PostCategory Add(PostCategory post)
        {
            return _postCategoryRepository.Add(post);
        }

        public PostCategory Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        } 

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentID(int parentID)
        {
            return _postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentID);
        }

        public PostCategory GetByID(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void Update(PostCategory post)
        {
            _postCategoryRepository.Update(post);
        }

        public void SaveChanges()
        {
            _IUnitOfWork.Commit();
        }
    }
}
