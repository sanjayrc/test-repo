using CustomerEditor.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CustomerEditor.Data.Service
{
    public class CustomerService : ICustomerService
    {
        private CustomerDBContext context;

        public CustomerService(CustomerDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            var query = from customer in context.Customers
                        select customer;

            return query.ToList();
        }

        public IEnumerable<Customer> GetActive()
        {
            var query = from customer in context.Customers
                        where customer.Active == true
                        select customer;

            return query.ToList();
        }

        public Customer GetById(int id)
        {
            var query = from customer in context.Customers
                        where customer.Id == id
                        select customer;

            return query.FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return context.Customers.Count(e => e.Id == id) > 0;
        }

        public void Save(Customer customer)
        {
            var query = from cust in context.Customers
                        where cust.Id == customer.Id
                        select cust;

            var existing = query.FirstOrDefault();

            if (existing == null)
                context.Customers.Add(customer);
            else
            {
                existing.FirstName = customer.FirstName;
                existing.LastName = customer.LastName;
                existing.Address = customer.Address;
                existing.Active = customer.Active;
                context.Entry(existing).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var query = from cust in context.Customers
                        where cust.Id == id
                        select cust;

            var existing = query.FirstOrDefault();

            if (existing != null)
                context.Customers.Remove(existing);

            context.SaveChanges();
        }
    }
}
