﻿using NamCkikuShop.Entities.Models;
using NamCkikuShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamCkikuShop.Repository.Repositories
{
    public interface ITagsRepository: IRepository<Tag>
    {

    }
    public class TagsRepository : RepositoryBase<Tag>, ITagsRepository
    {
        public TagsRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
