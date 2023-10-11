using Aki.Common.Http;
using Comfort.Common;
using EFT;
using EFT.UI;
using Newtonsoft.Json;

namespace TarkovTools.Core
{
    internal static class Utils
    {
        // Display the players position to the ingame console
        public static void GetPlayerPosition()
        {
            if (!Singleton<GameWorld>.Instance.MainPlayer)
            {
                ConsoleScreen.Log("-----------------------------------------------------------------");
                ConsoleScreen.Log("Player is null, or you are not ingame.");
                ConsoleScreen.Log("-----------------------------------------------------------------");
                return;
            }

            var position = Singleton<GameWorld>.Instance.MainPlayer.Position;
            ConsoleScreen.Log("-----------------------------------------------------------------");
            ConsoleScreen.Log($"Player Position X: {position.x} Y: {position.y} Z: {position.z}");
            ConsoleScreen.Log("-----------------------------------------------------------------");
        }

        // Get json from the server using a specificed route
        public static T Get<T>(string url)
        {
            var req = RequestHandler.GetJson(url);
            return JsonConvert.DeserializeObject<T>(req);
        }
    }
}
