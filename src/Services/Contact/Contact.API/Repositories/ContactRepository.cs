using AutoMapper;
using Contact.API.Dtos;
using Contact.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AssessmentContext _context;
        private readonly IMapper _mapper;
        public ContactRepository(IMapper mapper, AssessmentContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<ContactResponse>> GetAllContact()
        {
            var data = await _context.Contacts.Where(x => x.IsActive == true).ToListAsync();
            return _mapper.Map<IEnumerable<ContactResponse>>(data);
        }
    }
}
