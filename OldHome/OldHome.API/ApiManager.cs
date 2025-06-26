using OldHome.API.Apis;
using OldHome.API.Services;

namespace OldHome.API
{
    public class ApiManager
    {
        private readonly Lazy<AuthApi> _authApi;
        private readonly Lazy<UserApi> _userApi;
        private readonly Lazy<BedApi> _bedApi;
        private readonly Lazy<DepartmentApi> _departmentApi;
        private readonly Lazy<EmergencyContactApi> _emergencyContactApi;
        private readonly Lazy<MedicationOutboundApi> _medicationOutboundApi;
        private readonly Lazy<MedicationPrescriptionApi> _medicationPrescriptionApi;
        private readonly Lazy<MedicineApi> _medicineApi;
        private readonly Lazy<MedicineInventoryApi> _medicineInventoryApi;
        private readonly Lazy<OrgApi> _orgApi;
        private readonly Lazy<OrgAreaApi> _orgAreaApi;
        private readonly Lazy<ResidentApi> _residentApi;
        private readonly Lazy<RoleApi> _roleApi;
        private readonly Lazy<RoomApi> _roomApi;
        private readonly Lazy<StaffApi> _staffApi;



        public ApiManager(IApiClient apiClient)
        {
            _authApi = new Lazy<AuthApi>(() => new AuthApi(apiClient));
            _userApi = new Lazy<UserApi>(() => new UserApi(apiClient));
            _bedApi = new Lazy<BedApi>(() => new BedApi(apiClient));
            _departmentApi = new Lazy<DepartmentApi>(() => new DepartmentApi(apiClient));
            _emergencyContactApi = new Lazy<EmergencyContactApi>(() => new EmergencyContactApi(apiClient));
            _medicationOutboundApi = new Lazy<MedicationOutboundApi>(() => new MedicationOutboundApi(apiClient));
            _medicationPrescriptionApi = new Lazy<MedicationPrescriptionApi>(() => new MedicationPrescriptionApi(apiClient));
            _medicineApi = new Lazy<MedicineApi>(() => new MedicineApi(apiClient));
            _medicineInventoryApi = new Lazy<MedicineInventoryApi>(() => new MedicineInventoryApi(apiClient));
            _orgApi = new Lazy<OrgApi>(() => new OrgApi(apiClient));
            _orgAreaApi = new Lazy<OrgAreaApi>(() => new OrgAreaApi(apiClient));
            _residentApi = new Lazy<ResidentApi>(() => new ResidentApi(apiClient));
            _roleApi = new Lazy<RoleApi>(() => new RoleApi(apiClient));
            _roomApi = new Lazy<RoomApi>(() => new RoomApi(apiClient));
            _staffApi = new Lazy<StaffApi>(() => new StaffApi(apiClient));
        }

        public AuthApi AuthApi => _authApi.Value;
        public UserApi UserApi => _userApi.Value;
        public BedApi BedApi => _bedApi.Value;
        public DepartmentApi DepartmentApi => _departmentApi.Value;
        public EmergencyContactApi EmergencyContactApi => _emergencyContactApi.Value;
        public MedicationOutboundApi MedicationOutboundApi => _medicationOutboundApi.Value;
        public MedicationPrescriptionApi MedicationPrescriptionApi => _medicationPrescriptionApi.Value;
        public MedicineApi MedicineApi => _medicineApi.Value;
        public MedicineInventoryApi MedicineInventoryApi => _medicineInventoryApi.Value;
        public OrgApi OrgApi => _orgApi.Value;
        public OrgAreaApi OrgAreaApi => _orgAreaApi.Value;
        public ResidentApi ResidentApi => _residentApi.Value;
        public RoleApi RoleApi => _roleApi.Value;
        public RoomApi RoomApi => _roomApi.Value;
        public StaffApi StaffApi => _staffApi.Value;
    }
}
