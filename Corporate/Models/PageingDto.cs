﻿using Corporate.Model.Dtoes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate.Models
{

    public class PageingDto
    {

        public int CurrentPage { get; set; } = 1;
        
        public int TotalPages { get; set; }

        public int PageSize { get; set; } = 10;
        
        public int TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;


    }
}
