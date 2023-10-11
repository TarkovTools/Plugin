using EFT.UI;

namespace TarkovTools.Core
{
    internal class CommandProcessor
    {
        public void RegisterCommandProcessor()
        {
            // Clear console
            ConsoleScreen.Processor.RegisterCommand("clear",
                delegate () { MonoBehaviourSingleton<PreloaderUI>.Instance.Console.Clear(); });

            ConsoleScreen.Processor.RegisterCommand("GetPosition",
               delegate () { Utils.GetPlayerPosition(); });
        }
    }
}
