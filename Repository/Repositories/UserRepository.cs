using Entity;
using Entity.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Common.Exceptions;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            EmploymentStatus status = _context.EmploymentStatus.AsNoTracking().SingleOrDefault(x => x.Id == user.Person.EmploymentStatusId);

            if (status == null) { throw new EmploymentStatusNotFound(); }

            _context.User.Add(user);
            _context.SaveChanges();
            _context.Entry(user).State = EntityState.Detached;
            return user;
        }

        public User GetUser(Guid id)
        {
            User u = _context
                .User
                .Include(x => x.Person)
                .ThenInclude(x => x.Address)
                .Include(x => x.Person)
                .ThenInclude(x => x.EmploymentStatus)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (u == null) { throw new UserNotFoundException(); }

            return u;
        }

        public User GetUser(string mail)
        {
            User u = _context.User.SingleOrDefault(x => x.Mail.ToLower().Equals(mail.ToLower()));

            if(u == null) { throw new UserNotFoundException(); }

            return u;
        }
    }
}
