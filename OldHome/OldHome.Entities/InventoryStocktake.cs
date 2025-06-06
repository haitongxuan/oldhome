using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    /// <summary>
    /// 库存盘点
    /// </summary>
    public class InventoryStocktake : BaseOrgByEntity
    {
        /// <summary>
        /// 盘点单号
        /// </summary>
        public string StocktakeNumber { get; set; } = string.Empty;

        /// <summary>
        /// 盘点类型
        /// </summary>
        public StocktakeType StocktakeType { get; set; }

        /// <summary>
        /// 盘点日期
        /// </summary>
        public DateOnly StocktakeDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// 盘点范围描述
        /// </summary>
        public string ScopeDescription { get; set; } = string.Empty;

        /// <summary>
        /// 盘点人员
        /// </summary>
        public string StocktakePersons { get; set; } = string.Empty;

        /// <summary>
        /// 监盘人员ID
        /// </summary>
        public int? SupervisorId { get; set; }
        public User? Supervisor { get; set; }

        /// <summary>
        /// 盘点状态
        /// </summary>
        public StocktakeStatus Status { get; set; } = StocktakeStatus.InProgress;

        /// <summary>
        /// 总差异金额
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDifferenceAmount { get; set; } = 0;

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 盘点明细
        /// </summary>
        public List<InventoryStocktakeItem> Items { get; set; } = new List<InventoryStocktakeItem>();
    }
}
