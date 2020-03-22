using Dto.Dtos.GetDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dto.Dtos.AddDtos
{
    public class EnterpriseAddDto
    {
        [Required]
        public string VatNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public OfficeAddDto MainOffice { get; set; }
    }
}
