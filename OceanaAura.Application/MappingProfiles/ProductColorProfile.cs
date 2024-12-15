using AutoMapper;
using OceanaAura.Application.Features.ContactUs.Queries.GetContactUsWithDetails;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Features.ProductColor.Commands.UpdateColor;
using OceanaAura.Application.Features.ProductColor.Queries.GetAllProductColors;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.MappingProfiles
{
    public class ProductColorProfile : Profile
    {
        public ProductColorProfile()
        {
            CreateMap<ProductColorDto, LookUpEntity>()
                  .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.ImageUrl))
                  .ForMember(dest => dest.LookUpId, opt => opt.MapFrom(src => src.Id))

                  .ReverseMap();

            CreateMap<AddColorCommand, LookUpEntity>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<UpdateColorCommand, LookUpEntity>()
      .ForMember(dest => dest.LookUpId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
