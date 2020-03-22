using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Dtos.GetDtos
{
    public class OfficeGetDto
    {
        public Guid Id { get; set; }
        public bool IsMainOffice { get; set; }
        public AddressGetDto Address { get; set; }
    }
}
