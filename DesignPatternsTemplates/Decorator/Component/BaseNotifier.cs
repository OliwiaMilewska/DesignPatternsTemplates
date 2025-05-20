namespace Decorator.Component
{
    // Concrete Component
    public class BaseNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("[Base] Sending SMS notification: " + message);
        }
    }
}
