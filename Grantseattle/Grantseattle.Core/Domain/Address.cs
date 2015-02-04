using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryERP.Domain
{
    public class Address : IValueObject
    {
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StateName { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }                       
    }
}
