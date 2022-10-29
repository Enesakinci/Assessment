using Contact.API.Dtos;
using Contact.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactController : _BaseController
    {

        private readonly ILogger<ContactController> _logger;
        private readonly IContactRepository _contactRepository;
        public ContactController(ILogger<ContactController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContactResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ContactResponse>>> GetContacts()
        {
            var response = await _contactRepository.GetAllContact();
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }

    }
}
