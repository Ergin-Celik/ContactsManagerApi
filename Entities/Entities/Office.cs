using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Office
    {
        public Guid Id { get; set; }
        public bool IsMainOffice { get; set; }
        public Address Address { get; set; }
    }
}
