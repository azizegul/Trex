using System;
using System.Collections.Generic;
using System.Text;

namespace Trex.Entity.Models
{
    public class ShipAddress : ModelBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
