using AutoMapper;
using OceanaAura.Application.Features.Product.Command.AddProduct;
using OceanaAura.Application.Features.Product.Command.EditProduct;
using OceanaAura.Application.Features.Product.Queries.GetAllProduct;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using OceanaAura.Application.Features.Product.Queries.GetProductByName;
using OceanaAura.Application.Features.Product.Queries.GetProductDetails;
using OceanaAura.Application.Features.Product.Queries.GetProductUnique;
using OceanaAura.Domain.Entities.ProductsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
       public ProductProfile() { 

        CreateMap<AddProductCommand,Product>().ReverseMap();
        CreateMap<EditProductCommand, Product>().ReverseMap();

            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<Product, ProductDetailsDto>()
               .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages))
               .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ProductImages.Select(img => img.ImageUrl).ToList()))
               .ReverseMap();

            CreateMap<Product, GetProductDto>()
             .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.NameEnCategory, opt => opt.MapFrom(src => src.Category.NameEn))
             .ForMember(dest => dest.NameArCategory, opt => opt.MapFrom(src => src.Category.NameAr))
             .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ProductImages.Select(img => img.ImageUrl).ToList()))
             .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn.ToString("yyyy-MM-dd HH:mm"))) // Format date
             .ForMember(dest => dest.ModifyOn, opt => opt.MapFrom(src => src.ModifyOn.HasValue ? src.ModifyOn.Value.ToString("yyyy-MM-dd HH:mm") : "N/A")) // Format date
             
             .ReverseMap();
            CreateMap<UniqueProductDto, Product>().ReverseMap();
            CreateMap<Product,ProductHomeDto>()
             
            .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => src.ProductImages.Select(img => img.ImageUrl).ToList()))
                .ReverseMap();  

        }
    }
}
