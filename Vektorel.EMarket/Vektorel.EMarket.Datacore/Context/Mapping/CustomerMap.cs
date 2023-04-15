using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class CustomerMap : BaseEntityMap<Customer>
    {
        public CustomerMap()
        {

            ToTable(DbConstants.Customers.Name, DbConstants.Customers.Schema);

            HasKey(x => x.Id);

            HasRequired(x => x.User)
                .WithOptional();

            Property(x => x.Balance)
               .HasColumnType("money")
               .IsRequired();

            Property(x => x.Debit)
               .HasColumnType("money")
               .IsRequired();

            Property(x => x.Credit)
               .HasColumnType("money")
               .IsRequired();

            HasMany(x => x.Addresses)
                .WithRequired(x => x.Customer)
                .HasForeignKey(x => x.CustomerKey)
                .WillCascadeOnDelete(false);

        }
    }
}
