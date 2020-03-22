using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers
{
    public static class UserMapper
    {
        public static User ToEntity(this UserAddDto dto)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Mail = dto.Mail,
                Password = dto.Password,
                Person = dto.Person?.ToEntity()
            };
        }

        public static UserGetDto ToDto(this User entity)
        {
            return new UserGetDto()
            {
                Id = entity.Id,
                Mail = entity.Mail,
                Person = entity.Person.ToDto()
            };
        }
    }
}
