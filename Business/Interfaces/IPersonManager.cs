using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IPersonManager
    {
        List<PersonGetDto> GetPersons();
        PersonGetDto GetPerson(Guid id);
        PersonUpdateDto GetPersonToUpdate(Guid id);
        PersonGetDto AddPerson(PersonAddDto p);
        PersonGetDto UpdatePerson(PersonUpdateDto dto);
        void DeletePerson(Guid id);
    }
}
