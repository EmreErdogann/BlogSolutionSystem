using BlogSolutionSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Entities.Dtos.CategoryD
{
    public class CategoryListDto 
    {
        public IList<Category> Categories { get; set; }

    }
}
