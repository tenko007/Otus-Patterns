using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks_Game_Core.GameEntities
{
    public class GameBootstrap
    {
        public void StartGame()
        {
            InitUtils();
            InitData();
        }

        public void InitUtils()
        {
            ErrorHandler.SetHandler(new LogErrorHandler());
        }

        public void InitData()
        {
            GameObject player = new GameObject();
            player.AddComponent(new Transform());
            player.AddComponent(new Tank());
        }
    }
}
