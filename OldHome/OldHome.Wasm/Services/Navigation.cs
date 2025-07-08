using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components.Routing;

namespace OldHome.Wasm.Services
{
    public class Navigation : IElement
    {
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
        public string Group { get; set; } = string.Empty;
        public int Order { get; set; } = 0;

        public MenuDataItem ToMenuDataItem()
        {
            return new MenuDataItem
            {
                Name = Title,
                Key = Name,
                Path = Path,
                Icon = Icon,
                Locale = Title,
                Match = NavLinkMatch.All
            };
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class NavigationAttribute : Attribute
    {
        private string v1;
        private string v2;
        private string v3;

        public NavigationAttribute(string name, string path, string title, string group)
        {
            Name = name;
            Path = path;
            Title = title;
            Group = group;
        }

        public string Name { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Path { get; set; }
        public string Title { get; set; }
        public bool IsDefault { get; set; } = false;
        public string Group { get; set; } = string.Empty;
        public int Order { get; set; } = 0;
    }

    public class NavigationGroup
    {
        public string Group { get; set; } = string.Empty;
        public List<Navigation> Items { get; set; } = new();
    }
}
