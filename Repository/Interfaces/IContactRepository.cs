using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetContacts(Guid personId);
        void AddContact(Contact contact);
        void DeleteContact(Guid personId, Guid contactPersonId);
    }
}
