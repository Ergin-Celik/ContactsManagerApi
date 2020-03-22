using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Dtos.GetDtos
{
    public class ContactGetDto
    {
        public Guid ContactPersonId { get; set; }

        public PersonGetDto Person{ get; set; }
    }
}
