using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Dtos.GetDtos
{
    public class UserGetDto
    {
        public Guid Id { get; set; }
        public string Mail { get; set; }
        public PersonGetDto Person { get; set; }
    }
}
