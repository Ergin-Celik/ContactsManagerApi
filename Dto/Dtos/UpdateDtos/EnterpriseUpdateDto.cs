using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Dtos.UpdateDtos
{
    public class EnterpriseUpdateDto
    {
        public Guid Id { get; set; }
        public string VatNumber { get; set; }
        public string Name { get; set; }
    }
}
