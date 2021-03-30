using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Entities.Dtos.RoleD
{
    public class UserRoleAssignDto
    {
        public UserRoleAssignDto()
        {
            RoleAssignDtos = new List<RoleAssignDto>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<RoleAssignDto> RoleAssignDtos { get; set; }
    }
}
