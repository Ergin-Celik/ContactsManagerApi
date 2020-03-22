using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dto.Dtos.AddDtos
{
    public class UserAddDto
    {
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public PersonAddDto Person { get; set; }
    }
}
