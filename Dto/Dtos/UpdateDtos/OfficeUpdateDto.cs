using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Dtos.UpdateDtos
{
    public class OfficeUpdateDto
    {
        public Guid Id { get; set; }
        public bool IsMainOffice { get; set; }
    }
}
