using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
