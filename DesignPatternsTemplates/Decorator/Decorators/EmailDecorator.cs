using Decorator.Component;

namespace Decorator.Decorators
{
    // Concrete Decorator - Email
    public class EmailNotifier : NotifierDecorator
    {
        public EmailNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("[Email] Sending email notification: " + message);
        }
    }

}
