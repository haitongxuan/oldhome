
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.Containers
{
    public abstract class AbstractContainer<T> where T : IElement
    {
        protected Dictionary<string, T> _container = new Dictionary<string, T>();


        public virtual void Register(T ablity)
        {
            _container.Add(ablity.Name, ablity);
        }

        public virtual bool ContainsKey(string name)
        {
            return _container.ContainsKey(name);
        }

        public virtual List<T> GetAll()
        {
            return _container.Values.ToList();
        }

        public virtual T Get(string name)
        {
            return _container[name];
        }
    }

    public interface IElement
    {
        string Name { get; }
    }
}
