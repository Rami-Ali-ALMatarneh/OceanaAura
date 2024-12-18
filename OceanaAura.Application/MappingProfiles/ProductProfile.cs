using AutoMapper;
using OceanaAura.Application.Features.Product.Command.AddProduct;
using OceanaAura.Application.Features.Product.Queries.GetProductByName;
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
        CreateMap<ProductDto,Product>().ReverseMap();
        }
    }
}
