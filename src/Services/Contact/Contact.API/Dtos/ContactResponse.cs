using Contact.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Dtos
{
    public class ContactResponse
    {

        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public IEnumerable<ContactDetailResponse> ContactDetails { get; set; }
    }
}
