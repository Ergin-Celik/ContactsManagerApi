using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Dtos.GetDtos
{
    public class PersonGetDto
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public AddressGetDto Address { get; set; }
        public string VatNumber { get; set; }
        public EmploymentStatusGetDto EmploymentStatus { get; set; }
    }
}
