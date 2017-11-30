using EF._2.Entidades;

namespace EF._2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF._2.Datos.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF._2.Datos.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Employees.AddOrUpdate(c =>
            //{
            //    if (c.Name == "David")
            //    {
            //        context.Employees.Add(new Employee
            //        {
            //            Name = ""
            //        });
            //    }
            //});

            //context.Cities.Add(new City
            //{

            //});
        }
    }
}
