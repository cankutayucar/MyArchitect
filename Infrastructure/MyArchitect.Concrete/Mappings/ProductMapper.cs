using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyArchitect.Domain.Entities;
using MyArchitect.RequestResponseModels.Product.CreateProduct;
using MyArchitect.RequestResponseModels.Product.GetAllProducts;
using MyArchitect.RequestResponseModels.Product.UpdateProduct;

namespace MyArchitect.Concrete.Mappings
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, GetAllProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
