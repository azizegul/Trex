using System;
using System.Collections.Generic;
using System.Text;

namespace Trex.Entity.Models
{
    public class Product : ModelBase
    {
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public string Name { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
        public Address Address { get; set; }
    }

    public class Category : ModelBase
    {
        public string Description { get; set; }
        public string Name { get; set; }
    }

    public class Supplier : ModelBase
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public Address Address { get; set; }
    }

}
