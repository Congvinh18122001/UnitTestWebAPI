using System;
using System.ComponentModel.DataAnnotations;
namespace ProjectLib.Object
{
    public class Member
    {
        [Required] 
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]  
        [DataType(DataType.Date)]
        public string Birthday { get; set; }
        [Required]  
        [Phone(ErrorMessage = "Input phone number.")]
        public string Phone { get; set; }
        [Required]  
        public string Email { get; set; }
        public string BirthPlace { get; set; }
    }
}

