using Business.Interfaces;
using Business.Mappers;
using Dto.Dtos.GetDtos;
using Entity.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Managers
{
    public class ContactManager : IContactManager
    {
        private IContactRepository _contactRepo;

        public ContactManager(IContactRepository contactRepo) 
        {
            _contactRepo = contactRepo;
        }

        public void AddContact(Guid personId, Guid contactPersonId)
        {
            _contactRepo.AddContact(
                new Contact() { 
                    FirstPersonId = personId, 
                    SecondPersonId = contactPersonId 
                });
        }

        public void DeleteContact(Guid personId, Guid contactPersonId)
        {
            _contactRepo.DeleteContact(personId, contactPersonId);
        }

        public List<PersonGetDto> GetContacts(Guid personId)
        {
            List<Contact> contacts = _contactRepo.GetContacts(personId);

            return contacts.ToDtos();
        }
    }
}
