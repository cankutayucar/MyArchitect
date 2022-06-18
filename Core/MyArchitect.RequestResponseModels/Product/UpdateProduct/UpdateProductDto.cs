using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArchitect.RequestResponseModels.Product.UpdateProduct
{
    public class UpdateProductDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int UnitInStock { get; set; }
    }
}
