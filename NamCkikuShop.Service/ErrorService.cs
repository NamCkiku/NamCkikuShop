﻿using NamCkikuShop.Entities.Models;
using NamCkikuShop.Repository.Infrastructure;
using NamCkikuShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamCkikuShop.Service
{
    public interface IErrorService
    {
        Error Create(Error error);
        void SaveChanges();
    }
    public class ErrorService: IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;
        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }
        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
