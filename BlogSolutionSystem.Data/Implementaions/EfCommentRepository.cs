using BlogSolutionSystem.Data.Interfaces;
using BlogSolutionSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Data.Implementaions
{
    public class EfCommentRepository : EfGenericRepository<Comment>, ICommentRepository
    {
        public EfCommentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
