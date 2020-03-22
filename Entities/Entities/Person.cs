using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public string VatNumber { get; set; }
        public Guid EmploymentStatusId { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
