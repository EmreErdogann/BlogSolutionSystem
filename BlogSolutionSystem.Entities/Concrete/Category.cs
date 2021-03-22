using BlogSolutionSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
