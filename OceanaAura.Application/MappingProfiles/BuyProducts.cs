using AutoMapper;
using OceanaAura.Application.Features.BottleImg.Command.AddBottleImg;
using OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImg;
using OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImgCustomize;
using OceanaAura.Application.Features.BottleImg.Queries.GetAllBottleImg;
using OceanaAura.Application.Features.Invoice.Commands.AddInvoice;
using OceanaAura.Application.Features.Invoice.Queries.GetAllInvoices;
using OceanaAura.Application.Features.Invoice.Queries.GetInvoices;
using OceanaAura.Application.Features.LookUp.Queries.CustomizationFees.Queries.GetCustomizationFees;
using OceanaAura.Application.Features.LookUp.Queries.GetAllPayment;
using OceanaAura.Application.Features.LookUp.Queries.GetAllRegions;
using OceanaAura.Application.Features.LookUp.Queries.GetAllStatus;
using OceanaAura.Application.Features.Order.Commands.CreateOrder;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using OceanaAura.Application.Features.Product.Queries.Lids;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetSize;
using OceanaAura.Application.Features.ProductSize.Queries.GetSizeDetails;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Entities.ProductsEntities;
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
           .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
           .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr))

           .ReverseMap();
            CreateMap<ProductSize, SizeDto>()
            .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.Size.NameEn))
            .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.Size.NameAr))
                 .ReverseMap();
            CreateMap<OrderDto, Order>()
                                 .ReverseMap();
            CreateMap<GetOrdersDto, Order>()
                .ReverseMap();
            CreateMap<CartDto, Cart>()
             .ReverseMap();
            CreateMap<LookUpEntity, StatusDto>()
                            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.LookUpId))

.ReverseMap();
            CreateMap<Cart, cartCommand>()
              .ReverseMap();
            CreateMap<InvoiceDetails, OrderDto>()
          .ReverseMap();

            CreateMap<InvoiceDetailsDto, InvoiceDetails>()
        .ReverseMap();
            CreateMap<Invoice, InvoiceDtos>()
.ReverseMap();
            CreateMap<Product, LidsDto>()
.ReverseMap();

            CreateMap<GetBottleImg, BottleImg>()
.ReverseMap();
            CreateMap<AddBottleImgDto, BottleImg>()
.ReverseMap();
            CreateMap<BottleImg, BottleImgDto>()
                      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                      .ForMember(dest => dest.ImgUrlFront, opt => opt.MapFrom(src => src.ImgUrlFront))
                      .ForMember(dest => dest.ImgUrlBack, opt => opt.MapFrom(src => src.ImgUrlBack))
                      .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId))
                      .ForMember(dest => dest.ColorId, opt => opt.MapFrom(src => src.ColorId))
                      .ForMember(dest => dest.LidId, opt => opt.MapFrom(src => src.LidId))
                      .ReverseMap();
            CreateMap<BottleImg, filteredBottleImgCustomizeDto>();
            CreateMap<CustomizationFeesDto, AdditionalProduct>()
.ReverseMap();
        }
    }
}
