using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Services.Dtos;

namespace Services
{
    public class OrderService
    {
        public List<ReadOrderDto> ReadAll()
        {
            var list = new List<ReadOrderDto>();

            var data = DataAccess.ReadAll();

            foreach (var order in data)
            {
                list.Add(new ReadOrderDto()
                {
                    OrderID = order.OrderID,
                    CustomerName = order.Customer.ContactName,
                    Freight = order.Freight
                });
            }

            return list;
        }
    }
}
