using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class EmpTableDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only integer values are allowed.")]
        //[Range(1 to 500)]
        public int Age { get; set; }
        [Required]
        public string Gender{ get; set; }
        [Required]
        public string Department { get; set; }
        [Required]

        public string Education { get; set; }
        [Required]
        public string Company { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only integer values are allowed.")]
        public int Experience { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only integer values are allowed.")]
        public int Package { get; set; }

    }
}
