using FluentValidation;
using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.Messages;
using OldHome.DesktopApp.Services;
using OldHome.DesktopApp.ViewModels;
using OldHome.DesktopApp.Views;
using OldHome.DesktopApp.Views.Windows;
using System.Net.Http;
using System.Windows;

namespace OldHome.DesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register your types here
            containerRegistry.RegisterSingleton<WebApi>()
                .RegisterSingleton<NavigationsContainer>()
                .RegisterSingleton<IUserSessionService, UserSessionService>()
                .RegisterSingleton<INotificationUIService, NotificationUIService>()
                .RegisterSingleton<IApiClient>(() =>
                {
                    return new ApiClient(new HttpClient()
                    {
                        BaseAddress = new Uri("http://localhost:5185")
                    });
                });

            containerRegistry
                .RegisterScoped<MainWindowViewModel>()
                .RegisterScoped<FormUserViewModel>()
                .RegisterScoped<FormOrgViewModel>()
                .RegisterScoped<FormRoleViewModel>()
                .RegisterScoped<OrgAreaFormViewModel>()
                .RegisterScoped<EmergencyContactFormViewModel>()
                .RegisterScoped<StaffFormViewModel>()
                .RegisterScoped<DepartmentFormViewModel>()
                .RegisterScoped<RoomFormViewModel>()
                .RegisterScoped<BedFormViewModel>()
                .RegisterScoped<MedicineFormViewModel>()
                .RegisterScoped<MedicineInventoryFormViewModel>()
                .RegisterScoped<ResidentFormViewModel>();

            containerRegistry
                .Register<IValidator<FormUserViewModel>, FormUserViewModelValidator>()
                .Register<IValidator<FormOrgViewModel>, FormOrgViewModelValidator>()
                .Register<IValidator<FormRoleViewModel>, FormRoleViewModelValidator>()
                .Register<IValidator<OrgAreaFormViewModel>, OrgAreaFormViewModelValidator>()
                .Register<IValidator<EmergencyContactFormViewModel>, EmergencyContactFormViewModelValidator>()
                .Register<IValidator<StaffFormViewModel>, StaffFormViewModelValidator>()
                .Register<IValidator<DepartmentFormViewModel>, DepartmentFormViewModelValidator>()
                .Register<IValidator<RoomFormViewModel>, RoomFormViewModelValidator>()
                .Register<IValidator<BedFormViewModel>, BedFormViewModelValidator>()
                .Register<IValidator<MedicineFormViewModel>, MedicineFormViewModelValidator>()
                .Register<IValidator<MedicineInventoryFormViewModel>, MedicineInventoryFormViewModelValidator>()
                .Register<IValidator<ResidentFormViewModel>, ResidentFormViewModelValidator>()
                .Register<IValidator<MedicationPrescriptionFormViewModel>, MedicationPrescriptionFormViewModelValidator>()
                .Register<IValidator<MedicationPrescriptionItemDialogViewModel>, MedicationPrescriptionItemDialogViewModelValidator>();

            containerRegistry.RegisterForNavigation<Login, LoginViewModel>("Login");
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<SettingUsers, PagedListUsersViewModel>("SettingUsers");
            containerRegistry.RegisterForNavigation<SettingOrgs, ListOrgsViewModel>("SettingOrgs");
            containerRegistry.RegisterForNavigation<SettingRoles, ListRolesViewModel>("SettingRoles");
            containerRegistry.RegisterForNavigation<OrgAreaList, OrgAreaListViewModel>("SettingOrgAreas");
            containerRegistry.RegisterForNavigation<EmergencyContactPagedList, EmergencyContactPagedListViewModel>("SettingEmergencyContacts");
            containerRegistry.RegisterForNavigation<StaffPagedList, StaffPagedListViewModel>("SettingStaffs");
            containerRegistry.RegisterForNavigation<DepartmentList, DepartmentListViewModel>("SettingDepartments");
            containerRegistry.RegisterForNavigation<RoomPagedList, RoomPagedListViewModel>("SettingRooms");
            containerRegistry.RegisterForNavigation<BedPagedList, BedPagedListViewModel>("SettingBeds");
            containerRegistry.RegisterForNavigation<MedicinePagedList, MedicinePagedListViewModel>("SettingMedicines");
            containerRegistry.RegisterForNavigation<MedicineInventoryPagedList, MedicineInventoryPagedListViewModel>("SettingMedicineInventories");
            containerRegistry.RegisterForNavigation<ResidentPagedList, ResidentPagedListViewModel>("SettingResidents");
            containerRegistry.RegisterForNavigation<MedicationPrescriptionPagedList, MedicationPrescriptionPagedListViewModel>("SettingMedicationPrescriptions");

            containerRegistry.RegisterDialogWindow<CustomDialogWindow>(nameof(CustomDialogWindow));
            containerRegistry.RegisterDialog<MedicationPrescriptionItemDialog, MedicationPrescriptionItemDialogViewModel>("MedicationPrescriptionItemDialog");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // Configure your modules here
        }

        protected override Window CreateShell()
        {
            return this.Container.Resolve<Login>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            NavigationScanner.RegisterNavigations(Container);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Add any startup logic here
        }
    }

}
