using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class PersonEnterprise
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
    }
}
