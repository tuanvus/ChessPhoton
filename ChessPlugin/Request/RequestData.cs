using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Photon.Hive.Plugin;
using SimpleJSON;
namespace ChessPlugin
{
    class RequestData : Singleton<RequestData>
    {

        public void RequestGet(ICreateGameCallInfo info,IPluginHost PluginHost)
        {
            JSONObject jsname = new JSONObject();
            jsname.Add("name", "Tuan Anh");
            JSONObject jsdata = new JSONObject();
            jsdata.Add("data", jsname);
            PluginHost.LogInfo("Send " + jsdata.ToString());
            var stream = new MemoryStream();
            var data = Encoding.UTF8.GetBytes(jsdata.ToString());
            stream.Write(data, 0, data.Length);

            HttpRequest request = new HttpRequest()
            {
                Callback = OnHttpResponse,
                Url = "http://localhost:3000/api/photon",
                Async = !WebFlags.ShouldSendSync(info.Request.WebFlags),
                UserState = info,
                Method = "GET",
                ContentType = "application/json"
            };
            PluginHost.HttpRequest(request);
            // info.Continue();
            info.Continue();

            //request.Headers.Add(System.Net.HttpRequestHeader.ContentType, "application/json");
            //PluginHost.LogInfo("Data:" + (string)info.Request.Data);
        }

        private void OnHttpResponse(IHttpResponse response, object userState)
        {
        }

    }
}
