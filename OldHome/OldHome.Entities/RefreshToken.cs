using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    /// <summary>
    /// 刷新令牌实体 - 用于管理用户的刷新令牌
    /// </summary>
    public class RefreshToken : BaseEntity
    {
        /// <summary>
        /// 关联的用户ID
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// 令牌值（完整的JWT令牌）
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// JWT ID（唯一标识符）
        /// </summary>
        public string JwtId { get; set; } = string.Empty;

        /// <summary>
        /// 令牌有效期
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// 是否已被撤销
        /// </summary>
        public bool IsRevoked { get; set; } = false;

        /// <summary>
        /// 撤销时间
        /// </summary>
        public DateTime? RevokedAt { get; set; }

        /// <summary>
        /// 撤销原因
        /// </summary>
        public string? RevokeReason { get; set; }

        /// <summary>
        /// 是否已被使用（用于替换）
        /// </summary>
        public bool IsUsed { get; set; } = false;

        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime? UsedAt { get; set; }

        /// <summary>
        /// 客户端信息
        /// </summary>
        public string? ClientInfo { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// 用户代理
        /// </summary>
        public string? UserAgent { get; set; }

        /// <summary>
        /// 检查令牌是否有效
        /// </summary>
        public bool IsValid => !IsRevoked && !IsUsed && ExpiresAt > DateTime.UtcNow;
    }
}
