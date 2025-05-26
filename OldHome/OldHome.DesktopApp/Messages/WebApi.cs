using OldHome.DTO.Base;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OldHome.DesktopApp.Messages
{
    public class WebApi : BaseMessage
    {
        #region Auth
        public async Task<BaseResponse<SignInResponse>?> SignIn(int orgId, string username, string password)
        {
            var response = await _apiClient.PostAsync<SignInRequset, SignInResponse>("login", new SignInRequset(orgId, username, password));
            return response;
        }

        public async Task<BaseResponse<ProfileResponse>?> GetProfile()
        {
            var response = await _apiClient.GetAsync<ProfileResponse>("profile");
            return response;
        }

        public async Task<BaseResponse<string>?> SecureData()
        {
            var response = await _apiClient.GetAsync<string>("secure-data");
            return response;
        }
        #endregion

        #region User
        public async Task<BaseResponse<List<UserDto>>> GetAllUsers()
        {
            var response = await _apiClient.GetAsync<List<UserDto>>("users");
            return response;
        }

        public async Task<BaseResponse<PagedResult<UserDto>>> GetPagedUsers(int pageIndex, int pageSize)
        {
            var response = await _apiClient.GetAsync<PagedResult<UserDto>>($"users/paged?pageIndex={pageIndex}&pageSize={pageSize}");
            return response;
        }

        public async Task<BaseResponse<UserDto>> CreateUser(UserCreate userCreate)
        {
            var response = await _apiClient.PostAsync<UserCreate, UserDto>("users/create", userCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyUser(UserModify userModify)
        {
            var response = await _apiClient.PostAsync("users/modify", userModify);
            return response;
        }

        public async Task<BaseResponse> DeleteUser(int id)
        {
            var response = await _apiClient.GetAsync($"users/delete?id={id}");
            return response;
        }
        #endregion

        #region Org
        public async Task<BaseResponse<List<OrgDto>>> GetAllOrgs()
        {
            var response = await _apiClient.GetAsync<List<OrgDto>>("orgs");
            return response;
        }

        public async Task<BaseResponse<List<OrgSample>>> GetAllOrgSamples()
        {
            var response = await _apiClient.GetAsync<List<OrgSample>>("orgs/samples");
            return response;
        }

        public async Task<BaseResponse<OrgDto>> CreateOrg(OrgCreate orgCreate)
        {
            var response = await _apiClient.PostAsync<OrgCreate, OrgDto>("orgs/create", orgCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyOrg(OrgModify orgModify)
        {
            var response = await _apiClient.PostAsync("orgs/modify", orgModify);
            return response;
        }

        public async Task<BaseResponse> DeleteOrg(int id)
        {
            var response = await _apiClient.GetAsync($"orgs/delete?id={id}");
            return response;
        }

        public async Task<BaseResponse<List<OrgAreaDto>>> GetOrgAreas(int orgId)
        {
            var response = await _apiClient.GetAsync<List<OrgAreaDto>>($"orgs/{orgId}/orgareas");
            return response;
        }
        #endregion

        #region OrgArea
        public async Task<BaseResponse<List<OrgAreaDto>>> GetAllOrgAreas()
        {
            var response = await _apiClient.GetAsync<List<OrgAreaDto>>("orgareas");
            return response;
        }

        public async Task<BaseResponse<List<OrgAreaSample>>> GetAllOrgAreaSamples()
        {
            var response = await _apiClient.GetAsync<List<OrgAreaSample>>("orgareas/samples");
            return response;
        }

        public async Task<BaseResponse<OrgAreaDto>> CreateOrgArea(OrgAreaCreate orgCreate)
        {
            var response = await _apiClient.PostAsync<OrgAreaCreate, OrgAreaDto>("orgareas/create", orgCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyOrgArea(OrgAreaModify orgModify)
        {
            var response = await _apiClient.PostAsync("orgareas/modify", orgModify);
            return response;
        }

        public async Task<BaseResponse> DeleteOrgArea(int id)
        {
            var response = await _apiClient.GetAsync($"orgareas/delete?id={id}");
            return response;
        }
        #endregion

        #region Role
        public async Task<BaseResponse<List<RoleDto>>> GetAllRoles()
        {
            var response = await _apiClient.GetAsync<List<RoleDto>>("roles");
            return response;
        }

        public async Task<BaseResponse<List<RoleSample>>> GetAllRoleSamples()
        {
            var response = await _apiClient.GetAsync<List<RoleSample>>("roles/samples");
            return response;
        }

        public async Task<BaseResponse<RoleDto>> CreateRole(RoleCreate roleCreate)
        {
            var response = await _apiClient.PostAsync<RoleCreate, RoleDto>("roles/create", roleCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyRole(RoleModify roleModify)
        {
            var response = await _apiClient.PostAsync("roles/modify", roleModify);
            return response;
        }

        public async Task<BaseResponse> DeleteRole(int id)
        {
            var response = await _apiClient.GetAsync($"roles/delete?id={id}");
            return response;
        }
        #endregion

        #region EmergencyContact
        public async Task<BaseResponse<PagedResult<EmergencyContactDto>>> GetPagedEmergencyContacts(int pageIndex, int pageSize,
            string name = "", string phoneNum = "", string address = "")
        {
            var urlBuilder = new StringBuilder($"emergencycontacts/paged?pageIndex={pageIndex}&pageSize={pageSize}");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append($"&Name_like={name}");
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                urlBuilder.Append($"&PhoneNum_like={phoneNum}");
            }
            if (!string.IsNullOrEmpty(address))
            {
                urlBuilder.Append($"&Address_like={address}");
            }
            var response = await _apiClient.GetAsync<PagedResult<EmergencyContactDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<List<EmergencyContactSample>>> GetTop10EmergencyContactSamples(string name, string phoneNum)
        {
            var urlBuilder = new StringBuilder($"emergencycontacts/top10samples");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append($"&Name_like={name}");
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                urlBuilder.Append($"&PhoneNum_like={phoneNum}");
            }
            var response = await _apiClient.GetAsync<List<EmergencyContactSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<EmergencyContactDto>> CreateEmergencyContact(EmergencyContactCreate emergencyContactCreate)
        {
            var response = await _apiClient.PostAsync<EmergencyContactCreate, EmergencyContactDto>("emergencycontacts/create", emergencyContactCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyEmergencyContact(EmergencyContactModify emergencyContactModify)
        {
            var response = await _apiClient.PostAsync("emergencycontacts/modify", emergencyContactModify);
            return response;
        }

        public async Task<BaseResponse> DeleteEmergencyContact(int id)
        {
            var response = await _apiClient.GetAsync($"emergencycontacts/delete?id={id}");
            return response;
        }
        #endregion

        #region Staff
        public async Task<BaseResponse<PagedResult<StaffDto>>> GetPagedStaffs(int pageIndex, int pageSize, string name = "", string phoneNum = "", int? deptId = null)
        {
            var urlBuilder = new StringBuilder($"staffs/paged?pageIndex={pageIndex}&pageSize={pageSize}");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append($"&Name_like={name}");
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                urlBuilder.Append($"&PhoneNumber_like={phoneNum}");
            }
            if (deptId is not null)
                urlBuilder.Append($"&DepartmentId_eq={deptId}");
            var response = await _apiClient.GetAsync<PagedResult<StaffDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<StaffDto>> CreateStaff(StaffCreateDto staffCreate)
        {
            var response = await _apiClient.PostAsync<StaffCreateDto, StaffDto>("staffs/create", staffCreate);
            return response;
        }

        public async Task<BaseResponse> ModifyStaff(StaffModifyDto staffModify)
        {
            var response = await _apiClient.PostAsync("staffs/modify", staffModify);
            return response;
        }

        public async Task<BaseResponse<List<StaffSample>>> GetAllStaffSamples()
        {
            var response = await _apiClient.GetAsync<List<StaffSample>>("staffs/samples");
            return response;
        }

        public async Task<BaseResponse<List<StaffSample>>> GetTop10StaffSamples(string name, string phoneNum)
        {
            var urlBuilder = new StringBuilder($"staffs/top10samples");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append($"&Name_like={name}");
            }
            if (!string.IsNullOrEmpty(phoneNum))
            {
                urlBuilder.Append($"&PhoneNumber_like={phoneNum}");
            }
            var response = await _apiClient.GetAsync<List<StaffSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteStaff(int id)
        {
            var response = await _apiClient.GetAsync($"staffs/delete?id={id}");
            return response;
        }
        #endregion

        #region Department

        public async Task<BaseResponse<List<DepartmentDto>>> GetAllDepartments()
        {
            var response = await _apiClient.GetAsync<List<DepartmentDto>>("departments");
            return response;
        }

        public async Task<BaseResponse<DepartmentDto>> CreateDepartment(DepartmentCreate create)
        {
            var response = await _apiClient.PostAsync<DepartmentCreate, DepartmentDto>("departments/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyDepartment(DepartmentModify modify)
        {
            var response = await _apiClient.PostAsync("departments/modify", modify);
            return response;
        }

        public async Task<BaseResponse<List<DepartmentSample>>> GetAllDepartmentSamples()
        {
            var response = await _apiClient.GetAsync<List<DepartmentSample>>("departments/samples");
            return response;
        }

        public async Task<BaseResponse<List<DepartmentSample>>> GetTop10DepartmentSamples(string name)
        {
            var urlBuilder = new StringBuilder("departments/top10samples");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            var response = await _apiClient.GetAsync<List<DepartmentSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteDepartment(int id)
        {
            var response = await _apiClient.GetAsync("departments/delete?id=" + id);
            return response;
        }


        #endregion

        #region Room

        public async Task<BaseResponse<PagedResult<RoomDto>>> GetPagedRooms(int pageIndex, int pageSize, int? orgAreaId = null, int? floor = null)
        {
            var urlBuilder = new StringBuilder("rooms/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (orgAreaId is not null)
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            if (floor is not null)
                urlBuilder.Append("&Floor_eq=" + floor);
            var response = await _apiClient.GetAsync<PagedResult<RoomDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<RoomDto>> CreateRoom(RoomCreate create)
        {
            var response = await _apiClient.PostAsync<RoomCreate, RoomDto>("rooms/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyRoom(RoomModify modify)
        {
            var response = await _apiClient.PostAsync("rooms/modify", modify);
            return response;
        }

        public async Task<BaseResponse<List<RoomSample>>> GetAllRoomSamples(int? orgAreaId = null, int? floor = null)
        {
            var urlBuilder = new StringBuilder("rooms/samples?index=1");
            if (orgAreaId is not null)
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            if (floor is not null)
                urlBuilder.Append("&Floor_eq=" + floor);
            var response = await _apiClient.GetAsync<List<RoomSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteRoom(int id)
        {
            var response = await _apiClient.GetAsync("rooms/delete?id=" + id);
            return response;
        }

        #endregion

        #region Bed

        public async Task<BaseResponse<PagedResult<BedDto>>> GetPagedBeds(int pageIndex, int pageSize, int? orgAreaId, int? floor, int? roomId = null)
        {
            var urlBuilder = new StringBuilder("beds/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (orgAreaId is not null)
            {
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            }
            if (floor is not null)
            {
                urlBuilder.Append("&Floor_eq=" + floor);
            }
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            var response = await _apiClient.GetAsync<PagedResult<BedDto>>(urlBuilder.ToString());
            return response;
        }


        public async Task<BaseResponse<List<BedDto>>> GetAllBeds(int? orgAreaId, int? floor, int? roomId = null)
        {
            var urlBuilder = new StringBuilder("beds?index=1");
            if (orgAreaId is not null)
            {
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            }
            if (floor is not null)
            {
                urlBuilder.Append("&Floor_eq=" + floor);
            }
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            var response = await _apiClient.GetAsync<List<BedDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<BedDto>> CreateBed(BedCreate create)
        {
            var response = await _apiClient.PostAsync<BedCreate, BedDto>("beds/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyBed(BedModify modify)
        {
            var response = await _apiClient.PostAsync("beds/modify", modify);
            return response;
        }

        public async Task<BaseResponse<List<BedSample>>> GetAllBedSamples(int? roomId = null)
        {
            var urlBuilder = new StringBuilder("beds/samples?index=1");
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            var response = await _apiClient.GetAsync<List<BedSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<List<BedSample>>> GetTop10BedSamples(string name)
        {
            var urlBuilder = new StringBuilder("beds/top10samples");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            var response = await _apiClient.GetAsync<List<BedSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteBed(int id)
        {
            var response = await _apiClient.GetAsync("beds/delete?id=" + id);
            return response;
        }

        #endregion

        #region Medicine

        public async Task<BaseResponse<PagedResult<MedicineDto>>> GetPagedMedicines(int pageIndex, int pageSize, string name = "", string barcode = "")
        {
            var urlBuilder = new StringBuilder("medicines/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(barcode))
            {
                urlBuilder.Append("&Barcode_like=" + barcode);
            }
            var response = await _apiClient.GetAsync<PagedResult<MedicineDto>>(urlBuilder.ToString());
            return response;
        }


        public async Task<BaseResponse<List<MedicineDto>>> GetAllMedicines()
        {
            var response = await _apiClient.GetAsync<List<MedicineDto>>("medicines");
            return response;
        }

        public async Task<BaseResponse<MedicineDto>> CreateMedicine(MedicineCreate create)
        {
            var response = await _apiClient.PostAsync<MedicineCreate, MedicineDto>("medicines/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyMedicine(MedicineModify modify)
        {
            var response = await _apiClient.PostAsync("medicines/modify", modify);
            return response;
        }

        public async Task<BaseResponse<List<MedicineSample>>> GetAllMedicineSamples(string name = "", string barcode = "")
        {
            var urlBuilder = new StringBuilder("medicines/samples?index=1");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(barcode))
            {
                urlBuilder.Append("&Barcode_like=" + barcode);
            }
            var response = await _apiClient.GetAsync<List<MedicineSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<List<MedicineSample>>> GetTop10MedicineSamples(string name = "", string barcode = "")
        {
            var urlBuilder = new StringBuilder("medicines/top10samples");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(barcode))
            {
                urlBuilder.Append("&Barcode_like=" + barcode);
            }
            var response = await _apiClient.GetAsync<List<MedicineSample>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse> DeleteMedicine(int id)
        {
            var response = await _apiClient.GetAsync("medicines/delete?id=" + id);
            return response;
        }

        #endregion

        #region Resident
        public async Task<BaseResponse<PagedResult<ResidentDto>>> GetPagedResidents(int pageIndex, int pageSize, string name = "",
            int? orgAreaId = null, int? floor = null, int? roomId = null, int? bedId = null)
        {
            var urlBuilder = new StringBuilder("residents/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (orgAreaId is not null)
            {
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            }
            if (floor is not null)
            {
                urlBuilder.Append("&Floor_eq=" + floor);
            }
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            if (bedId is not null)
                urlBuilder.Append("&BedId_eq=" + bedId);
            var response = await _apiClient.GetAsync<PagedResult<ResidentDto>>(urlBuilder.ToString());
            return response;
        }
        public async Task<BaseResponse<List<ResidentDto>>> GetAllResidents(string name = "", string code = "", int? orgAreaId = null, int? floor = null,
            int? roomId = null, int? bedId = null)
        {
            var urlBuilder = new StringBuilder("residents?index=1");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(code))
            {
                urlBuilder.Append("&Code_like=" + code);
            }
            if (orgAreaId is not null)
            {
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            }
            if (floor is not null)
            {
                urlBuilder.Append("&Floor_eq=" + floor);
            }
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            if (bedId is not null)
                urlBuilder.Append("&BedId_eq=" + bedId);
            var response = await _apiClient.GetAsync<List<ResidentDto>>(urlBuilder.ToString());
            return response;
        }
        public async Task<BaseResponse<ResidentDto>> CreateResident(ResidentCreate create)
        {
            var response = await _apiClient.PostAsync<ResidentCreate, ResidentDto>("residents/create", create);
            return response;
        }
        public async Task<BaseResponse> ModifyResident(ResidentModify modify)
        {
            var response = await _apiClient.PostAsync("residents/modify", modify);
            return response;
        }
        public async Task<BaseResponse<List<ResidentSample>>> GetAllResidentSamples(string name = "", string code = "", int? orgAreaId = null, int? floor = null,
            int? roomId = null, int? bedId = null)
        {
            var urlBuilder = new StringBuilder("residents/samples?index=1");
            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append("&Name_like=" + name);
            }
            if (!string.IsNullOrEmpty(code))
            {
                urlBuilder.Append("&Code_like=" + code);
            }
            if (orgAreaId is not null)
            {
                urlBuilder.Append("&OrgAreaId_eq=" + orgAreaId);
            }
            if (floor is not null)
            {
                urlBuilder.Append("&Floor_eq=" + floor);
            }
            if (roomId is not null)
            {
                urlBuilder.Append("&RoomId_eq=" + roomId);
            }
            if (bedId is not null)
                urlBuilder.Append("&BedId_eq=" + bedId);
            var response = await _apiClient.GetAsync<List<ResidentSample>>(urlBuilder.ToString());
            return response;
        }
        public async Task<BaseResponse> DeleteResident(int id)
        {
            var response = await _apiClient.GetAsync("residents/delete?id=" + id);
            return response;
        }
        #endregion

        #region MedicineInventory

        public async Task<BaseResponse<PagedResult<MedicineInventoryDto>>> GetPagedMedicineInventories(int pageIndex, int pageSize,
            string batchNum = "", string residentFilter = "", string medicineFilter = "")
        {
            var urlBuilder = new StringBuilder("medicine-inventories/paged?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            if (!string.IsNullOrEmpty(batchNum))
            {
                urlBuilder.Append("&BatchNumber_like=" + batchNum);
            }
            if (!string.IsNullOrEmpty(residentFilter))
            {
                urlBuilder.Append("&or_ResidentCode_ResidentName_like=" + residentFilter);
            }
            if (!string.IsNullOrEmpty(medicineFilter))
            {
                urlBuilder.Append("&or_MedicineBarcode_MedicineName_like=" + medicineFilter);
            }
            var response = await _apiClient.GetAsync<PagedResult<MedicineInventoryDto>>(urlBuilder.ToString());
            return response;
        }


        public async Task<BaseResponse<List<MedicineInventoryDto>>> GetAllMedicineInventories(string batchNum = "",
            string residentName = "", string residentCode = "", string medicineName = "", string medicineBarcode = "")
        {
            var urlBuilder = new StringBuilder("medicine-inventories?index=1");
            if (!string.IsNullOrEmpty(batchNum))
            {
                urlBuilder.Append("&BatchNumber_like=" + batchNum);
            }
            if (!string.IsNullOrEmpty(residentName))
            {
                urlBuilder.Append("&ResidentName_like=" + residentName);
            }
            if (!string.IsNullOrEmpty(residentCode))
            {
                urlBuilder.Append("&ResidentCode_like=" + residentCode);
            }
            if (!string.IsNullOrEmpty(medicineName))
            {
                urlBuilder.Append("&MedicineName_like=" + medicineName);
            }
            if (!string.IsNullOrEmpty(medicineBarcode))
            {
                urlBuilder.Append("&MedicineBarcode_like=" + medicineBarcode);
            }
            var response = await _apiClient.GetAsync<List<MedicineInventoryDto>>(urlBuilder.ToString());
            return response;
        }

        public async Task<BaseResponse<MedicineInventoryDto>> CreateMedicineInventory(MedicineInventoryCreate create)
        {
            var response = await _apiClient.PostAsync<MedicineInventoryCreate, MedicineInventoryDto>("medicine-inventories/create", create);
            return response;
        }

        public async Task<BaseResponse> ModifyMedicineInventory(MedicineInventoryModify modify)
        {
            var response = await _apiClient.PostAsync("medicine-inventories/modify", modify);
            return response;
        }

        public async Task<BaseResponse> DeleteMedicineInventory(int id)
        {
            var response = await _apiClient.GetAsync("medicine-inventories/delete?id=" + id);
            return response;
        }

        #endregion
    }
}
