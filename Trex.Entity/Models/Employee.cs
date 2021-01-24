using System;
using System.Collections.Generic;
using System.Text;

namespace Trex.Entity.Models
{
    public class Employee : ModelBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string BirthDate { get; set; }
        public string HireDate { get; set; }
        public string Notes { get; set; }
        public string ReportsTo { get; set; }
        public List<int> TerritoryIds { get; set; }
        public Address Address { get; set; }
    }
}
