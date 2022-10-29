using System;
using System.Collections.Generic;

#nullable disable

namespace Contact.API.Entities
{
    public partial class ContactDetail
    {
        public Guid Uuid { get; set; }
        public Guid ContactUuid { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual Contact ContactUu { get; set; }
    }
}
