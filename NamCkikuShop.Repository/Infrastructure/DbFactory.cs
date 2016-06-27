using NamCkikuShop.Entities.Models;

namespace NamCkikuShop.Repository.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NamCkikuShopDbContext dbContext;

        public NamCkikuShopDbContext Init()
        {
            return dbContext ?? (dbContext = new NamCkikuShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}