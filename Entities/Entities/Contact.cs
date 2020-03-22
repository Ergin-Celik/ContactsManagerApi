using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Contact
    {
        public Guid FirstPersonId { get; set; }
        public Person FirstPerson { get; set; }

        public Guid SecondPersonId { get; set; }
        public Person SecondPerson { get; set; }
    }
}
