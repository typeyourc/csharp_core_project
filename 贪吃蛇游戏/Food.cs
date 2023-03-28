using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 食物类(真食物类)
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

        public bool BeEaten(int x)
        {
            if (x == 2)
            {
                return true;
            }
            else return false;
        }

        public bool BeEaten()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 绘制食物需要的绘制函数
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(gFood.vGrid.x, gFood.vGrid.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("¤");
        }

        public void Draw(int flag, Grid x)
        {
            throw new NotImplementedException();
        }

        public void RandomPos(Player p)
        {
            Random r = new Random();
            while (true)
            {
                int flag = 0;
                int randomIndex = r.Next(0, 646);
                //Map.grids[randomIndex] = new Grid();
                //下面这句一直提示没有实例化，不知为啥
                //下面引用传递改成值传递
                //gFood.vGrid = Map.grids[randomIndex].vGrid;
                gFood.vGrid.x = Map.grids[randomIndex].vGrid.x;
                gFood.vGrid.y = Map.grids[randomIndex].vGrid.y;
                for (int i = 0; i < p.gPlayer.Length; i++)
                {
                    //下面引用传递改成值传递
                    //if (gFood.vGrid == p.gPlayer[i].vGrid)
                    if (gFood.vGrid.x == p.gPlayer[i].vGrid.x && gFood.vGrid.y == p.gPlayer[i].vGrid.y)
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
