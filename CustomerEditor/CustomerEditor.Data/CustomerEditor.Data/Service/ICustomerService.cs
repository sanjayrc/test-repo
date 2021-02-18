using CustomerEditor.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerEditor.Data.Service
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Gets active Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        IEnumerable<Customer> GetActive();

        /// <summary>
        /// Gets a Customer by Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns></returns>
        Customer GetById(int id);

        /// <summary>
        /// Checks if a Customer exists
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns></returns>
        bool Exists(int id);

        /// <summary>
        /// Saves a new or updates existing Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        void Save(Customer customer);

        /// <summary>
        /// Deletes a Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        void Delete(int id);
    }
}
