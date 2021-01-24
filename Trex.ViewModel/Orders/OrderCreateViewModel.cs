using System;
using System.Collections.Generic;
using System.Text;
using Trex.Entity.Models;

namespace Trex.ViewModel.Orders
{
    public class OrderCreateViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public Order Order { get; set; }
    }
}
