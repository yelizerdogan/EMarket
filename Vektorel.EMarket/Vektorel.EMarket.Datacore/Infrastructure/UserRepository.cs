using MAA.Basecore.Data.EntityFramework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Datacore.Context;
using Vektorel.EMarket.Domain.Model.EMarketDb;
using Vektorel.EMarket.Domain.ResultTypes;
using MAA.Basecore.Helpers.Common;
using MAA.Basecore.Model.Enums;
using Vektorel.EMarket.Domain.Constants;

namespace Vektorel.EMarket.Datacore.Infrastructure
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        UserResult Login(string email, string password);
    }


    public class UserRepository : Repository<EMarketDbContext, ApplicationUser>, IUserRepository
    {
        public UserRepository(EMarketDbContext ctx)
            : base(ctx)
        {

        }


        public UserResult Login(string email, string password)
        {
            UserResult result = null;
            try
            {
                var user = Context.Users.SingleOrDefault(u => u.Email == email && u.Password == password.GetMD5Hash());
                if (user == null)
                {
                    result = new UserResult(UserResultType.NotFound, null, "Böyle bir kullanıcı yok", BusinessResultType.Info);
                }
                else
                {
                    if (!user.IsActive)
                    {
                        result = new UserResult(UserResultType.Blocked, user, "Engellenmiş kullanıcı", BusinessResultType.Info);
                    }
                    else if (user.IsDeleted)
                    {
                        result = new UserResult(UserResultType.NotFound, user, "Bu kullanıcı silinmiş", BusinessResultType.Info);
                    }
                    else
                    {
                        result = new UserResult(UserResultType.Authenticated,user, "", BusinessResultType.Success);
                    }
                }

            }
            catch (Exception ex)
            {
                result = new UserResult(UserResultType.UnAuthorized,null, "Hata:"+ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }
    }
}
