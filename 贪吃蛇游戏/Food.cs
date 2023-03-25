using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 食物类
    /// </summary>
    internal class Food : IDraw
    {
        public Grid gFood;
        public void Draw()
        {
            Console.SetCursorPosition(gFood.vGrid.x, gFood.vGrid.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("¤");
        }
    }
}
