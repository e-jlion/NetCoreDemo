using Jlion.NetCore.User.Domain.Entities;
using Overt.Core.Data;

namespace Jlion.NetCore.User.Domain.Contracts
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        int MerchantId { set; get; }
    }
}
