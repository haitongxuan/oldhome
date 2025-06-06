using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{ /// <summary>
  /// 家属送药明细
  /// </summary>
    public class FamilyMedicineDeliveryItem : BaseEntity
    {
        /// <summary>
        /// 送药记录ID
        /// </summary>
        public int DeliveryId { get; set; }
        public FamilyMedicineDelivery Delivery { get; set; } = new FamilyMedicineDelivery();

        /// <summary>
        /// 药品ID
        /// </summary>
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = new Medicine();

        /// <summary>
        /// 药品名称（冗余，防止药品信息变更）
        /// </summary>
        public string MedicineName { get; set; } = string.Empty;

        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; } = string.Empty;

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNumber { get; set; } = string.Empty;

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateOnly ProductionDate { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateOnly ExpirationDate { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 包装单位
        /// </summary>
        public MedicinePackageUnit Unit { get; set; } = MedicinePackageUnit.Box;

        /// <summary>
        /// 购买地点
        /// </summary>
        public string? PurchaseLocation { get; set; }

        /// <summary>
        /// 购买价格（可选）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }

        /// <summary>
        /// 验收状态
        /// </summary>
        public CheckStatus CheckStatus { get; set; } = CheckStatus.Pending;

        /// <summary>
        /// 验收备注
        /// </summary>
        public string? CheckNotes { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;
    }
}
