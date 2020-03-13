﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Model.Dtoes
{
    public class CategoryDto
    {
        
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int Order { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public string Metakeword { get; set; }
        public string MetaDescription { get; set; }
    }
}
