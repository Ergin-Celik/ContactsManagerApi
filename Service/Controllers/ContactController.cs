using Business.Interfaces;
using Dto.Dtos.GetDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ContactController : CustomController
    {
        private IContactManager _contactManager;

        public ContactController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        /// <summary>
        /// Get all the contacts for the connected user(default) or the specified user.
        /// </summary>
        /// <param name="userId">Id of the user for which to get the contacts</param>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<List<PersonGetDto>> GetContacts()
        {
            return Ok(_contactManager.GetContacts(UserId));
        }

        /// <summary>
        /// Add the contact to the connected user.
        /// </summary>
        /// <param name="contactPersonId"></param>
        /// <returns></returns>
        [HttpPost("{contactPersonId}")]
        public ActionResult AddContact(Guid contactPersonId)
        {
            _contactManager.AddContact(PersonId, contactPersonId);
            return Ok();
        }

        /// <summary>
        /// Delete the contact from the connected user's list.
        /// </summary>
        /// <param name="contactPersonId"></param>
        /// <returns></returns>
        [HttpDelete("{contactPersonId}")]
        public ActionResult DeleteContact(Guid contactPersonId)
        {
            _contactManager.DeleteContact(PersonId, contactPersonId);
            return Ok();
        }
    }
}
