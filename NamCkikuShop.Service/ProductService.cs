using NamCkikuShop.Common;
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
    public interface IProductService
    {
        Product Add(Product productCategory);
        void Update(Product productCategory);
        Product Delete(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAll(string keyword);
        Product GetByID(int id);
        IEnumerable<Product> GetLastest(int top);
        IEnumerable<Product> GetHotProduct(int top);
        void SaveChanges();
    }
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _IUnitOfWork;
        private ITagsRepository _tagRepository;
        private IProductTagRepository _productTagRepository;

        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository,
            ITagsRepository _tagRepository, IUnitOfWork IUnitOfWork)
        {
            this._productRepository = productRepository;
            this._productTagRepository = productTagRepository;
            this._tagRepository = _tagRepository;
            this._IUnitOfWork = IUnitOfWork;
        }

        public Product Add(Product product)
        {
            var productdb = _productRepository.Add(product);
            _IUnitOfWork.Commit();
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
            return productdb;
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.DeleteMulti(x => x.ProductID == product.ID);
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }


        public Product GetByID(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _IUnitOfWork.Commit();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetLastest(int top)
        {
            return _productRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Product> GetHotProduct(int top)
        {
            return _productRepository.GetMulti(x => x.Status && x.HotFlag == true).OrderByDescending(x => x.CreatedDate).Take(top);
        }
    }
}
