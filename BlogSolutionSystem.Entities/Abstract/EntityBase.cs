using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string CreatedByName { get; set; } = "Admin"; 
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual string Note { get; set; }

    }
}
