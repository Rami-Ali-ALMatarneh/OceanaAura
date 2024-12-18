using AutoMapper;
using OceanaAura.Application.Features.LookUp.Commands.Additional;
using OceanaAura.Application.Features.LookUp.Queries.GetAllAdditinalProduct;
using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.MappingProfiles
{
    public class AdditionalProfile : Profile
    {
        public AdditionalProfile() {
        CreateMap<AddAdditionalCommad,AdditionalProduct>().ReverseMap();

            CreateMap<AdditionalProduct, AdditionalDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.LookUpId, opt => opt.MapFrom(src => src.AdditionalProducts.LookUpId))
           .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.AdditionalProducts.NameEn))
           .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.AdditionalProducts.NameAr))
           .ForMember(dest => dest.PriceJor, opt => opt.MapFrom(src => src.PriceJOR))
           .ForMember(dest => dest.PriceUae, opt => opt.MapFrom(src => src.PriceUAE))
           .ForMember(dest => dest.PriceUsd, opt => opt.MapFrom(src => src.PriceUSD)).ReverseMap();
        }
    }
}
