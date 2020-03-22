using Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dto.Dtos.AddDtos
{
    public class PersonAddDto
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public AddressAddDto Address { get; set; }
        
        public string VatNumber { get; set; }
        [NotEmpty]
        public Guid EmploymentStatusId { get; set; }
    }
}
