using System.ComponentModel.DataAnnotations;

namespace ExampleDapperPostgreSQL.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
