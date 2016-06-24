using NamCkikuShop.Entities.Models;
using NamCkikuShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamCkikuShop.Repository.Repositories
{
    public interface IMenuGroupRepository
    {

    }
    public class MenuGroupRepository: RepositoryBase<MenuGroup>,IMenuGroupRepository
    {
        public MenuGroupRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
