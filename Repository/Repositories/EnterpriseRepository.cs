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
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private DatabaseContext _context;

        public EnterpriseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Enterprise> GetEnterprises()
        {
            return _context.Enterprise.AsNoTracking().ToList();
        }

        public Enterprise GetEnterprise(Guid id)
        {
            Enterprise e = _context.Enterprise.AsNoTracking().SingleOrDefault(x => x.Id == id);

            if (e == null) { throw new EnterpriseNotFoundException(); }

            return e;
        }

        public Enterprise AddEnterprise(Enterprise enterprise)
        {
            _context.Enterprise.Add(enterprise);
            _context.SaveChanges();
            _context.Entry(enterprise).State = EntityState.Detached;
            return enterprise;
        }

        public Office AddEnterpriseOffice(EnterpriseOffice eo)
        {
            _context.EnterpriseOffice.Add(eo);
            _context.SaveChanges();
            _context.Entry(eo).State = EntityState.Detached;
            return eo.Office;
        }

        public void DeleteEnterpriseOffice(Guid officeId)
        {
            Office o = _context.Office.SingleOrDefault(x => x.Id == officeId);

            if (o == null) { throw new EnterpriseNotFoundException(); }

            _context.Office.Remove(o);
            _context.SaveChanges();
        }

        public Enterprise UpdateEnterprise(Enterprise enterprise)
        {
            _context.Entry(enterprise).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(enterprise).State = EntityState.Detached;
            return enterprise;
        }

        public Office GetOffice(Guid id)
        {
            Office o = _context
                .Office
                .Include(x => x.Address)
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);

            if (o == null) { throw new EnterpriseNotFoundException(); }

            return o;
        }

        public Office UpdateOffice(Office office)
        {
            _context.Entry(office).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(office).State = EntityState.Detached;
            return office;
        }

        
    }
}
