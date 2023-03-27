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
        //空的格子
        public EmptyGrid[] emptyGrid = new EmptyGrid[1];
        //构造函数格子集合数组初始化
        public Player()
        {
            //一开始有2个索引
            gPlayer = new Grid[2];
            //数组索引0和1位置存着一个实例化的格子
            gPlayer[0] = new Grid();
            gPlayer[1] = new Grid();
            //索引0用来存头部，索引1用来一个空
            gPlayer[0].typeOfGrid = E_TypeOfGrid.Head;
            gPlayer[1].typeOfGrid = E_TypeOfGrid.Empty;
            //索引0和1存的格子坐标都是(20,10)
            gPlayer[0].vGrid.x = 20;
            gPlayer[0].vGrid.y = 10;
            gPlayer[1].vGrid.x = 20;
            gPlayer[1].vGrid.y = 10;
        }

        public void Draw(int flag)
        {
            for (int i = 0; i < gPlayer.Length; i++)
            {
                Console.SetCursorPosition(gPlayer[i].vGrid.x, gPlayer[i].vGrid.y);
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("●");
                }
                else if (i == gPlayer.Length - 1)
                {
                    if (gPlayer.Length == 2 && flag != 1)
                    {
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                    //下面这句引用传递改成值传递
                    //gPlayer[gPlayer.Length - 1].vGrid = gPlayer[gPlayer.Length - 2].vGrid;
                    gPlayer[gPlayer.Length - 1].vGrid.x = gPlayer[gPlayer.Length - 2].vGrid.x;
                    gPlayer[gPlayer.Length - 1].vGrid.y = gPlayer[gPlayer.Length - 2].vGrid.y;
                    break;
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
            //下面这句引用传递改成值传递
            //if (gPlayer[0].vGrid == xFood.gFood.vGrid)
            if (gPlayer[0].vGrid.x == xFood.gFood.vGrid.x && gPlayer[0].vGrid.y == xFood.gFood.vGrid.y)
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// 玩家没吃食物移动后身体变化
        /// </summary>
        public void Grow(EmptyGrid emptyGrid)
        {
            //声明跟原来等长的数组
            Grid[] grids = new Grid[gPlayer.Length];
            //将原有数组的元素复制到新数组中，将头部存进新数组
            for (int i = 0; i < grids.Length; i++)
            {
                grids[i] = new Grid();
                //测试：下面这句用来测试是否需要实例化
                grids[i].vGrid = new Vector();
                if (i == 0)
                {
                    //下面这句引用传递改成值传递
                    //grids[0].vGrid = emptyGrid.gEmpty.vGrid;
                    grids[0].vGrid.x = emptyGrid.gEmpty.vGrid.x;
                    grids[0].vGrid.y = emptyGrid.gEmpty.vGrid.y;
                    grids[0].typeOfGrid = E_TypeOfGrid.Head;
                }
                else if (i == grids.Length - 1)
                {
                    //下面这句引用传递改成值传递
                    //grids[i].vGrid = gPlayer[i].vGrid;
                    grids[i].vGrid.x = gPlayer[i].vGrid.x;
                    grids[i].vGrid.y = gPlayer[i].vGrid.y;
                    grids[i].typeOfGrid = E_TypeOfGrid.Empty;
                }
                else
                {
                    //grids[i].vGrid = gPlayer[i - 1].vGrid;
                    //grids[i].typeOfGrid = E_TypeOfGrid.Body;
                    //下面这句引用传递改成值传递
                    //grids[i].vGrid = gPlayer[i - 1].vGrid;
                    grids[i].vGrid.x = gPlayer[i - 1].vGrid.x;
                    grids[i].vGrid.y = gPlayer[i - 1].vGrid.y;
                    grids[i].typeOfGrid = E_TypeOfGrid.Body;
                }
                
            }
            //将新数组赋值给原有数组
            gPlayer = grids;
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
                grids[i] = new Grid();
                //测试：下面这句用来测试是否需要实例化
                grids[i].vGrid = new Vector();
                if (i == 0)
                {
                    //下面这句引用传递改成值传递
                    //grids[i].vGrid = food.gFood.vGrid;
                    grids[i].vGrid.x = food.gFood.vGrid.x;
                    grids[i].vGrid.y = food.gFood.vGrid.y;
                    grids[i].typeOfGrid = E_TypeOfGrid.Head;
                }
                else if (i == 1) 
                {
                    //下面这句引用传递改成值传递
                    //grids[i].vGrid = food.gFood.vGrid;
                    grids[i].vGrid.x = food.gFood.vGrid.x;
                    grids[i].vGrid.y = food.gFood.vGrid.y;
                    grids[i].typeOfGrid = E_TypeOfGrid.Body;
                }
                else
                {
                    //下面这句引用传递改成值传递
                    //grids[i].vGrid = gPlayer[i - 1].vGrid;
                    grids[i].vGrid.x = gPlayer[i - 1].vGrid.x;
                    grids[i].vGrid.y = gPlayer[i - 1].vGrid.y;
                    grids[i].typeOfGrid = gPlayer[i - 1].typeOfGrid;
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
                //下面这句引用比骄，改成值比较
                //if (gPlayer[0].vGrid == Wall.gWall[i].vGrid)
                if (gPlayer[0].vGrid.x == Wall.gWall[i].vGrid.x && gPlayer[0].vGrid.y == Wall.gWall[i].vGrid.y)
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
                //下面这句引用比骄，改成值比较
                //if (gPlayer[0].vGrid == gPlayer[i + 1].vGrid)
                if (gPlayer[0].vGrid.x == gPlayer[i + 1].vGrid.x && gPlayer[0].vGrid.y == gPlayer[i + 1].vGrid.y)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public void Move(ref E_Scene sceneID, Food xFood)
        {
            //下一个发生撞墙或者撞到自身的标志0表示没有撞到，1表示撞到
            int flag1;
            //下一个吃食物的标志，吃到是1，没吃到是0
            int flag2;
            //移动到下一个空的标志，1是移动到，0是没有
            int flag3;
            while (true)
            {
                flag1 = 0;
                flag2 = 0;
                flag3 = 0;
                EmptyGrid emptyGrid = new EmptyGrid();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        gPlayer[0].vGrid.x -= 2;
                        //下面这句是引用传递，改成值传递
                        //emptyGrid.gEmpty.vGrid = gPlayer[0].vGrid;
                        emptyGrid.gEmpty.vGrid.x = gPlayer[0].vGrid.x;
                        emptyGrid.gEmpty.vGrid.y = gPlayer[0].vGrid.y;
                        if (HitWall() || HitYourself())
                        {
                            sceneID = E_Scene.EndScene;
                            flag1 = 1;
                        }
                        else if(Eat(xFood))
                        {
                            flag2 = 1;
                            Grow(xFood);
                            Draw(0);
                        }
                        else
                        {
                            flag3 = 1;
                            Grow(emptyGrid);
                            Draw(flag3);
                            break;
                        }
                        break;
                    case ConsoleKey.S:
                        gPlayer[0].vGrid.y += 1;
                        if (HitWall() || HitYourself())
                        {
                            sceneID = E_Scene.EndScene;
                            flag1 = 1;
                        }
                        else if (Eat(xFood))
                        {
                            flag2 = 1;
                            Grow(xFood);
                            Draw(0);
                        }
                        else
                        {
                            flag3 = 1;
                            Draw(flag3);
                            break;
                        }
                        break;
                    case ConsoleKey.D:
                        gPlayer[0].vGrid.x += 2;
                        if (HitWall() || HitYourself())
                        {
                            sceneID = E_Scene.EndScene;
                            flag1 = 1;
                        }
                        else if (Eat(xFood))
                        {
                            flag2 = 1;
                            Grow(xFood);
                            Draw(0);
                        }
                        else
                        {
                            flag3 = 1;
                            Draw(flag3);
                            break;
                        }
                        break;
                    case ConsoleKey.W:
                        gPlayer[0].vGrid.y -= 1;
                        if (HitWall() || HitYourself())
                        {
                            sceneID = E_Scene.EndScene;
                            flag1 = 1;
                        }
                        else if (Eat(xFood))
                        {
                            flag2 = 1;
                            Grow(xFood);
                            Draw(0);
                        }
                        else
                        {
                            flag3 = 1;
                            Draw(flag3);
                            break;
                        }
                        break;
                }
                if (flag1 == 1 || flag2 == 1 || flag3 == 1)
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
