using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }

        public decimal OrderTotal { get; set; }


        public Guid CustomerKey { get; set; }

        public Customer Customer { get; set; }

        public OrderStatus Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
