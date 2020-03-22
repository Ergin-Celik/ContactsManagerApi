using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IAddressManager
    {
        AddressUpdateDto GetAddressToUpdate(Guid id);
        AddressGetDto UpdateAddress(AddressUpdateDto dto);
    }
}
