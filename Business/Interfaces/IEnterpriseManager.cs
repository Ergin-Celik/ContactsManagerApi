using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IEnterpriseManager
    {
        List<EnterpriseGetDto> GetEnterprises();
        EnterpriseGetDto AddEnterprise(EnterpriseAddDto dto);
        OfficeGetDto AddEnterpriseOffice(Guid enterpriseId, OfficeAddDto dto);
        EnterpriseUpdateDto GetEnterpriseToUpdate(Guid id);
        EnterpriseGetDto UpdateEnterprise(EnterpriseUpdateDto dto);
        OfficeUpdateDto GetOfficeToUpdate(Guid id);
        OfficeGetDto UpdateOffice(OfficeUpdateDto dto);
        void DeleteEnterpriseOffice(Guid officeId);
    }
}
