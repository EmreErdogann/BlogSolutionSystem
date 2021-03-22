using BlogSolutionSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Entities.Dtos.UserD
{
    public class UserListDto
    {
        public IList<User> Users { get; set; }
    }
}
