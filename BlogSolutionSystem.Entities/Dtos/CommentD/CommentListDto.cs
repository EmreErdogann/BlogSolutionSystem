using BlogSolutionSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSolutionSystem.Entities.Dtos.CommentD
{
    public class CommentListDto
    {
        public IList<Comment> Comments { get; set; }
    }
}
