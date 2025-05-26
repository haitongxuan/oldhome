using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.Containers
{
    public class NavigationsContainer : AbstractContainer<Navigation>
    {
    }

    public class NavigationGroup
    {
        public string Group { get; set; } = string.Empty;
        public List<Navigation> Items { get; set; } = new();
    }

    public class Navigation : IElement
    {
        public string Name { get; set; } = string.Empty;
        private string _icon = string.Empty;
        public string Icon { get => char.ConvertFromUtf32(int.Parse(_icon, System.Globalization.NumberStyles.HexNumber)); set => _icon = value; }
        public string Path { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
        public string Group { get; set; } = string.Empty;
        public int Order { get; set; } = 0;
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class NavigationAttribute : Attribute
    {
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

    public static class NavigationScanner
    {
        private static readonly HashSet<Type> _registeredTypes = new();

        public static void RegisterNavigations(IContainerProvider container, Assembly[]? targetAssemblies = null)
        {
            var navigationContainer = container.Resolve<NavigationsContainer>();

            var assemblies = targetAssemblies ?? AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrEmpty(a.FullName))
                .ToArray();

            var typesWithAttribute = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute<NavigationAttribute>() is not null);

            foreach (var type in typesWithAttribute)
            {
                if (_registeredTypes.Contains(type))
                    continue;

                var attr = type.GetCustomAttribute<NavigationAttribute>();
                if (attr != null)
                {
                    navigationContainer.Register(new Navigation
                    {
                        Name = attr.Name,
                        Title = attr.Title,
                        Path = attr.Path,
                        Icon = attr.Icon,
                        IsDefault = attr.IsDefault,
                        Group = attr.Group,
                        Order = attr.Order
                    });

                    _registeredTypes.Add(type);
                }
            }
        }
    }
}