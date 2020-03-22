using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers
{
    public static class AddressMapper
    {
        public static AddressGetDto ToDto(this Address entity)
        {
            return new AddressGetDto()
            {
                Id = entity.Id,
                Street = entity.Street,
                Number = entity.Number,
                PostalCode = entity.PostalCode,
                City = entity.City,
                Country = entity.Country
            };
        }

        public static AddressUpdateDto ToUpdateDto(this Address entity)
        {
            return new AddressUpdateDto()
            {
                Id = entity.Id,
                Street = entity.Street,
                Number = entity.Number,
                PostalCode = entity.PostalCode,
                City = entity.City,
                Country = entity.Country
            };
        }

        public static Address ToEntity(this AddressAddDto dto)
        {
            return new Address()
            {
                Id = Guid.NewGuid(),
                Street = dto.Street,
                Number = dto.Number,
                PostalCode = dto.PostalCode,
                City = dto.City,
                Country = dto.Country
            };
        }

        public static Address ToEntity(this AddressUpdateDto dto)
        {
            return new Address()
            {
                Id = dto.Id,
                Street = dto.Street,
                Number = dto.Number,
                PostalCode = dto.PostalCode,
                City = dto.City,
                Country = dto.Country
            };
        }
    }
}
