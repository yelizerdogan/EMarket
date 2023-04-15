using MAA.Basecore.Data.EntityFramework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Datacore.Context;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Infrastructure
{
    public interface IProductRepository : IRepository<Product>
    {

    }
    public class ProductRepository : Repository<EMarketDbContext,Product>, IProductRepository
    {

        public ProductRepository(EMarketDbContext ctx) : base(ctx)
        {

        }
    }
}
