using AutoMapper;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Features.ProductSize.Command.AddSize;
using OceanaAura.Application.Features.ProductSize.Queries.GetAllSize;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.MappingProfiles
{
    public class ProductSizeProfile : Profile
    {
        public ProductSizeProfile()
        {

            CreateMap<ProductSizeDto, LookUpEntity>()
                  .ForMember(dest => dest.LookUpId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<AddSizeCommand, LookUpEntity>().ReverseMap();

        }
    }
}
