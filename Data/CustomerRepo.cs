using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMonitoring.Models;

namespace ShopMonitoring.Data
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerContext _context;

        public CustomerRepo(CustomerContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers(DateTime? startDate, DateTime? endDate)
        {
            IQueryable<Customer> query = _context.Customers;

            if (startDate != null)
                query = query.Where(x => x.VisitDateTime >= startDate.Value);
            if (endDate != null)
                query = query.Where(x => x.VisitDateTime <= endDate.Value);

            return query.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> GetCustomersByIds(int[] ids)
        {
            return _context.Customers.Where(x => ids.Contains(x.Id));
        }

        public void CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _context.Add(customer);
        }

        public void CreateCustomers(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                if (customer == null)
                    throw new NotImplementedException();
            }

            _context.AddRange(customers);
        }
    }
}
