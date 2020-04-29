using Jlion.NetCore.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jlion.NetCore.User.Application.Constracts
{
    public interface IUserService
    {
        /// <summary>
        /// 根据userId 获得用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="merchantId">商户ID</param>
        /// <param name="isMaster">是否是主库</param>
        /// <returns></returns>
        Task<UserEntity> GetByIdAsync(int userId, int merchantId, bool isMaster = false);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> AddAsync(UserEntity entity);
    }
}
