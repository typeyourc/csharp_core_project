using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 玩家类
    /// </summary>
    internal class Player : IHitWall, IHitYourself, IDraw
    {
        public Grid[] gPlayer;

        public void Draw()
        {
            for (int i = 0; i < gPlayer.Length; i++)
            {
                Console.SetCursorPosition(gPlayer[i].vGrid.x, gPlayer[i].vGrid.y);
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("●");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("◎");
                }
            }
        }

        public void HitWall()
        {

        }
        public void HitYourself()
        {

        }
    }

}
