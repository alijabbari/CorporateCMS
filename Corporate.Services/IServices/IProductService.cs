using Corporate.Data.Context;
using Corporate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporate.Services.IServices
{
    public interface IProductService :IAsyncRepository<Product>
    {
        
    }
}
