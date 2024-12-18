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

            CreateMap<ProductSize, ProductSizeDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.Size.NameEn))
           .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.Size.NameAr))
           .ForMember(dest => dest.PriceJor, opt => opt.MapFrom(src => src.PriceJOR))
           .ForMember(dest => dest.PriceUae, opt => opt.MapFrom(src => src.PriceUAE))
           .ForMember(dest => dest.PriceUsd, opt => opt.MapFrom(src => src.PriceUSD)).ReverseMap();
            CreateMap<AddSizeCommand, LookUpEntity>().ReverseMap();

        }
    }
}
