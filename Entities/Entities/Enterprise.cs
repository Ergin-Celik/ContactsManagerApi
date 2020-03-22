using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Enterprise
    {
        public Guid Id { get; set; }
        public string VatNumber { get; set; }
        public string Name { get; set; }
        public List<EnterpriseOffice> Offices { get; set; }
    }
}
