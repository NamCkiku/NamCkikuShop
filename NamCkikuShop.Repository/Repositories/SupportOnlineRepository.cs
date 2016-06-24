using NamCkikuShop.Entities.Models;
using NamCkikuShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamCkikuShop.Repository.Repositories
{
    public interface ISupportOnlineRepository
    {

    }
    public class SupportOnlineRepository : RepositoryBase<MenuGroup>, ISupportOnlineRepository
    {
        public SupportOnlineRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
