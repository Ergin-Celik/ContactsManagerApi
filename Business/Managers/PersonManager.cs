using Business.Interfaces;
using Business.Mappers;
using Common.Exceptions;
using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using Entity.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Managers
{
    public class PersonManager : IPersonManager
    {
        public IPersonRepository _personRepo;

        public PersonManager(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public List<PersonGetDto> GetPersons()
        {
            return _personRepo.GetPersons().ToDtos();
        }

        public PersonGetDto GetPerson(Guid id)
        {
            return _personRepo.GetPerson(id)?.ToDto();
        }

        public PersonUpdateDto GetPersonToUpdate(Guid id)
        {
            return _personRepo.GetPerson(id)?.ToUpdateDto();
        }

        public PersonGetDto AddPerson(PersonAddDto p)
        {
            //Get employment status
            EmploymentStatus status = _personRepo.GetEmploymentStatus(p.EmploymentStatusId);

            if(status.StatusName.Equals("Indépendant") && string.IsNullOrWhiteSpace(p.VatNumber))
            {
                throw new VatNumberRequiredException();
            }

            return _personRepo
                .AddPerson(p.ToEntity())
                .ToDto();
        }

        public void DeletePerson(Guid id)
        {
            _personRepo.DeletePerson(id);
        }

        public PersonGetDto UpdatePerson(PersonUpdateDto dto)
        {
            return _personRepo
                .UpdatePerson(dto.ToEntity())
                .ToDto();
        }

        
    }
}
