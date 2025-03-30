using Builder.Builders;

namespace Builder
{
    public class Director
    {
        private IBuilder _builder;

        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        // Allows changing the builder dynamically
        public void ChangeBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        // Constructs a home by calling all builder steps
        public void BuildHome()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }
}
