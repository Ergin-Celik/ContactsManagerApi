using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Dtos.UpdateDtos
{
    public class AddressUpdateDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
