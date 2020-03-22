using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers
{
    public static class PersonMapper
    {
        public static PersonGetDto ToDto(this Person entity)
        {
            return new PersonGetDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                VatNumber = entity.VatNumber,
                EmploymentStatus = entity.EmploymentStatus?.ToDto(),
                Address = entity.Address?.ToDto()
            };
        }

        public static List<PersonGetDto> ToDtos(this List<Person> entities)
        {
            var list = new List<PersonGetDto>();

            foreach (var e in entities)
            {
                list.Add(e.ToDto());
            }

            return list;
        }

        public static PersonUpdateDto ToUpdateDto(this Person entity)
        {
            return new PersonUpdateDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                VatNumber = entity.VatNumber,
                EmploymentStatusId = entity.EmploymentStatus.Id
            };
        }

        public static Person ToEntity(this PersonAddDto dto)
        {
            return new Person()
            {
                Id = Guid.NewGuid(),
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                VatNumber = dto.VatNumber,
                EmploymentStatusId = dto.EmploymentStatusId,
                Address = dto.Address.ToEntity()
            };
        }

        public static Person ToEntity(this PersonUpdateDto dto)
        {
            return new Person()
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                VatNumber = dto.VatNumber,
                EmploymentStatusId = dto.EmploymentStatusId
            };
        }
    }
}
