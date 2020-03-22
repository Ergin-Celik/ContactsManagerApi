using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers
{
    public static class OfficeMapper
    {
        public static OfficeGetDto ToDto(this Office entity)
        {
            return new OfficeGetDto()
            {
                Id = entity.Id,
                Address = entity.Address.ToDto(),
                IsMainOffice = entity.IsMainOffice
            };
        }

        public static List<OfficeGetDto> ToDtos(this List<Office> entities)
        {
            var list = new List<OfficeGetDto>();

            foreach (var e in entities)
            {
                list.Add(new OfficeGetDto() { 
                     Id = e.Id,
                     IsMainOffice = e.IsMainOffice,
                     Address = e.Address.ToDto()
                });
            }

            return list;
        }

        public static OfficeUpdateDto ToUpdateDto(this Office entity)
        {
            return new OfficeUpdateDto()
            {
                Id = entity.Id,
                IsMainOffice = entity.IsMainOffice
            };
        }

        public static Office ToEntity(this OfficeAddDto dto)
        {
            return new Office()
            {
                Id = Guid.NewGuid(),
                Address = dto.Address.ToEntity(),
                IsMainOffice = dto.IsMainOffice
            };
        }
    }
}
