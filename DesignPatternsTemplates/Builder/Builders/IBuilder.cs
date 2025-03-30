namespace Builder.Builders
{
    // The IBuilder interface defines the construction steps
    public interface IBuilder
    {
        void Reset();
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
        string GetProduct();
    }
}
