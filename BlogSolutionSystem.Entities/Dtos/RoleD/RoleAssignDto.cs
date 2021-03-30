using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Entities.Dtos.RoleD
{
    public class RoleAssignDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool HasRole { get; set; }
    }
}
