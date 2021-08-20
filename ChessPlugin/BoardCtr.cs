using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photon.Hive.Plugin;
namespace ChessPlugin
{
    public class BoardCtr : Singleton<BoardCtr> 
    {

        public Vector2[,] boardChess;
        IPluginHost pluginHost;

        Vector2 posStart;
        Vector2 posEnd;
        public void SetUpBoard( IPluginHost plugin)
        {
            pluginHost = plugin;
            posStart = new Vector2(1, 1);
            posEnd = new Vector2(8, 8);
            boardChess = new Vector2[9, 9];
            CreateIndexBoard();
        }
        void CreateIndexBoard()
        {
            float x, y;
            int count = 8;
            for (int i = 1; i <= count; i++)
            {
                x = (Math.Abs((posEnd.x - posStart.x + posStart.x) / count)) * i;
                for (int j = 1; j <= count; j++)
                {
                    y = (Math.Abs((posEnd.y - posStart.y + posStart.y) / count) * j);
                    boardChess[i, j] = new Vector2(x, y);
                    pluginHost.LogInfo(string.Format("X = {0} , Y = {1} ", x, y));
                }
            }
        }


    }


    public class Vector2
    {
        public float x;
        public float y;
        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
    }
}
