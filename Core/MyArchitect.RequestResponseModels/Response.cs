using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArchitect.RequestResponseModels
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }  
    }
}
