using Business.Dtos;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerService
    {   

        public void AddCustomer(Customer customer)
        {
            
        }

        public List<CustomerDto> ReadCustomers()
        {
            List<CustomerDto> customers = new List<CustomerDto>();
            foreach (var c in CustomerRepository.GetAll())
            {
                var customer = new CustomerDto
                {
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    ContactTitle = c.ContactTitle,
                    Address = c.Address,
                    City = c.City,
                    Region = c.Region,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    Phone = c.Phone,
                    Fax = c.Fax
                };

                customers.Add(customer);
            }
            return customers;
        }
    }
}
