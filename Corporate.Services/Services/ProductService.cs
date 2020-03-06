using Corporate.Data.Context;
using Corporate.Domain.Entities;
using Corporate.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Services.Services
{
    public class ProductService : EFRepository<Product>, IProductService
    {
        public ProductService(CorporateDb corporateDb) : base(corporateDb)
        {

        }

    }
}
