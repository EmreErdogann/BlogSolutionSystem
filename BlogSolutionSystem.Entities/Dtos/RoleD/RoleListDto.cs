using BlogSolutionSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Entities.Dtos.RoleD
{
    public class RoleListDto
    {
        public IList<Role> Roles { get; set; }
    }
}
