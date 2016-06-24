namespace NamCkikuShop.Repository.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NamCkikuShop.Entities.Models.NamCkikuShop dbContext;

        public NamCkikuShop.Entities.Models.NamCkikuShop Init()
        {
            return dbContext ?? (dbContext = new NamCkikuShop.Entities.Models.NamCkikuShop());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}