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
    public class AddressRepository : IAddressRepository
    {
        private DatabaseContext _context;

        public AddressRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Address GetAddress(Guid id)
        {
            Address a = _context.Address.AsNoTracking().SingleOrDefault(x => x.Id == id);

            if(a == null) { throw new AddressNotFoundException(); }

            return a;
        }

        public Address UpdateAddress(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(address).State = EntityState.Detached;
            return address;
        }
    }
}
