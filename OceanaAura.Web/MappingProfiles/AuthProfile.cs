using AutoMapper;
using OceanaAura.Application.Features.ContactUs.Commands.AddContactUs;
using OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories;
using OceanaAura.Application.Features.Product.Command.AddProduct;
using OceanaAura.Application.Features.Product.Queries.GetProductByName;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Features.ProductSize.Command.AddSize;
using OceanaAura.Application.Models.Identity.Login;
using OceanaAura.Application.Models.Identity.Password;
using OceanaAura.Application.Models.Identity.UserInfo;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Web.Models.Auth;
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
        }
    }
}
