using Dto.Dtos.GetDtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers
{
    public static class EmploymentStatusMapper
    {
        public static EmploymentStatusGetDto ToDto(this EmploymentStatus entity)
        {
            return new EmploymentStatusGetDto()
            {
                Id = entity.Id,
                StatusName = entity.StatusName,
            };
        }
    }
}
