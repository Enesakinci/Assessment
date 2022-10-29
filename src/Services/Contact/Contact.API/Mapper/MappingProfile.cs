using AutoMapper;
using Contact.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact.API.Entities.Contact,ContactResponse>();
            CreateMap<Contact.API.Entities.ContactDetail,ContactDetailResponse>();
        }
    }
}
