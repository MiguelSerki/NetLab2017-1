using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    static public class CustomerRepository
    {
        static public List<Customer> GetAll()
        {
            List<Customer> customers;

            using (var context = new TestEntities())
            {
                customers = context.Customers.ToList();
            }
            return customers;
        }


    }
}
