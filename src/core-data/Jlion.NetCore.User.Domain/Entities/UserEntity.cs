using Overt.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Jlion.NetCore.User.Domain.Entities
{
    /// <summary>
    /// 标注数据库对于的表名
    /// </summary>
    [Table("User")]
    public class UserEntity
    {
        /// <summary>
        /// 主键ID,标注自增ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        [Submeter(Bit =2)]
        public int MerchantId { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }

}
