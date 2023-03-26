using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 玩家类
    /// </summary>
    internal class Player : IHitWall, IHitYourself, IDraw , IMove, IEat, IGrow
    {
        //玩家所占格子的集合
        public Grid[] gPlayer = new Grid[1];
        //这个集合的默认长度以及
        //构造函数格子集合数组初始化
        public Player()
        {
            //一开始有1个格子
            gPlayer = new Grid[1];
            //这个格子数组索引0位置存着一个实例化的格子
            gPlayer[0] = new Grid();
            //这个格子的类型时头部，因为开始只有头部
            gPlayer[0].typeOfGrid = E_TypeOfGrid.Head;
            //这个格子的坐标是(20,10)
            gPlayer[0].vGrid.x = 20;
            gPlayer[0].vGrid.y = 10;
        }

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
        /// <summary>
        /// 如果玩家头撞到食物则返回真，否则返回假
        /// </summary>
        /// <param name="xFood"></param>
        /// <returns></returns>
        public bool Eat(Food xFood)
        {
            if (gPlayer[0].vGrid == xFood.gFood.vGrid)
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// 玩家吃到食物后身体增长
        /// </summary>
        /// <param name="food"></param>
        public void Grow(Food food)
        {
            //声明比原有数组长度大1的数组
            Grid[] grids = new Grid[gPlayer.Length + 1];
            //将原有数组的元素复制到新数组中，将头部存进新数组
            for (int i = 0; i < grids.Length; i++)
            {
                if (i == 0)
                {
                    grids[i].vGrid = food.gFood.vGrid;
                    grids[i].typeOfGrid = E_TypeOfGrid.Head;
                }
                else
                {
                    grids[i].vGrid = gPlayer[i - 1].vGrid;
                    grids[i].typeOfGrid = E_TypeOfGrid.Body;
                }
            }
            //将新数组赋值给原有数组
            gPlayer = grids;
        }
        /// <summary>
        /// 如果玩家撞到城墙则返回真，否则返回假
        /// </summary>
        /// <returns></returns>
        public bool HitWall()
        {
            bool flag = false;
            for (int i = 0; i < 114; i++)
            {
                if (gPlayer[0].vGrid == Wall.gWall[i].vGrid)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        /// <summary>
        /// 如果玩家撞到自己则返回真，否则返回假
        /// </summary>
        /// <returns></returns>
        public bool HitYourself()
        {
            bool flag = false;
            for (int i = 0; i < gPlayer.Length - 1; i++)
            {
                if (gPlayer[0].vGrid == gPlayer[i + 1].vGrid)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public void Move(ref E_Scene sceneID, Food xFood)
        {
            while (true)
            {
                int flag = 0;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        gPlayer[0].vGrid.x -= 2;
                        if (HitWall() || HitYourself())
                        {
                            sceneID = E_Scene.EndScene;
                            flag = 1;
                        }
                        else if(Eat(xFood))
                        {
                            Grow(xFood);
                            Draw();
                        }
                        else
                        {
                            Draw();
                            break;
                        }
                        break;
                    case ConsoleKey.S:
                        gPlayer[0].vGrid.y += 1;
                        if (HitWall() || HitYourself())
                        {
                            sceneID = E_Scene.EndScene;
                        }
                        else if (Eat(xFood))
                        {
                            Grow(xFood);
                            Draw();
                        }
                        else
                        {
                            Draw();
                            break;
                        }
                        break;
                    case ConsoleKey.D:
                        gPlayer[0].vGrid.x += 2;
                        if (HitWall() || HitYourself())
                        {
                            sceneID = E_Scene.EndScene;
                        }
                        else if (Eat(xFood))
                        {
                            Grow(xFood);
                            Draw();
                        }
                        else
                        {
                            Draw();
                            break;
                        }
                        break;
                    case ConsoleKey.W:
                        gPlayer[0].vGrid.y -= 1;
                        if (HitWall() || HitYourself())
                        {
                            sceneID = E_Scene.EndScene;
                        }
                        else if (Eat(xFood))
                        {
                            Grow(xFood);
                            Draw();
                        }
                        else
                        {
                            Draw();
                            break;
                        }
                        break;
                }
                if (flag == 1)
                {
                    break;
                }
            }
            
        }

        //private bool Eat(Food food, object xFood)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
