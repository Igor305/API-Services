using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class Field
    {
        public Field()
        {
            RoleAccessToFields = new HashSet<RoleAccessToField>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AccessDepartmentFormId { get; set; }
        public string KeyName { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual AccessDepartmentForm AccessDepartmentForm { get; set; }
        public virtual ICollection<RoleAccessToField> RoleAccessToFields { get; set; }
    }
}
