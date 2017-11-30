//using System;
//using System.Collections.Generic;
//using System.Data.Entity.ModelConfiguration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EF._2.Entidades;

//namespace EF._2.Datos.Configurations
//{
//    public class CityConfigurations : EntityTypeConfiguration<City>
//    {
//        public CityConfigurations()
//        {
//            HasKey(c => c.Id);

//            HasMany(c => c.Employees)
//                .WithRequired(c => c.City);
//        }
//    }
//}
