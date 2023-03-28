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
        //单个空的格子
        //public EmptyGrid[] emptyGrid = new EmptyGrid[1];
        public EmptyGrid emptyGrid = new EmptyGrid();
        //单个格子-表示移动后的头部
        public Grid nextHeadGrid = new Grid();
        //单个格子-表示移动前的尾部
        public Grid lastTailGrid = new Grid();

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
        /// <summary>
        /// 最开始绘制玩家需要的绘制函数
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(gPlayer[0].vGrid.x, gPlayer[0].vGrid.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("●");
        }
        /// <summary>
        /// 移动情况下绘制玩家需要的绘制函数
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="x"></param>
        public void Draw(int flag, Grid x)
        {
            for (int i = 0; i < gPlayer.Length; i++)
            {
                Console.SetCursorPosition(gPlayer[i].vGrid.x, gPlayer[i].vGrid.y);
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("●");
                }
                //这句else if主要是用来在身体移动之后(注意吃食物的那种情况除外)清除尾巴的显示(注意在吃掉食物的时候尾巴是不会清除的)
                else if (i == gPlayer.Length - 1)
                {
                    //这个if感觉不会成立
                    //if (gPlayer.Length == 2 && flag != 1)
                    //{
                    //    break;
                    //}
                    //如果吃到食物，直接break，尾巴不用清除
                    if (flag == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(x.vGrid.x, x.vGrid.y);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                    }
                    //Console.ForegroundColor = ConsoleColor.Black;
                    //Console.Write("  ");
                    //下面这句引用传递改成值传递，这句要达成的目的是让虚拟索引等于最后一个实体索引坐标，好像没必要了，前面已经完成了
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
        public bool Eat(Food xFood, Grid x)
        {
            //下面这句引用传递改成值传递
            //if (gPlayer[0].vGrid == xFood.gFood.vGrid)
            //下面这句改成用nextHeadGrid判断
            //if (gPlayer[0].vGrid.x == xFood.gFood.vGrid.x && gPlayer[0].vGrid.y == xFood.gFood.vGrid.y)
            if (x.vGrid.x == xFood.gFood.vGrid.x && x.vGrid.y == xFood.gFood.vGrid.y)
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// 玩家没吃食物移动后身体变化
        /// </summary>
        public void Grow(EmptyGrid emptyGrid, Grid x)
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
                    //下面的赋值时错误的，grid[0]的值应该是新位置的值，而新位置存储在nextHeadGird中，需要引入参数
                    //grids[0].vGrid.x = emptyGrid.gEmpty.vGrid.x;
                    //grids[0].vGrid.y = emptyGrid.gEmpty.vGrid.y;
                    grids[0].vGrid.x = x.vGrid.x;
                    grids[0].vGrid.y = x.vGrid.y;
                    //grids[0].typeOfGrid = E_TypeOfGrid.Head;
                }
                //下面这个else if应该不需要了
                //else if (i == grids.Length - 1)
                //{
                //    //下面这句引用传递改成值传递
                //    //grids[i].vGrid = gPlayer[i].vGrid;
                //    grids[i].vGrid.x = gPlayer[i].vGrid.x;
                //    grids[i].vGrid.y = gPlayer[i].vGrid.y;
                //    //grids[i].typeOfGrid = E_TypeOfGrid.Empty;
                //}
                else
                {
                    //grids[i].vGrid = gPlayer[i - 1].vGrid;
                    //grids[i].typeOfGrid = E_TypeOfGrid.Body;
                    //下面这句引用传递改成值传递
                    //grids[i].vGrid = gPlayer[i - 1].vGrid;
                    grids[i].vGrid.x = gPlayer[i - 1].vGrid.x;
                    grids[i].vGrid.y = gPlayer[i - 1].vGrid.y;
                    //grids[i].typeOfGrid = E_TypeOfGrid.Body;
                }               
            }
            for (int i = 0; i < grids.Length; i++)
            {
                if (i == 0)
                {
                    grids[i].typeOfGrid = E_TypeOfGrid.Head;
                }
                else if (i == grids.Length - 1)
                {
                    grids[i].typeOfGrid = E_TypeOfGrid.Body;
                }
                else
                {
                    grids[i].typeOfGrid = E_TypeOfGrid.Empty;
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
                }
                //else if (i == grids.Length - 1) 
                //{
                //    //下面这句引用传递改成值传递
                //    //grids[i].vGrid = food.gFood.vGrid;
                //    grids[i].vGrid.x = food.gFood.vGrid.x;
                //    grids[i].vGrid.y = food.gFood.vGrid.y;
                //    grids[i].typeOfGrid = E_TypeOfGrid.Body;
                //}
                else
                {
                    //下面这句引用传递改成值传递
                    //grids[i].vGrid = gPlayer[i - 1].vGrid;
                    //下面的语句是有问题的，因为在进入grow之前，gPlayer的头部坐标已经发生了变化，这样grids[1]里其实存进的gPlayer[0]其实不是原来的gPlayer[0]，而是新的头部
                    //为了解决这个问题，需要在进入之前的移动后，先做一个副本专门存储变化后的gPlayer，原有gPlayer的数据不变
                    grids[i].vGrid.x = gPlayer[i - 1].vGrid.x;
                    grids[i].vGrid.y = gPlayer[i - 1].vGrid.y;
                }
            }
            //格子属性同一赋值
            for (int i = 0; i < grids.Length; i++)
            {
                if (i == 0)
                {
                    grids[i].typeOfGrid = E_TypeOfGrid.Head;
                }
                else if (i == grids.Length - 1)
                {
                    grids[i].typeOfGrid = E_TypeOfGrid.Empty;
                }
                else
                {
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
        public bool HitWall(Grid x)
        {
            bool flag = false;
            for (int i = 0; i < 114; i++)
            {
                //下面这句引用比骄，改成值比较
                //if (gPlayer[0].vGrid == Wall.gWall[i].vGrid)
                if (x.vGrid.x == Wall.gWall[i].vGrid.x && x.vGrid.y == Wall.gWall[i].vGrid.y)
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
        public bool HitYourself(Grid x)
        {
            bool flag = false;
            //下面之所以-2是因为无需跟隐藏的那个数组索引比较
            for (int i = 0; i < gPlayer.Length - 2; i++)
            {
                //下面这句引用比骄，改成值比较
                //if (gPlayer[0].vGrid == gPlayer[i + 1].vGrid)
                if (x.vGrid.x == gPlayer[i + 1].vGrid.x && x.vGrid.y == gPlayer[i + 1].vGrid.y)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public int Move(ref E_Scene sceneID, Food xFood)
        {
            //下一个发生撞墙或者撞到自身的标志0表示没有撞到，1表示撞到
            int flag1;
            //下一个吃食物的标志，吃到是2，没吃到是0
            int flag2;
            //移动到下一个空的标志，2是移动到，0是没有
            int flag3;
            while (true)
            {
                flag1 = 0;
                flag2 = 0;
                flag3 = 0;
                //下面的语句放到Player类成员变量处
                //EmptyGrid emptyGrid = new EmptyGrid();
                //Grid nextHeadGrid = new Grid();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        //下面这句会影响到grow里面的头部赋值，所以改成用headGrid来单独存移动后头部的位置
                        //gPlayer[0].vGrid.x -= 2;
                        //用nextHeadGrid来单独存移动后头部的位置
                        nextHeadGrid.vGrid.x = gPlayer[0].vGrid.x - 2;
                        nextHeadGrid.vGrid.y = gPlayer[0].vGrid.y;
                        //用lastTailGrid来单独存移动前的尾巴位置
                        lastTailGrid.vGrid.x = gPlayer[gPlayer.Length - 1].vGrid.x;
                        lastTailGrid.vGrid.y = gPlayer[gPlayer.Length - 1].vGrid.y;
                        //下面这句是引用传递，改成值传递，用单个空格子来存储异动前头部的位置
                        //emptyGrid.gEmpty.vGrid = gPlayer[0].vGrid;
                        emptyGrid.gEmpty.vGrid.x = gPlayer[0].vGrid.x;
                        emptyGrid.gEmpty.vGrid.y = gPlayer[0].vGrid.y;
                        if (HitWall(nextHeadGrid) || HitYourself(nextHeadGrid))
                        {
                            sceneID = E_Scene.EndScene;
                            flag1 = 1;
                        }
                        else if (Eat(xFood, nextHeadGrid))
                        {
                            flag2 = 2;
                            Grow(xFood);
                            Draw(flag2, lastTailGrid);
                        }
                        else
                        {
                            flag3 = 3;
                            Grow(emptyGrid, nextHeadGrid);
                            Draw(flag3, lastTailGrid);
                            break;
                        }
                        break;
                    case ConsoleKey.S:
                        //gPlayer[0].vGrid.y += 1;
                        //用nextHeadGrid来单独存移动后头部的位置
                        nextHeadGrid.vGrid.x = gPlayer[0].vGrid.x;
                        nextHeadGrid.vGrid.y = gPlayer[0].vGrid.y + 1;
                        //用lastTailGrid来单独存移动前的尾巴位置
                        lastTailGrid.vGrid.x = gPlayer[gPlayer.Length - 1].vGrid.x;
                        lastTailGrid.vGrid.y = gPlayer[gPlayer.Length - 1].vGrid.y;
                        //下面这句是引用传递，改成值传递，用单个空格子来存储异动前头部的位置
                        emptyGrid.gEmpty.vGrid.x = gPlayer[0].vGrid.x;
                        emptyGrid.gEmpty.vGrid.y = gPlayer[0].vGrid.y;
                        if (HitWall(nextHeadGrid) || HitYourself(nextHeadGrid))
                        {
                            sceneID = E_Scene.EndScene;
                            flag1 = 1;
                        }
                        else if (Eat(xFood, nextHeadGrid))
                        {
                            flag2 = 2;
                            Grow(xFood);
                            Draw(flag2, lastTailGrid);
                        }
                        else
                        {
                            flag3 = 3;
                            Grow(emptyGrid, nextHeadGrid);
                            Draw(flag3, lastTailGrid);
                            break;
                        }
                        break;
                    case ConsoleKey.D:
                        //gPlayer[0].vGrid.x += 2;
                        //用nextHeadGrid来单独存移动后头部的位置
                        nextHeadGrid.vGrid.x = gPlayer[0].vGrid.x + 2;
                        nextHeadGrid.vGrid.y = gPlayer[0].vGrid.y;
                        //用lastTailGrid来单独存移动前的尾巴位置
                        lastTailGrid.vGrid.x = gPlayer[gPlayer.Length - 1].vGrid.x;
                        lastTailGrid.vGrid.y = gPlayer[gPlayer.Length - 1].vGrid.y;
                        //下面这句是引用传递，改成值传递，用单个空格子来存储异动前头部的位置
                        emptyGrid.gEmpty.vGrid.x = gPlayer[0].vGrid.x;
                        emptyGrid.gEmpty.vGrid.y = gPlayer[0].vGrid.y;
                        if (HitWall(nextHeadGrid) || HitYourself(nextHeadGrid))
                        {
                            sceneID = E_Scene.EndScene;
                            flag1 = 1;
                        }
                        else if (Eat(xFood, nextHeadGrid))
                        {
                            flag2 = 2;
                            Grow(xFood);
                            Draw(flag2, lastTailGrid);
                        }
                        else
                        {
                            flag3 = 3;
                            Grow(emptyGrid, nextHeadGrid);
                            Draw(flag3, lastTailGrid);
                            break;
                        }
                        break;
                    case ConsoleKey.W:
                        //gPlayer[0].vGrid.y -= 1;
                        //用nextHeadGrid来单独存移动后头部的位置
                        nextHeadGrid.vGrid.x = gPlayer[0].vGrid.x;
                        nextHeadGrid.vGrid.y = gPlayer[0].vGrid.y - 1;
                        //用lastTailGrid来单独存移动前的尾巴位置
                        lastTailGrid.vGrid.x = gPlayer[gPlayer.Length - 1].vGrid.x;
                        lastTailGrid.vGrid.y = gPlayer[gPlayer.Length - 1].vGrid.y;
                        //下面这句是引用传递，改成值传递，用单个空格子来存储异动前头部的位置
                        emptyGrid.gEmpty.vGrid.x = gPlayer[0].vGrid.x;
                        emptyGrid.gEmpty.vGrid.y = gPlayer[0].vGrid.y;
                        if (HitWall(nextHeadGrid) || HitYourself(nextHeadGrid))
                        {
                            sceneID = E_Scene.EndScene;
                            flag1 = 1;
                        }
                        else if (Eat(xFood, nextHeadGrid))
                        {
                            flag2 = 2;
                            Grow(xFood);
                            Draw(flag2, lastTailGrid);
                        }
                        else
                        {
                            flag3 = 3;
                            Grow(emptyGrid, nextHeadGrid);
                            Draw(flag3, lastTailGrid);
                            break;
                        }
                        break;
                }
                if (flag1 == 1 || flag2 == 2 || flag3 == 3)
                {
                    break;
                }
            }
            if (flag1 == 1)
            {
                return flag1;
            }
            return flag2;
        }

        //private bool Eat(Food food, object xFood)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
