using Contact.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Repositories
{
    public interface IContactRepository
    {

        Task<IEnumerable<ContactResponse>> GetAllContact();
        Task<bool> DeleteContact(Guid uuid);
        Task<bool> AddContactDetail(ContactDetailAddRequest contactDetailResponse);
        Task<bool> AddContact(ContactAddRequest contactAddRequest);
    }
}
