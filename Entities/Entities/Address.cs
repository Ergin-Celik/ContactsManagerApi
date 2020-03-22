using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
