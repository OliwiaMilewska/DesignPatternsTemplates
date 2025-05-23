namespace Composite.Simple
{
    // The base Component class declares common operations for both simple and
    // complex objects of a composition.
    public abstract class Component
    {
        protected string Name;

        public Component(string name)
        {
            Name = name;
        }

        public abstract void Add(Component cmp);

        public abstract void Remove(Component cmp);

        public abstract void Display(int depth);

        /// <summary>
        ///  Method that informs whether a component can bear children
        /// </summary>
        /// <returns>True or false</returns>
        public virtual bool IsComposite()
        {
            return true;
        }
    }
}
