using System;
using System.Collections.Generic;
using ShopMonitoring.Models;

namespace ShopMonitoring.Data
{
    public interface ICustomerRepo
    {
        void SaveChanges();

        IEnumerable<Customer> GetAllCustomers(DateTime? startDate, DateTime? endDate);

        Customer GetCustomerById(int id);

        IEnumerable<Customer> GetCustomersByIds(int[] ids);

        void CreateCustomer(Customer customer);

        void CreateCustomers(IEnumerable<Customer> customers);
    }
}
