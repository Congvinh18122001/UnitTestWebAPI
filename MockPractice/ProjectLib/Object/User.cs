using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace ProjectLib.Object
{
    public class User
    {
        [Required]
        [Key]
        public int UserID {get;set;}
        [Required]
        public string Username {get;set;}
        [Required]
        public string Password {get;set;}
        public int RoleID {get;set;} 
        public virtual Role Role { get; set; }
    }
    public class Role
    {
        public int ID {get;set;}
        public string RoleName{get;set;}
        public virtual List<User> Users { get; set; }
    }
}

