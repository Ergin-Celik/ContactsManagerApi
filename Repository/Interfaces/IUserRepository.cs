using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(Guid id);
        User GetUser(string mail);
        User AddUser(User user);
    }
}
