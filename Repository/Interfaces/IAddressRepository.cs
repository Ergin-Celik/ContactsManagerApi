using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IAddressRepository
    {
        Address GetAddress(Guid id);
        Address UpdateAddress(Address address);
    }
}
