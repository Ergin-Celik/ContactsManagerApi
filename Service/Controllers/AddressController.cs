using Business.Interfaces;
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
    public class AddressController: CustomController
    {
        private IAddressManager _addressManager;

        public AddressController(IAddressManager addressManager)
        {
            _addressManager = addressManager;
        }

        /// <summary>
        /// Update an address for a person, enterprise,... and return it updated.
        /// </summary>
        /// <param name="id">Address id</param>
        /// <param name="patchDoc">Patch actions to execute on the Address</param>
        /// <returns></returns>
        [HttpPatch()]
        public ActionResult<AddressGetDto> UpdateAddress(Guid id, [FromBody]JsonPatchDocument<AddressUpdateDto> patchDoc)
        {
            AddressUpdateDto dto = _addressManager.GetAddressToUpdate(id);

            patchDoc.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_addressManager.UpdateAddress(dto));
        }
    }
}
