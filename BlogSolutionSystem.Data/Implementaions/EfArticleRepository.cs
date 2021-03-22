using BlogSolutionSystem.Data.Interfaces;
using BlogSolutionSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Data.Implementaions
{
    public class EfArticleRepository : EfGenericRepository<Article>, IArticleRepository
    {
        public EfArticleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
