using Business.Interfaces;
using Business.Mappers;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Managers
{
    public class AddressManager : IAddressManager
    {
        private IAddressRepository _addressRepo;

        public AddressManager(IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public AddressUpdateDto GetAddressToUpdate(Guid id)
        {
            return _addressRepo.GetAddress(id)?.ToUpdateDto();
        }

        public AddressGetDto UpdateAddress(AddressUpdateDto dto)
        {
            return _addressRepo.UpdateAddress(dto.ToEntity()).ToDto();
        }
    }
}
