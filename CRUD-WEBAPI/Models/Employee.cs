using System.ComponentModel.DataAnnotations;

namespace CRUD_WEBAPI.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Place enter employee name.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Place enter employee surname.")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Place enter employee position.")]
        public string Position { get; set; }
    }
}
