using Decorator.Component;

namespace Decorator.Decorators
{
    // Decorator Base
    public abstract class NotifierDecorator : INotifier
    {
        protected INotifier Wrappee;

        public NotifierDecorator(INotifier notifier)
        {
            Wrappee = notifier;
        }

        public virtual void Send(string message)
        {
            Wrappee.Send(message);
        }
    }
}
