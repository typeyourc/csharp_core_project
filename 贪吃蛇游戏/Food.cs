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
    internal class Food : IDraw , IRandomPos, IBeEaten
    {
        //格子类型的成员变量
        public Grid gFood = new Grid();

        //构造函数
        public Food()
        {
            gFood = new Grid();
            gFood.typeOfGrid = E_TypeOfGrid.Food;
            //初始坐标为(10,10)
            gFood.vGrid.x = 10;
            gFood.vGrid.y = 10;
        }

        public void BeEaten()
        {
            
        }

        public void Draw()
        {
            Console.SetCursorPosition(gFood.vGrid.x, gFood.vGrid.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("¤");
        }

        public void RandomPos(Player p)
        {
            Random r = new Random();
            while (true)
            {
                int flag = 0;
                int randomIndex = r.Next(0, 646);
                //Map.grids[randomIndex] = new Grid();
                gFood.vGrid = Map.grids[randomIndex].vGrid;
                for (int i = 0; i < p.gPlayer.Length; i++)
                {
                    if (gFood.vGrid == p.gPlayer[i].vGrid)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    break;
                }
            }

        }
    }
}
