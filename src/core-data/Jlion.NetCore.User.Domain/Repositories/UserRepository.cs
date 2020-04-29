using Jlion.NetCore.User.Domain.Contracts;
using Jlion.NetCore.User.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Overt.Core.Data;
using System;

namespace Jlion.NetCore.User.Domain.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(IConfiguration configuration)
            : base(configuration, "user")
        {
        }

        /// <summary>
        /// 用于根据商户ID来进行分表
        /// </summary>
        public int MerchantId { set; get; }

        public override Func<string> TableNameFunc => () =>
        {
            var tableName = $"{GetMainTableName()}_{MerchantId}";
            return tableName;
        };

        public override Func<string, string> CreateScriptFunc => (tableName) =>
        {
            //MySql
            return "CREATE TABLE `" + tableName + "` (" +
                   "  `UserId` int(11) NOT NULL AUTO_INCREMENT," +
                   "  `UserName` varchar(200) DEFAULT NULL," +
                   "  `Password` varchar(200) DEFAULT NULL," +
                   "  `RealName` varchar(200) DEFAULT NULL," +
                   "  `AddTime` datetime DEFAULT NULL," +
                   "  `MerchantId` int(11) NOT NULL," +
                   "  PRIMARY KEY(`UserId`)" +
                   ") ENGINE = InnoDB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8mb4; ";
        };
    }
}
