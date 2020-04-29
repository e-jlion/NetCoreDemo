using Jlion.NetCore.User.Application.Constracts;
using Jlion.NetCore.User.Domain.Contracts;
using Jlion.NetCore.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jlion.NetCore.User.Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddAsync(UserEntity entity)
        {
            //用于分表(根据MerchantId 自定义分表则一定需要指定该字段)
            _userRepository.MerchantId = entity.MerchantId;
            return await _userRepository.AddAsync(entity);
        }

        public async Task<UserEntity> GetByIdAsync(int userId, int merchantId, bool isMaster = false)
        {
            _userRepository.MerchantId = merchantId;
            return await _userRepository.GetAsync(item => item.UserId == userId, isMaster: isMaster);
        }
    }
}
