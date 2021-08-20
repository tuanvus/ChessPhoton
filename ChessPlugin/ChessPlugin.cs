using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon.Hive.Plugin;
namespace ChessPlugin
{
    public class ChessPlugin : PluginBase
    {
		public override string Name
		{
			get
			{
				return "MyFirstPlugin";
			}
		}

		public override void BeforeJoin(IBeforeJoinGameCallInfo info)
		{
			info.Continue();
		}

		public override void OnCreateGame(ICreateGameCallInfo info)
		{
			info.Continue();
			//RequestData.Instance.RequestGet(info, PluginHost);

			base.PluginHost.LogInfo(string.Format("OnCreateGame {0} by user {1} actor id {2}", info.Request.GameId, info.UserId, info.Request.ActorNr));
			BoardCtr.Instance.SetUpBoard(base.PluginHost);
		}

		public override void OnJoin(IJoinGameCallInfo info)
		{
			info.Continue();
			base.PluginHost.LogInfo("OnJoinGame");
			base.PluginHost.LogInfo(string.Format("OnCreateGame {0} by user {1} actor id {2}", info.Request.GameId, info.UserId, info.ActorNr));


		}

		public override void OnRaiseEvent(IRaiseEventCallInfo info)
		{
			base.PluginHost.LogInfo("Data :" + ((info != null) ? info.ToString() : null));
            base.BroadcastEvent(1, new Dictionary<byte, object>
            {
                {
                    1,
                    1
                },
                {
                    2,
                    1
                }
            });
            info.Continue();
		}
	}
}

