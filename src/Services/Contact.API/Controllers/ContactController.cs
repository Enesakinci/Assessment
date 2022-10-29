using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contact.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : _BaseController
    {

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

 
    }
}
