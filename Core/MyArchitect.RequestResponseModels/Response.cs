﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArchitect.RequestResponseModels
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }  
    }
}
