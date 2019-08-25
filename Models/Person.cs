using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleDapperPostgreSQL.Models
{
    [Table("Person")]
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
