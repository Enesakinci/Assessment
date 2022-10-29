using Contact.API.Dtos;
using Contact.API.Repositories;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
//using Report.GRPC;

namespace Contact.API.Controllers
{
    [ApiController]
    [Route("api/v1/[action]")]
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
        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> AddContact(ContactAddRequest contactAddRequest)
        {
            var response = await _contactRepository.AddContact(contactAddRequest);
            if (response != false)
                return Ok(response);
            else
                return BadRequest();
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteContact(Guid uuid)
        {
            var response = await _contactRepository.DeleteContact(uuid);
            if (response != false)
                return Ok(response);
            else
                return BadRequest();
        }
        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> AddContactDetail(ContactDetailAddRequest contactDetailAddRequest)
        {
            var response = await _contactRepository.AddContactDetail(contactDetailAddRequest);
            if (response != false)
                return Ok(response);
            else
                return BadRequest();
        }
        //[HttpGet]
        ////[ProducesResponseType(typeof(IEnumerable<ContactResponse>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult> CreateReport()
        //{
        //    var channel = GrpcChannel.ForAddress("https://localhost:5001");
        //    var client = new GrpcNetCore.Greeter.GreeterClient(channel);

        //    var response = await client.SayHelloAsync(
        //        new GrpcNetCore.HelloRequest { Name = "World" });
        //    Console.WriteLine(response.Message);

        //    var streamResponse = client.SayHelloStream(new GrpcNetCore.HelloRequest { Name = "Stream Example" });
        //    while (await streamResponse.ResponseStream.MoveNext())
        //    {
        //        Console.WriteLine(streamResponse.ResponseStream.Current.Message);
        //    }
        //    Console.WriteLine("End of response");
        //    Console.ReadLine();
        //}

    }
}
