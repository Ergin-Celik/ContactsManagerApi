using Dto.Dtos.GetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IContactManager
    {
        List<PersonGetDto> GetContacts(Guid personId);
        void AddContact(Guid personId, Guid contactPersonId);
        void DeleteContact(Guid personId, Guid contactPersonId);
    }
}
