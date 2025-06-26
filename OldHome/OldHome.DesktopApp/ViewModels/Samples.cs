using OldHome.API;
using OldHome.Core;
using OldHome.DTO;
using System.Collections.ObjectModel;

namespace OldHome.DesktopApp.ViewModels
{
    public static class Samples
    {
        public static void LoadFloors(ObservableCollection<int> allFloors, int? orgAreaId, ObservableCollection<OrgAreaSample> orgAreas)
        {
            allFloors.Clear();
            if (orgAreaId == null)
                return;
            var orgArea = orgAreas.FirstOrDefault(x => x.Id == orgAreaId);
            if (orgArea != null)
            {
                for (int i = orgArea.FloorMin; i <= orgArea.FloorMax; i++)
                {
                    allFloors.Add(i);
                }
            }
        }

        public static async void LoadRooms(ObservableCollection<RoomSample> rooms, int? orgAreaId, int? floor, ApiManager api)
        {
            rooms.Clear();
            if (orgAreaId == null || floor == null)
                return;
            {
                var resp = await api.RoomApi.GetAllRoomSamples(orgAreaId, floor);
                if (!resp.IsSuccess)
                {
                    return;
                }
                var roomList = resp.Data!;
                foreach (var room in roomList)
                {
                    rooms.Add(room);
                }
            }
        }

        public static async void LoadOrgAreas(ObservableCollection<OrgAreaSample> allOrgAreas, ApiManager api)
        {
            allOrgAreas.Clear();
            var resp = await api.OrgAreaApi.GetAllOrgAreaSamples();
            if (!resp.IsSuccess)
            {
                return;
            }
            var orgAreaList = resp.Data!;
            foreach (var orgArea in orgAreaList)
            {
                allOrgAreas.Add(orgArea);
            }
        }

        public static void LoadGenders(ObservableCollection<Gender> genders)
        {
            genders.Clear();
            foreach (Gender item in Enum.GetValues(typeof(Gender)))
            {
                genders.Add(item);
            }
        }

        public static async void LoadBeds(ObservableCollection<BedSample> allBeds, int? roomId, ApiManager api)
        {
            allBeds.Clear();
            var resp = await api.BedApi.GetAllBedSamples(roomId);
            if (!resp.IsSuccess)
            {
                return;
            }
            var bedList = resp.Data!;
            foreach (var bed in bedList)
            {
                allBeds.Add(bed);
            }
        }

        public static void LoadHealthStatuses(ObservableCollection<HealthStatus> allHealthStatuses)
        {
            allHealthStatuses.Clear();
            foreach (HealthStatus item in Enum.GetValues(typeof(HealthStatus)))
            {
                allHealthStatuses.Add(item);
            }
        }
    }
}
