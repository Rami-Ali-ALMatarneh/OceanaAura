using AutoMapper;
using OceanaAura.Application.Features.ContactUs.Queries.GetContactUsWithDetails;
using OceanaAura.Application.Features.LookUp.Commands.AddCagegory;
using OceanaAura.Application.Features.LookUp.Commands.Additional;
using OceanaAura.Application.Features.LookUp.Queries.GetAllAdditinalProduct;
using OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories;
using OceanaAura.Application.Features.LookUp.Queries.GetProductCategories;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.MappingProfiles
{
    public class LookUpProfile : Profile
    {
        public LookUpProfile()
        {
            CreateMap<ProductCategoriesDto, LookUpEntity>()
                                  .ForMember(dest => dest.LookUpId, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<CategoryDto, LookUpEntity>()
               .ForMember(dest => dest.LookUpId, opt => opt.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<LookUpEntity, AddProductCategoryCommad>().ReverseMap();


            CreateMap<AdditionalDto, LookUpEntity>()
               .ForMember(dest => dest.LookUpId, opt => opt.MapFrom(src => src.Id)).ReverseMap();

        }
    }
}
