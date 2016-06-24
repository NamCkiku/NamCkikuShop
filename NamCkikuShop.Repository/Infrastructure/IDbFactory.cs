using System;

namespace NamCkikuShop.Repository.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        NamCkikuShop.Entities.Models.NamCkikuShop Init();
    }
}