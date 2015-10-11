namespace BalloonsPop.ConsoleUserInterface
{
    using System.IO;

    using GnomInterpreter;
    using GnomUi.Contracts;

    public class GnomViewProvider
    {
        private static GnomController controller;
        private static IGnomTree view;

        public static IGnomTree GetGnomView()
        {
            if (view == null)
            {
                var viewBuilder = ParserProvider.GetGnomConstructor();

                // TODO: Abstract reading this logic
                var uiDescription = File.ReadAllText("../../GnomFiles/index.guid");
                var stylesheet = File.ReadAllText("../../GnomFiles/styles.gss");
                var controlsMap = File.ReadAllText("../../GnomFiles/control-map.gsm");

                view = viewBuilder.Construct(uiDescription, controlsMap, stylesheet);
            }

            return view;
        }

        public static GnomController GetController()
        {
            if (controller == null)
            {
                controller = new GnomController(GetGnomView());
            }

            return controller;
        }
    }
}
