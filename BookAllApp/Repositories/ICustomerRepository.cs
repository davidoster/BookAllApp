using BookAllApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAllApp.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(string customerId);
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        Customer Delete(string ID);
        IEnumerable<Customer> AllCustomers { get; }
        IEnumerable<Customer> MostFrequentCustomers { get; }
    }
}
