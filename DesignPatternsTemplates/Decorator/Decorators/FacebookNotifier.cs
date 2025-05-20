using Decorator.Component;

namespace Decorator.Decorators
{
    // Concrete Decorator - Facebook
    public class FacebookNotifier : NotifierDecorator
    {
        public FacebookNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("[Facebook] Sending Facebook notification: " + message);
        }
    }
}
