using System.ComponentModel.DataAnnotations;

namespace RestApiCRUD.Models
{
    public class Employee
    {   
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Name can only be 20 characters long.")]
        public string Name { get; set; }    

    }
}
