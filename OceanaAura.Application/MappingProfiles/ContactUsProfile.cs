using AutoMapper;
using OceanaAura.Application.Features.ContactUs.Commands.AddContactUs;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Features.ContactUs.Queries.GetContactUsWithDetails;
using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.MappingProfiles
{
    public class ContactUsProfile : Profile
    {
        public ContactUsProfile()
        {
            CreateMap<ContactUs, ContactUsDto>()
                       .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => src.SubmittedAt.ToString("yyyy-MM-dd HH:mm"))) // Format date
                       .ReverseMap();


            CreateMap<ContactUsDetailsDto, ContactUs>().ReverseMap();
            CreateMap<AddContactUsCommand, ContactUs>().ReverseMap();

        }
    }
}
