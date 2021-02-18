using CustomerEditor.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerEditor.API.Models
{
    public class CustomerModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }

        public Customer ToEntity()
        {
            return new Customer
            {
                Id = Id.GetValueOrDefault(),
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                Active = Active
            };
        }
    }
}
