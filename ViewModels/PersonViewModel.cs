using ExampleDapperPostgreSQL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleDapperPostgreSQL.ViewModels
{
    [Table("Person")]
    public class PersonViewModel : BaseEntity
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Informe o E-mail"), MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe o E-mail"), MaxLength(200)]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Informe o Telefone"), MaxLength(20)]
        public string Phone { get; set; }
    }
}
