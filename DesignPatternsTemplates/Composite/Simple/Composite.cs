namespace Composite.Simple
{
    public class Composite : Component
    {
        protected List<Component> Children = new List<Component>();

        public Composite(string name) : base(name) { }

        public override void Add(Component cmp)
        {
            Children.Add(cmp);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + Name);

            foreach (Component component in Children)
                component.Display(depth + 2);
        }

        public override void Remove(Component cmp)
        {
           Children.Remove(cmp);
        }
    }
}
