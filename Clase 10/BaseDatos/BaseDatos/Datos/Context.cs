using BaseDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Datos
{
    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .IsRequired()
                .HasColumnName("CityName")
                .HasMaxLength(50);

            modelBuilder.Entity<City>().HasKey(c => c.Id);
            modelBuilder.Entity<Employee>().HasKey(c => c.Id);

            modelBuilder.Entity<Employee>()
                .ToTable("Employees");

            modelBuilder.Entity<Employee>()
                .HasRequired(c => c.City)
                .WithMany(c => c.Employees);

            modelBuilder.Entity<Employee>()
                .HasOptional(c => c.Supervisor)
                .WithMany( c => c.Employees);

            base.OnModelCreating(modelBuilder);
        }
    }
}
