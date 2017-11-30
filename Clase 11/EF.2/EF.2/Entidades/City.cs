using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF._2.Entidades
{
    [Table("Cities")]
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}