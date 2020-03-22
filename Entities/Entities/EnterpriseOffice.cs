using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class EnterpriseOffice
    {
        public Guid EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
