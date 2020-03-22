using Business.Interfaces;
using Business.Managers;
using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Dto.Dtos.UpdateDtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpGet()]
        public ActionResult<List<PersonGetDto>> GetPersons()
        {
            return Ok(_personManager.GetPersons());
        }

        /// <summary>
        /// Get one person by its uid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<PersonGetDto> GetPerson(Guid id)
        {
            return Ok(_personManager.GetPerson(id));
        }

        /// <summary>
        /// Add a person and get it back with id set.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult<PersonGetDto> AddPerson(PersonAddDto dto)
        {
            return Ok(_personManager.AddPerson(dto));
        }

        /// <summary>
        /// Update a person's information. Each property is updated individually.
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult UpdatePerson(Guid id, [FromBody] JsonPatchDocument<PersonUpdateDto> patchDoc)
        {
            PersonUpdateDto dto = _personManager.GetPersonToUpdate(id);

            patchDoc.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_personManager.UpdatePerson(dto));
        }

        /// <summary>
        /// Delete a person by its uid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(Guid id)
        {
            _personManager.DeletePerson(id);
            return Ok();
        }
    }
}
