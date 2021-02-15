using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BusinessObjects.Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public int UserID { get; set; }

        public string UserRole { get; set; }
    }
}
