using Entity.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entity;
using Microsoft.EntityFrameworkCore;
using Common.Exceptions;

namespace Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private DatabaseContext _context;

        public PersonRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Person> GetPersons()
        {
            return _context.Person.AsNoTracking().ToList();
        }

        public Person GetPerson(Guid id)
        {
            Person p = _context
                .Person
                .Include(x => x.Address)
                .Include(x => x.EmploymentStatus)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (p == null) { throw new PersonNotFoundException(); }

            return p;
        }

        public Person AddPerson(Person p)
        {
            _context.Person.Add(p);
            _context.SaveChanges();
            _context.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return p;
        }

        public void DeletePerson(Guid id)
        {
            Person p = _context.Person.FirstOrDefault(x => x.Id == id);

            if (p == null) { throw new PersonNotFoundException(); }

            _context.Person.Remove(p);
            _context.SaveChanges();
        }

        public Person UpdatePerson(Person person)
        {
            Person p = _context
                .Person
                .Include(x => x.EmploymentStatus)
                .FirstOrDefault(x => x.Id == person.Id);

            if (p == null) { throw new PersonNotFoundException(); }

            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            p.VatNumber = person.VatNumber;
            p.EmploymentStatusId = person.EmploymentStatusId;

            _context.SaveChanges();
            _context.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return p;
        }

        public EmploymentStatus GetEmploymentStatus(Guid id)
        {
            EmploymentStatus s = _context.EmploymentStatus.SingleOrDefault(x => x.Id == id);

            if(s == null) { throw new EmploymentStatusNotFound(); }

            return s;
        }
    }
}
