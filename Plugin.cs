using TarkovTools.Patches;
using BepInEx;
using TarkovTools.Core;

namespace TarkovTools
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        Plugin plugin;

        private CommandProcessor _commandProcessor;


        private void Awake()
        {
            plugin = this;
            DontDestroyOnLoad(plugin);
            
            _commandProcessor = new CommandProcessor();
            _commandProcessor.RegisterCommandProcessor();

            new GameWorldPatch().Enable();
        }
    }
}
