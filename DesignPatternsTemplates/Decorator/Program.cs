using Decorator.Component;
using Decorator.Decorators;

INotifier baseNotifier = new BaseNotifier();

INotifier emailNotifier = new EmailNotifier(baseNotifier);

INotifier slackEmailNotifier = new SlackNotifier(emailNotifier);

INotifier fullNotifier = new FacebookNotifier(slackEmailNotifier);


Console.WriteLine("------ SMS + EMIL ------");
emailNotifier.Send("Combined notification");

Console.WriteLine("------ FULL NOTIFICATION ------");
fullNotifier.Send("This is an important alert!");

Console.ReadKey();