using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corporate.Models
{
    public class PageingDto
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
