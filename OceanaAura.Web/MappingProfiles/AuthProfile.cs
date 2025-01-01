using AutoMapper;
using OceanaAura.Application.Features.ContactUs.Commands.AddContactUs;
using OceanaAura.Application.Features.LookUp.Queries.GetAllPayment;
using OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories;
using OceanaAura.Application.Features.LookUp.Queries.GetAllRegions;
using OceanaAura.Application.Features.Product.Command.AddProduct;
using OceanaAura.Application.Features.Product.Command.EditProduct;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using OceanaAura.Application.Features.Product.Queries.GetProductByName;
using OceanaAura.Application.Features.Product.Queries.GetProductDetails;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetSize;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Features.ProductSize.Command.AddSize;
using OceanaAura.Application.Models.Identity.Login;
using OceanaAura.Application.Models.Identity.Password;
using OceanaAura.Application.Models.Identity.UserInfo;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Entities.ProductsEntities;
using OceanaAura.Web.Models.Auth;
using OceanaAura.Web.Models.BuyVM;
using OceanaAura.Web.Models.Colors;
using OceanaAura.Web.Models.Home;
using OceanaAura.Web.Models.Lookup;
using OceanaAura.Web.Models.Products;
using OceanaAura.Web.Models.Size;
using System.Drawing;

namespace OceanaAura.Web.MappingProfiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile() {
            CreateMap<LoginVM, LoginRequest>().ReverseMap();
            CreateMap<ForgetPasswordVM, ForgetPasswordRequest>().ReverseMap();
            CreateMap<ResetPasswordVM, ResetPasswordRequest>().ReverseMap();
            CreateMap<NewPasswordVM, ChangePasswordRequest>().ReverseMap();
            CreateMap<UpdateInfo, UpdateInfoRequest>().ReverseMap();
            CreateMap<ChangePasswordVM, ChangeNewPassowrd>().ReverseMap();
            CreateMap<AddContactUsCommand, ContactUsVM>().ReverseMap();
            CreateMap<AddColorCommand,ColorVM>().ReverseMap();
            CreateMap<AddSizeCommand, SizeVM>().ReverseMap();
            CreateMap<CategoryVM,CategoryDto>().ReverseMap();
            CreateMap<ProductVM,AddProductCommand>().ReverseMap();
            CreateMap<EditProductVM, EditProductCommand>().ReverseMap();
            CreateMap<ProductDetailsDto, EditProductVM>()
              .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ProductImages.Select(img => img.ImageUrl).ToList()))
              .ReverseMap();
            CreateMap<ProductDetailsDto, ProductVM>()
               .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ProductImages.Select(img => img.ImageUrl).ToList()))
               .ReverseMap();

            CreateMap<ProductHomeDto, ProductVMHome>()
               .ForMember(dest => dest.ImgProduct, opt => opt.MapFrom(src => src.ImgUrl))
                .ReverseMap();


            CreateMap<SizeVM,SizeDto>().ReverseMap();
            CreateMap<ColorVM, ColorDto>()
                           .ForMember(dest => dest.Img, opt => opt.MapFrom(src => src.ImageURL))
                           .ReverseMap();

            CreateMap<RegionVM, RegionDto>()
               .ReverseMap();
            CreateMap<deliveryFee, PaymentDto>()
      .ReverseMap();
        }
    }
}
