using Decorator.Component;

namespace Decorator.Decorators
{
    // Concrete Decorator - Slack
    public class SlackNotifier : NotifierDecorator
    {
        public SlackNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("[Slack] Sending Slack notification: " + message);
        }
    }

}
