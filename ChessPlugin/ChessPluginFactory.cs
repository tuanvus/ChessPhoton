using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon.Hive.Plugin;
namespace ChessPlugin
{
    class ChessPluginFactory : IPluginFactory
	{
		public IGamePlugin Create(IPluginHost gameHost, string pluginName, Dictionary<string, string> config, out string errorMsg)
		{
			ChessPlugin plugin = new ChessPlugin();
			bool flag = plugin.SetupInstance(gameHost, config, out errorMsg);
			IGamePlugin result;
			if (flag)
			{
				result = plugin;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
