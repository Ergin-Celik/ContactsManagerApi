using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dto.Dtos.AddDtos
{
    public class OfficeAddDto
    {
        [Required]
        public bool IsMainOffice { get; set; }
        [Required]
        public AddressAddDto Address { get; set; }
    }
}
