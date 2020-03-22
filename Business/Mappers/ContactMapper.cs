using Dto.Dtos.GetDtos;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers
{
    public static class ContactMapper
    {
        public static PersonGetDto ToDto(this Contact entity)
        {
            return entity.SecondPerson.ToDto();
        }

        public static List<PersonGetDto> ToDtos(this List<Contact> entities)
        {
            var list = new List<PersonGetDto>();

            foreach (var e in entities)
            {
                list.Add(e.ToDto());
            }

            return list;
        }
    }
}
