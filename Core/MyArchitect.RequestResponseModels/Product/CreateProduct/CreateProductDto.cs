using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyArchitect.Domain.Entities;

namespace MyArchitect.RequestResponseModels.Product.CreateProduct
{
    public class CreateProductDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int UnitInStock { get; set; }
    }
}
