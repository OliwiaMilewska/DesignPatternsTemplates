using Decorator.Component;
using Decorator.Decorators;
using Moq;

namespace Decorator.Tests
{
    public class NotifierTests
    {
        [Fact]
        public void BaseNotifier_ShouldSendBasicNotification()
        {
            var output = CaptureConsoleOutput(() =>
            {
                INotifier notifier = new BaseNotifier();
                notifier.Send("Base message");
            });

            Assert.Contains("[Base] Sending SMS notification: Base message", output);
        }

        [Fact]
        public void EmailNotifier_ShouldIncludeEmailMessage()
        {
            var output = CaptureConsoleOutput(() =>
            {
                INotifier notifier = new EmailNotifier(new BaseNotifier());
                notifier.Send("Email message");
            });

            Assert.Contains("[Base] Sending SMS notification: Email message", output);
            Assert.Contains("[Email] Sending email notification: Email message", output);
        }

        [Fact]
        public void SlackAndEmailNotifier_ShouldIncludeBothMessages()
        {
            var output = CaptureConsoleOutput(() =>
            {
                INotifier notifier = new SlackNotifier(new EmailNotifier(new BaseNotifier()));
                notifier.Send("Slack + Email message");
            });

            Assert.Contains("[Base] Sending SMS notification: Slack + Email message", output);
            Assert.Contains("[Email] Sending email notification: Slack + Email message", output);
            Assert.Contains("[Slack] Sending Slack notification: Slack + Email message", output);
        }

        [Fact]
        public void AllNotifiers_ShouldIncludeAllMessages()
        {
            var output = CaptureConsoleOutput(() =>
            {
                INotifier notifier = new FacebookNotifier(
                                        new SlackNotifier(
                                            new EmailNotifier(
                                                new BaseNotifier())));
                notifier.Send("Full message");
            });

            Assert.Contains("[Base] Sending SMS notification: Full message", output);
            Assert.Contains("[Email] Sending email notification: Full message", output);
            Assert.Contains("[Slack] Sending Slack notification: Full message", output);
            Assert.Contains("[Facebook] Sending Facebook notification: Full message", output);
        }

        [Fact]
        public void EmailNotifier_ShouldCallWrappedSend()
        {
            var mock = new Mock<INotifier>();
            var notifier = new EmailNotifier(mock.Object);

            notifier.Send("Test");

            mock.Verify(m => m.Send("Test"), Times.Once);
        }

        // Helper to capture console output
        private string CaptureConsoleOutput(Action action)
        {
            var writer = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(writer);

            action();

            Console.SetOut(originalOut);
            return writer.ToString();
        }
    }
}