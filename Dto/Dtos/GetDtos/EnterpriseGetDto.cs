using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Dtos.GetDtos
{
    public class EnterpriseGetDto
    {
        public Guid Id { get; set; }
        public string VatNumber { get; set; }
        public string Name { get; set; }
        public List<OfficeGetDto> Offices { get; set; }
    }
}
