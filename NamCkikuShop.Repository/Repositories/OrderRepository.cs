using NamCkikuShop.Entities.Models;
using NamCkikuShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamCkikuShop.Repository.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {

    }
    public class OrderRepository : RepositoryBase<Order>,IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
    }
}
