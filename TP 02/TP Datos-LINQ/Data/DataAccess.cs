using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data
{
    public static class DataAccess
    {
        public static List<Order> ReadAll()
        {
            using (var context = new Context())
            {
                return context.Orders
                    .Include(c => c.Customer)
                    .AsNoTracking()
                    .ToList();
            }
        }
    }
}
