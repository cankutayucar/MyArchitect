using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArchitect.Domain.Abstraction
{
    public class BaseEntity
    {
        public BaseEntity()
        {
                CreateDate = DateTime.Now;
                LastUpdate = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
