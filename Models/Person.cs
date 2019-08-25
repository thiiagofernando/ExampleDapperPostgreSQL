using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleDapperPostgreSQL.Models
{
    [Table("person", Schema = "public")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Informe o E-mail"), MaxLength(200)]
        public string fullname { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe o E-mail"), MaxLength(200)]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Informe o Telefone"), MaxLength(20)]
        public string phone { get; set; }
    }
}
