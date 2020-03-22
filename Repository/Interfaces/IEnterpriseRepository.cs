using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IEnterpriseRepository
    {
        Enterprise GetEnterprise(Guid id);
        List<Enterprise> GetEnterprises();
        Enterprise AddEnterprise(Enterprise enterprise);
        Enterprise UpdateEnterprise(Enterprise enterprise);
        Office AddEnterpriseOffice(EnterpriseOffice office);
        Office GetOffice(Guid id);
        Office UpdateOffice(Office office);
        void DeleteEnterpriseOffice(Guid officeId);
    }
}
