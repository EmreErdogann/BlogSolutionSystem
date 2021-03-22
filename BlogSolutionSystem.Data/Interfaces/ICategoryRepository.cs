using BlogSolutionSystem.Entities.Abstract;
using BlogSolutionSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Data.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
