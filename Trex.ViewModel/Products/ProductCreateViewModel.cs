using System;
using System.Collections.Generic;
using System.Text;
using Trex.Entity.Models;

namespace Trex.ViewModel
{
    public class ProductCreateViewModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}
