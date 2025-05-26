using System.ComponentModel.DataAnnotations;

namespace OldHome.Core
{
    public enum Gender
    {
        [Display(Name = "男")]
        Male,
        [Display(Name = "女")]
        Female,
    }

    public enum HealthStatus
    {
        /// <summary>
        /// 健康型：身体状况良好，生活完全自理
        /// </summary>
        [Display(Name = "健康型", Description = "身体状况良好，生活完全自理")]
        Healthy = 1,

        /// <summary>
        /// 亚健康型：有慢性病但稳定，基本生活自理
        /// </summary>
        [Display(Name = "亚健康型", Description = "有慢性病但稳定，基本生活自理")]
        SubHealthy = 2,

        /// <summary>
        /// 轻度失能：部分自理，部分日常生活需他人协助
        /// </summary>
        [Display(Name = "轻度失能", Description = "部分自理，部分日常生活需他人协助")]
        MildDisability = 3,

        /// <summary>
        /// 中度失能：明显功能障碍，日常生活大多需照护
        /// </summary>
        [Display(Name = "中度失能", Description = "明显功能障碍，日常生活大多需照护")]
        ModerateDisability = 4,

        /// <summary>
        /// 重度失能：完全失能，卧床，需全护理
        /// </summary>
        [Display(Name = "重度失能", Description = "完全失能，卧床，需全护理")]
        SevereDisability = 5,

        /// <summary>
        /// 认知障碍型：如阿尔茨海默病、脑卒中后认知受损
        /// </summary>
        [Display(Name = "认知障碍型", Description = "如阿尔茨海默病、脑卒中后认知受损")]
        CognitiveImpairment = 6
    }

    public enum StaffPosition
    {
        [Display(Name = "护理员")]
        Caregiver,
        [Display(Name = "医生")]
        Doctor,
        [Display(Name = "护士")]
        Nurse,
        [Display(Name = "营养师")]
        Nutritionist,
        [Display(Name = "心理咨询师")]
        Psychologist,
        [Display(Name = "社工")]
        SocialWorker,
        [Display(Name = "生活咨询员")]
        LifeConsultant,
        [Display(Name = "后勤人员")]
        Logistics,
        [Display(Name = "厨师")]
        Cook,
    }

    public enum RoomType
    {
        [Display(Name = "单人间")]
        Single,
        [Display(Name = "双人间")]
        Double,
        [Display(Name = "三人间")]
        Triple,
        [Display(Name = "多人间")]
        Multiple,
    }

    public enum MedicineType
    {
        [Display(Name = "口服")]
        Oral,
        [Display(Name = "注射")]
        Injection,
        [Display(Name = "外用")]
        External,
        [Display(Name = "贴敷")]
        Patch,
        [Display(Name = "吸入")]
        Inhalation,
    }

    public enum MedicinePackageUnit
    {
        [Display(Name = "盒")]
        Box,
        [Display(Name = "瓶")]
        Bottle,
    }

    public enum MedicineUnit
    {
        [Display(Name = "片")]
        Tablet,
        [Display(Name = "支")]
        Stick,
    }

    public enum MedicineInventoryStatus
    {
        [Display(Name = "正常")]
        Normal,
        [Display(Name = "过期")]
        Expired,
        [Display(Name = "即将过期")]
        NearExpiration,
        [Display(Name = "用完")]
        UsedUp,
        [Display(Name = "报废")]
        Scrapped,
    }

    public enum MedicineInventoryType
    {
        [Display(Name = "个人")]
        Personal,
        [Display(Name = "公共")]
        Public,
    }

    public enum MedicineInventoryOperationType
    {
        [Display(Name = "入库")]
        Inbound,
        [Display(Name = "作废")]
        Invalid,
        [Display(Name = "盘点调整")]
        InventoryAdjustment,
        [Display(Name = "发药")]
        Dispense,
        [Display(Name = "退药")]
        Return,
    }

    public enum MedicineAlterType
    {
        [Display(Name = "库存不足")]
        InsufficientStock,
        [Display(Name = "即将过期")]
        NearExpiration,
        [Display(Name = "个人断药")]
        PersonalDiscontinuation,
    }

    public enum NotificationType
    {
        [Display(Name = "未通知")]
        None,
        [Display(Name = "系统通知")]
        System,
        [Display(Name = "企业微信")]
        WeChat,
        [Display(Name = "短信")]
        SMS,
        [Display(Name = "语音电话")]
        VoiceCall,
        [Display(Name = "人工电话")]
        ManualCall,
    }

    public enum MedicineTime
    {
        [Display(Name = "早餐前")]
        BeforeBreakfast,
        [Display(Name = "早上")]
        Morning,
        [Display(Name = "早餐后")]
        AfterBreakfast,
        [Display(Name = "午饭前")]
        BeforeLunch,
        [Display(Name = "中午")]
        Noon,
        [Display(Name = "午饭后")]
        AfterLunch,
        [Display(Name = "晚饭前")]
        BeforeDinner,
        [Display(Name = "晚上")]
        Evening,
        [Display(Name = "晚饭后")]
        AfterDinner,
        [Display(Name = "睡前")]
        BeforeSleep,
    }

    public enum BedStatus
    {
        [Display(Name = "空闲")]
        Free,
        [Display(Name = "占用")]
        Occupied,
        [Display(Name = "维修")]
        Maintenance,
        [Display(Name = "冻结")]
        Frozen,
    }

    public enum CareLevel
    {
        [Display(
            Name = "自理",
            Prompt = "老人生活基本自理，能够独立完成日常活动，无需护理员常规协助。",
            Description = "- 提供安全巡视\r\n- 偶尔提醒、指导（如服药提醒）\r\n- 提供健康监测（血压、血糖常规测量）")]
        SelfCare,
        [Display(
            Name = "半自理",
            Prompt = "老人可完成部分日常活动，但需要适度协助（如穿衣、洗澡、用药管理）。",
            Description = "- 协助穿衣、洗澡、如厕\r\n- 带领参加康复锻炼\r\n- 简单用药管理\r\n- 防跌倒巡视")]
        SemiSelfCare,
        [Display(Name = "全护理",
            Prompt = "老人需要全天候护理，无法独立完成大部分生活动作，需要护理员全程协助。",
            Description = "- 协助饮食、洗漱、如厕、翻身\r\n- 每日生命体征监测\r\n- 规范服药喂药\r\n- 皮肤护理（防止褥疮）")]
        FullCare,
        [Display(Name = "重度护理",
            Prompt = "老人存在重度失能或多种慢性病，需专业护理，包括医疗护理干预。",
            Description = "- 氧疗、吸痰、导尿护理\r\n- 护理床旁吸氧、抽痰等\r\n- 床旁翻身拍背\r\n- 专业伤口护理（压疮、手术创面）")]
        SevereCare,
        [Display(Name = "特级护理",
            Prompt = "老人极度虚弱或患有特殊疾病，需要特护人员1对1或极高频次专业照料。",
            Description = "- 24小时一对一护理\r\n- 监测意识状态\r\n- 持续医学支持（如插管护理）\r\n- 个性化特护方案执行")]
        SpecialCare,
        [Display(Name = "临终关怀",
            Prompt = "老人处于生命末期，重点在于减轻痛苦、保持舒适、尊严地度过最后阶段。",
            Description = "- 镇痛管理（如吗啡贴、镇静药物）\r\n- 舒适护理（清洁、口腔护理）\r\n- 情绪支持（家属陪伴、心理疏导）\r\n- 尊重个体尊严与意愿")]
        EndOfLifeCare,
    }

    public enum ResidentBadChangeType
    {
        [Display(Name = "入住")]
        CheckIn,
        [Display(Name = "换床")]
        ChangeBed,
        [Display(Name = "换房")]
        ChangeRoom,
        [Display(Name = "出院")]
        CheckOut,
    }

    public enum ContactRelationship
    {
        [Display(Name = "配偶")]
        Spouse,
        [Display(Name = "子女")]
        Child,
        [Display(Name = "父母")]
        Parent,
        [Display(Name = "兄弟姐妹")]
        Sibling,
        [Display(Name = "其他亲属")]
        OtherRelative,
        [Display(Name = "朋友")]
        Friend,
        [Display(Name = "其他")]
        Other,
    }

    public enum CaregiverResidentChangeType
    {
        [Display(Name = "老人入住")]
        CheckIn,
        [Display(Name = "老人换床")]
        ChangeBed,
        [Display(Name = "老人换房")]
        ChangeRoom,
        [Display(Name = "老人出院")]
        CheckOut,
        [Display(Name = "老人转院")]
        Transfer,
        [Display(Name = "老人死亡")]
        Death,
        [Display(Name = "护理员离职")]
        CaregiverLeave,
        [Display(Name = "护理员调岗")]
        CaregiverTransfer,
        [Display(Name = "护理员请假")]
        CaregiverLeaveOfAbsence,
        [Display(Name = "护理员回岗")]
        CaregiverReturn,
        [Display(Name = "护理员调班")]
        CaregiverShiftChange,
        [Display(Name = "护理员换岗")]
        CaregiverChangePosition,
        [Display(Name = "护理员换班")]
        CaregiverChangeShift,
        [Display(Name = "护理员换区域")]
        CaregiverChangeArea,
        [Display(Name = "护理员换机构")]
        CaregiverChangeOrg,
    }
}
