using System;
using System.Collections.Generic;
using System.Globalization;
using ShopMonitoring.Models;

namespace ShopMonitoring.Data
{
    public class CustomerMockRepo : ICustomerRepo

    {
        public void SaveChanges()
        {
            return;
        }

        public IEnumerable<Customer> GetAllCustomers(DateTime? startDate, DateTime? endDate)
        {
            return new List<Customer>()
            {
                new Customer { Id = 0, VisitDateTime = GetDate("2020-10-01 14:56"), Age = 20, WasSatisfied = true, Sex = 'F' },
                new Customer { Id = 1, VisitDateTime = GetDate("2020-10-03 14:57"), Age = 24, WasSatisfied = false, Sex = 'M' },
                new Customer { Id = 2, VisitDateTime = GetDate("2020-10-05 14:58"), Age = 28, WasSatisfied = false, Sex = 'F' },
                new Customer { Id = 3, VisitDateTime = GetDate("2020-10-07 14:59"), Age = 32, WasSatisfied = true, Sex = 'M' },
            };
        }

        public Customer GetCustomerById(int id)
        {
            return new Customer { Id = 0, VisitDateTime = GetDate("2020-10-07 14:59"), Age = 20, WasSatisfied = true, Sex = 'F' };
        }

        public IEnumerable<Customer> GetCustomersByIds(int[] ids)
        {
            return new List<Customer>()
            {
                new Customer { Id = 1, VisitDateTime = GetDate("2020-10-03 14:57"), Age = 24, WasSatisfied = false, Sex = 'M' },
                new Customer { Id = 2, VisitDateTime = GetDate("2020-10-05 14:58"), Age = 28, WasSatisfied = false, Sex = 'F' },
            };
        }

        public void CreateCustomer(Customer customer)
        {
            return;
        }

        public void CreateCustomers(IEnumerable<Customer> customers)
        {
            return;
        }

        private DateTime GetDate(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        }
    }
}
