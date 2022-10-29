using System;
using System.Collections.Generic;

#nullable disable

namespace Contact.API.Entities
{
    public partial class Contact
    {
        public Contact()
        {
            ContactDetails = new HashSet<ContactDetail>();
        }

        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
