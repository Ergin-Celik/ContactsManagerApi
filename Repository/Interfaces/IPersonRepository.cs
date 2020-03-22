using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetPersons();
        Person GetPerson(Guid id);
        Person AddPerson(Person p);
        void DeletePerson(Guid id);
        Person UpdatePerson(Person person);
        EmploymentStatus GetEmploymentStatus(Guid id);
    }
}
