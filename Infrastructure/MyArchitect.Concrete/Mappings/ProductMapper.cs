using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyArchitect.Domain.Entities;
using MyArchitect.RequestResponseModels.Product.GetAllProducts;

namespace MyArchitect.Concrete.Mappings
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, GetAllProductDto>().ReverseMap(); 
        }
    }
}
