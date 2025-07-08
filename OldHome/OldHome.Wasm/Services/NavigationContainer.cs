using System.Reflection;

namespace OldHome.Wasm.Services
{
    public class NavigationContainer : AbstractContainer<Navigation>
    {
    }

    public static class NavigationScanner
    {
        private static readonly HashSet<Type> _registeredTypes = new();

        public static void RegisterNavigations(NavigationContainer container, Assembly[]? targetAssemblies = null)
        {
            var navigationContainer = container;

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
