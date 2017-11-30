using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF._2.Entidades
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(40)]
        public string Surname { get; set; }

        public int CityId { get; set; }

        public int? SupervisorId { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }

        [StringLength(60)]
        public string Position { get; set; }

        public virtual Employee Supervisor { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}