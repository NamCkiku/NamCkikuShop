using NamCkikuShop.Entities.Models;
using System;

namespace NamCkikuShop.Repository.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        NamCkikuShopDbContext Init();
    }
}