using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Dto.Dtos.UpdateDtos
{
    public class PersonUpdateDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string VatNumber { get; set; }
        public Guid EmploymentStatusId { get; set; }
    }
}
