namespace BalloonsPop.ConsoleUserInterface
{
    using System;

    using BalloonsPop.Bundling;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.Core.Contexts;
    using BalloonsPop.GameModels;
    using BalloonsPop.Highscore;
    using BalloonsPop.LogicProvider;
    using BalloonsPop.Saver;
    using BalloonsPop.SoundPlayer;
    using BalloonsPop.Validation;
    using BalloonsPop.Core.Commands;

    using GnomUi;
    using GnomUi.Contracts;
    using GnomUi.Drawing;
    
    using Ninject;

    class Program
    {
        private static void LoadModules(IKernel kernel)
        {
            kernel.Bind<ILogger>().ToMethod(x => LogHelper.GetLogger());

            DependancyBinder.Instance
                .RegisterModules(
                                 new ModelsModule(kernel),
                                 new LogicModule(kernel),
                                 new ValidationModule(kernel),
                                 new HighscoreModule(kernel),
                                 new SaverModule(kernel),
                                 new SoundsModule(kernel),
                                 new CommandModule(kernel),
                                 new GnomModule(kernel))
                .LoadAll();
        }

        static void Main()
        {
            var kernel = new StandardKernel();

            LoadModules(kernel);

            var bundle = new CoreBundle(kernel);
            var ctx = new Context(kernel);
            
            // TODO: introduce a getUserNameCommand
            Console.WriteLine("Who are you?");
            ctx.PlayerName = Console.ReadLine();
            Console.Clear();

            var engine = new GnomEngine(ctx, bundle);

            engine.HandleUserInput("field");

            var view = GnomViewProvider.GetGnomView();
            var app = new GnomApp(view, view["restart"], new ConsoleManipulator(), x =>
            {
                if (x.PressedKeyInfo.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(60, 25);
                    Environment.Exit(42);
                }
                else if (x.PressedKeyInfo.Key == ConsoleKey.Enter)
                {
                    engine.HandleUserInput((x.Target as IElement).Id);
                }
            });

            app.Start();
        }
    }
}
