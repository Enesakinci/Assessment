using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Dtos
{
    public class ContactDetailAddRequest
    {
        public Guid ContactUuid { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }

    }
}
