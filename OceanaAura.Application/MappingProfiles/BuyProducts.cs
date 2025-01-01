using AutoMapper;
using OceanaAura.Application.Features.LookUp.Queries.GetAllPayment;
using OceanaAura.Application.Features.LookUp.Queries.GetAllRegions;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetSize;
using OceanaAura.Application.Features.ProductSize.Queries.GetSizeDetails;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.MappingProfiles
{
    public class BuyProducts : Profile
    {
        public BuyProducts()
        {
            CreateMap<ProductSize, SizeDetailsDto>().ReverseMap();
            CreateMap<AdditionalProduct, PaymentDto>()
                           .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.AdditionalProducts.NameEn))
           .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.AdditionalProducts.NameAr))
              .ReverseMap();
            CreateMap<LookUpEntity, RegionDto>()
                           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LookUpId))
                .ReverseMap();

            CreateMap<LookUpEntity, ColorDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LookUpId))
           .ForMember(dest => dest.Img, opt => opt.MapFrom(src => src.Details))
           .ReverseMap();
           CreateMap<ProductSize,SizeDto>()
           .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.Size.NameEn))
           .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.Size.NameAr))
                .ReverseMap();

        }
    }
}
