using Business.Interfaces;
using Business.Mappers;
using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using Entity.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Managers
{
    public class EnterpriseManager : IEnterpriseManager
    {
        private IEnterpriseRepository _enterpriseRepo;

        public EnterpriseManager(IEnterpriseRepository enterpriseRepo)
        {
            _enterpriseRepo = enterpriseRepo;
        }

        public EnterpriseGetDto AddEnterprise(EnterpriseAddDto dto)
        {
            return _enterpriseRepo.AddEnterprise(dto.ToEntity()).ToDto();
        }

        public OfficeGetDto AddEnterpriseOffice(Guid enterpriseId, OfficeAddDto dto)
        {
            EnterpriseOffice eo = new EnterpriseOffice()
            {
                EnterpriseId = enterpriseId,
                Office = dto.ToEntity()
            };

            return _enterpriseRepo.AddEnterpriseOffice(eo).ToDto();
        }

        public void DeleteEnterpriseOffice(Guid officeId)
        {
            _enterpriseRepo.DeleteEnterpriseOffice(officeId);
        }

        public List<EnterpriseGetDto> GetEnterprises()
        {
            return _enterpriseRepo.GetEnterprises().ToDtos();
        }

        public EnterpriseUpdateDto GetEnterpriseToUpdate(Guid id)
        {
            EnterpriseUpdateDto e = _enterpriseRepo.GetEnterprise(id)?.ToUpdateDto();

            if (e == null)
            {
                throw new Exception();
            }

            return e;
        }

        public OfficeUpdateDto GetOfficeToUpdate(Guid id)
        {
            OfficeUpdateDto dto = _enterpriseRepo.GetOffice(id).ToUpdateDto();

            if (dto == null)
            {
                throw new Exception();
            }

            return dto;
        }

        public EnterpriseGetDto UpdateEnterprise(EnterpriseUpdateDto dto)
        {
            Enterprise e = _enterpriseRepo.GetEnterprise(dto.Id);

            e.Name = dto.Name;
            e.VatNumber = dto.VatNumber;

            return _enterpriseRepo.UpdateEnterprise(e).ToDto();
        }

        public OfficeGetDto UpdateOffice(OfficeUpdateDto dto)
        {
            Office office = _enterpriseRepo.GetOffice(dto.Id);

            if(office == null)
            {
                throw new Exception("Le bureau n'existe pas.");
            }
            
            office.IsMainOffice = dto.IsMainOffice;

            return _enterpriseRepo.UpdateOffice(office).ToDto();
        }
    }
}
