using System.Data.Entity;
using EF._2.Entidades;

namespace EF._2.Datos
{
    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CityConfigurations());

            //modelBuilder.Configurations.AddFromAssembly(typeof(Context).Assembly);

            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name2")
                .HasMaxLength(50);

            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Employee>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Employee>()
                .ToTable("Employees");

            modelBuilder.Entity<Employee>()
                .HasRequired(c => c.City)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.CityId);


            modelBuilder.Entity<Employee>()
                .Property(c => c.SupervisorId)
                .HasColumnName("Supervisor_Id");

            modelBuilder.Entity<Employee>()
                .HasOptional(c => c.Supervisor)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.SupervisorId);

            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Categories)
                .WithMany(c => c.Employees)
                .Map(c => c.ToTable("EmployeesCategories")
                    .MapLeftKey("Id1")
                    .MapRightKey("Id2"));

            base.OnModelCreating(modelBuilder);
        }
    }
}