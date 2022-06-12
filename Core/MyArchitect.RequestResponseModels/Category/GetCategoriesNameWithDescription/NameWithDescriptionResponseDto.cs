using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArchitect.RequestResponseModels.Category.GetCategoriesNameWithDescription
{
    public class NameWithDescriptionResponseDto : BaseResponseDto
    {
        public string NameWithDescription { get; set; }
    }
}
