using BlogSolutionSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Entities.Dtos.ArticleD
{
    public class ArticleListDto
    {
        public IList<Article> Articles { get; set; }
    }
}
