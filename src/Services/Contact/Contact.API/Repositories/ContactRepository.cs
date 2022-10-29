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

        public async Task<bool> AddContact(ContactAddRequest contactAddRequest)
        {
            try
            {
                await _context.Contacts.AddAsync(new Entities.Contact
                {
                    Company = contactAddRequest.Company,
                    Name = contactAddRequest.Name,
                    Surname = contactAddRequest.Surname,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> AddContactDetail(ContactDetailAddRequest contactDetailAddRequest)
        {
            try
            {
                await _context.ContactDetails.AddAsync(new ContactDetail
                {
                    Location = contactDetailAddRequest.Location,
                    Email = contactDetailAddRequest.Email,
                    Phone = contactDetailAddRequest.Phone,
                    ContactUuid = contactDetailAddRequest.ContactUuid,

                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> DeleteContact(Guid uuid)
        {
            try
            {
                var deleteContact = await _context.Contacts.Where(x => x.IsActive == true && x.Uuid == uuid).FirstOrDefaultAsync();
                if (deleteContact != null)
                {
                    var deleteContactDetail = await _context.ContactDetails.Where(x => x.IsActive == true && x.ContactUuid == uuid).FirstOrDefaultAsync();
                    deleteContact.IsActive = false;
                    if (deleteContactDetail != null)
                        deleteContactDetail.IsActive = false;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<IEnumerable<ContactResponse>> GetAllContact()
        {
            var data = await _context.Contacts.Where(x => x.IsActive == true).Include(x => x.ContactDetails.Where(y => y.IsActive == true)).ToListAsync();
            return _mapper.Map<IEnumerable<ContactResponse>>(data);
        }
    }
}
