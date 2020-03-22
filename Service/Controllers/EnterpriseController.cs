using Business.Interfaces;
using Business.Mappers;
using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EnterpriseController : CustomController
    {
        private IEnterpriseManager _enterpriseManager;

        public EnterpriseController(IEnterpriseManager enterpriseManager)
        {
            _enterpriseManager = enterpriseManager;
        }

        [HttpGet()]
        public ActionResult<List<EnterpriseGetDto>> GetEnterprises(){
            return Ok(_enterpriseManager.GetEnterprises());
        }

        /// <summary>
        /// Add a new enterprise.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult<EnterpriseGetDto> AddEnterprise(EnterpriseAddDto dto)
        {
            return Ok(_enterpriseManager.AddEnterprise(dto));
        }

        /// <summary>
        /// Update an eterprise's information.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult<EnterpriseGetDto> UpdateEnterprise(Guid id, [FromBody] JsonPatchDocument<EnterpriseUpdateDto> patchDoc)
        {
            EnterpriseUpdateDto dto = _enterpriseManager.GetEnterpriseToUpdate(id);

            patchDoc.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_enterpriseManager.UpdateEnterprise(dto));
        }

        /// <summary>
        /// Add a new office for a given enterprise.
        /// </summary>
        /// <param name="enterpriseId">Enterprise id</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("office")]
        public ActionResult<OfficeGetDto> AddOffice(Guid enterpriseId, OfficeAddDto dto)
        {
            return Ok(_enterpriseManager.AddEnterpriseOffice(enterpriseId, dto));
        }

        /// <summary>
        /// Update an office's information.
        /// </summary>
        /// <param name="id">Office uid</param>
        /// <param name="patchDoc">Array of operations to execute</param>
        /// <returns></returns>
        [HttpPatch("office")]
        public ActionResult<OfficeGetDto> UpdateOffice(Guid id, [FromBody]JsonPatchDocument<OfficeUpdateDto> patchDoc)
        {
            OfficeUpdateDto dto = _enterpriseManager.GetOfficeToUpdate(id);

            patchDoc.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_enterpriseManager.UpdateOffice(dto));
        }

        /// <summary>
        /// Delete an enterprises's office by its uid. 
        /// </summary>
        /// <param name="officeId">Office uid</param>
        /// <returns></returns>
        [HttpDelete("office")]
        public ActionResult DeleteOffice(Guid officeId)
        {
            _enterpriseManager.DeleteEnterpriseOffice(officeId);
            return Ok();
        }
    }
}
