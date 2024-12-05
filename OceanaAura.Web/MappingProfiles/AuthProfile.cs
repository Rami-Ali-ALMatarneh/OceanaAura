using AutoMapper;
using OceanaAura.Application.Models.Identity.Login;
using OceanaAura.Application.Models.Identity.Password;
using OceanaAura.Application.Models.Identity.UserInfo;
using OceanaAura.Web.Models.Auth;

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


        }
    }
}
