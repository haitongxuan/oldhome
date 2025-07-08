namespace OldHome.Wasm.Services
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
}
