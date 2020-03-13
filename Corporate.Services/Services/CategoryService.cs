﻿using Corporate.Data.Context;
using Corporate.Domain.Entities;
using Corporate.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Services.Services
{
    public class CategoryService : EFRepository<Category> ,ICategoryService
    {
        public CategoryService(CorporateDb corporateDb):base(corporateDb)
        {

        }

    }
}
