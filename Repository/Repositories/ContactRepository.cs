using Common.Exceptions;
using Entity;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private DatabaseContext _context;

        public ContactRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Contact> GetContacts(Guid personId)
        {
            return _context
                .Contact
                .Include(x => x.SecondPerson)
                .Where(x => x.FirstPersonId == personId)
                .AsNoTracking()
                .ToList();
        }

        public void AddContact(Contact contact)
        {
            _context.Contact.Add(contact);
            _context.SaveChanges();
        }

        public void DeleteContact(Guid personId, Guid contactPersonId)
        {
            Contact c = _context.Contact.FirstOrDefault(x => x.FirstPersonId == personId && x.SecondPersonId == contactPersonId);

            if (c == null) { throw new ContactNotFoundException(); }
            
            _context.Contact.Remove(c);
            _context.SaveChanges();
        }

    }
}
