using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Mappers
{
    public static class EnterpriseMapper
    {
        public static EnterpriseGetDto ToDto(this Enterprise entity)
        {
            return new EnterpriseGetDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                VatNumber = entity.VatNumber,
                Offices = entity.Offices?.Select(x => x.Office).ToList().ToDtos()
            };
        }

        public static List<EnterpriseGetDto> ToDtos(this List<Enterprise> entities)
        {
            var list = new List<EnterpriseGetDto>();

            foreach (var e in entities)
            {
                list.Add(e.ToDto());
            }

            return list;
        }

        public static Enterprise ToEntity(this EnterpriseAddDto dto)
        {
            Guid id = Guid.NewGuid();

            return new Enterprise()
            {
                Id = id,
                Name = dto.Name,
                VatNumber = dto.VatNumber,
                Offices = new List<EnterpriseOffice>() { 
                    new EnterpriseOffice() { 
                        EnterpriseId = id,
                        Office = dto.MainOffice.ToEntity()
                    } 
                }
            };
        }

        public static EnterpriseUpdateDto ToUpdateDto(this Enterprise entity)
        {
            return new EnterpriseUpdateDto()
            {
                Id = entity.Id,
                VatNumber = entity.VatNumber,
                Name = entity.Name
            };
        }
    }
}
