using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Clases
{
    class Ej17
    {
        DateTime today = DateTime.Now;

        List<DateTime> dates = new List<DateTime>
        {
               new DateTime(2017, 1, 21),
               new DateTime(2014, 2, 17),
               new DateTime(2013, 3, 20),
               new DateTime(2012, 4, 2),
               new DateTime(2010, 10, 7),
               new DateTime(2018, 6, 8),
               new DateTime(2025, 7, 9),
               new DateTime(2022, 8, 11),
               new DateTime(1980, 9, 12),
               new DateTime(1970, 10, 13),
               new DateTime(2099, 11, 18),
               new DateTime(1945, 12, 15),
        };

        public void ShowFutureDates()
        {
            Console.WriteLine("Las fechas futuras son:");
            foreach (var date in dates)
                if (date > today)
                    Console.WriteLine(date.ToShortDateString());
        }

        public void ShowOctoberDates()
        {
            Console.WriteLine("Las fechas de Octubre son:");
            foreach (var date in dates)
                if (date.Month == 10)
                    Console.WriteLine(date.ToShortDateString());
        }

        public void ShowOldDates()
        {
            Console.WriteLine("Las fechas previas al 2000 son:");
            foreach (var date in dates)
                if (date.Year < 2000)
                    Console.WriteLine(date.ToShortDateString());
        }

    }
}
