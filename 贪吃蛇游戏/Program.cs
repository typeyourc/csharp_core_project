using System.Reflection.Metadata.Ecma335;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 游戏三大场景枚举
    /// </summary>
    enum E_Scene
    {
        /// <summary>
        /// 开始场景
        /// </summary>
        BeginScene,
        /// <summary>
        /// 游戏场景
        /// </summary>
        GameScene,
        /// <summary>
        /// 结束场景
        /// </summary>
        EndScene,
    }
    /// <summary>
    /// 格子类型
    /// </summary>
    enum E_TypeOfGrid
    {
        /// <summary>
        /// 玩家头部
        /// </summary>
        Head,
        /// <summary>
        /// 玩家身体
        /// </summary>
        Body,
        /// <summary>
        /// 食物
        /// </summary>
        Food,
        /// <summary>
        /// 城墙
        /// </summary>
        Wall,
        /// <summary>
        /// 空格子
        /// </summary>
        Empty,
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region 一、全局变量配置
            //游戏场景ID，初始赋值为开始场景
            E_Scene sceneID = E_Scene.BeginScene;
            //窗口大小设置
            const int width = 80;
            const int height = 19;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.CursorVisible = false;
            int xPosition = 0;
            int yPosition = 0;
            #endregion

            #region 二、游戏场景循环与切换
            while (true)
            {
                switch (sceneID)
                {
                    case E_Scene.BeginScene:
                        //开始场景
                        DrawBeginEndScene(width, height, new Vector(), ref sceneID);
                        break;
                    case E_Scene.GameScene:
                        //游戏场景-城墙绘制
                        DrawGameSceneWall(width, height, new Vector());
                        ////测试城墙输出
                        //Console.ReadLine();
                        ////测试游戏结束场景
                        //sceneID = E_Scene.EndScene;
                        break;
                    case E_Scene.EndScene:
                        //结束场景
                        DrawBeginEndScene(width, height, new Vector(), ref sceneID);
                        break;
                }
            }
            #endregion
        }
        //开始&结束场景绘制函数
        static void DrawBeginEndScene(int width, int height, Vector vBeginEnd, ref E_Scene sceneID)
        {
            //清屏
            Console.Clear();
            //绘制开始场景
            vBeginEnd.x = sceneID == E_Scene.BeginScene ? width / 2 - 3 : width / 2 - 4;
            vBeginEnd.y = 5;
            Console.SetCursorPosition(vBeginEnd.x, vBeginEnd.y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(sceneID == E_Scene.BeginScene ? "贪食蛇" : "游戏结束");
            vBeginEnd.x = sceneID == E_Scene.BeginScene ? width / 2 - 4 : width / 2 - 6;
            vBeginEnd.y = 8;
            Console.SetCursorPosition(vBeginEnd.x, vBeginEnd.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sceneID == E_Scene.BeginScene ? "开始游戏" : "回到开始界面");
            vBeginEnd.x = width / 2 - 4;
            vBeginEnd.y = 10;
            Console.SetCursorPosition(vBeginEnd.x, vBeginEnd.y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("结束游戏");
            //char input = (char)(Console.ReadKey(true).Key);
            char input = 'w';
            while (true)
            {
                bool enterOK = false;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        vBeginEnd.x = sceneID == E_Scene.BeginScene ? width / 2 - 4 : width / 2 - 6;
                        vBeginEnd.y = 8;
                        Console.SetCursorPosition(vBeginEnd.x, vBeginEnd.y);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(sceneID == E_Scene.BeginScene ? "开始游戏" : "回到开始界面");
                        vBeginEnd.x = width / 2 - 4;
                        vBeginEnd.y = 10;
                        Console.SetCursorPosition(vBeginEnd.x, vBeginEnd.y);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("结束游戏");
                        input = 'w';
                        break;
                    case ConsoleKey.S:
                        vBeginEnd.x = sceneID == E_Scene.BeginScene ? width / 2 - 4 : width / 2 - 6;
                        vBeginEnd.y = 8;
                        Console.SetCursorPosition(vBeginEnd.x, vBeginEnd.y);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(sceneID == E_Scene.BeginScene ? "开始游戏" : "回到开始界面");
                        vBeginEnd.x = width / 2 - 4;
                        vBeginEnd.y = 10;
                        Console.SetCursorPosition(vBeginEnd.x, vBeginEnd.y);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("结束游戏");
                        input = 's';
                        break;
                    case ConsoleKey.Enter:
                        if (input == 'w')
                        {
                            sceneID = sceneID == E_Scene.BeginScene ? E_Scene.GameScene : E_Scene.BeginScene;
                            enterOK = true;
                        }
                        else if (input == 's')
                        {
                            Environment.Exit(0);
                        }
                        break;
                    default: break;
                }
                if (enterOK == true)
                {
                    break;
                }

            }
            return;
        }
        //游戏场景-绘制城墙函数
        static void DrawGameSceneWall(int width, int height, Vector vGameWall)
        {
            //清屏
            Console.Clear();
            //绘制两个横墙
            for (int i = 0; i <= width - 2; i += 2) 
            {
                vGameWall.x = i;
                vGameWall.y = 0;
                Console.SetCursorPosition(vGameWall.x, vGameWall.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("■");
            }
            for (int i = 0; i <= width - 2; i += 2)
            {
                vGameWall.x = i;
                vGameWall.y = height - 1;
                Console.SetCursorPosition(vGameWall.x, vGameWall.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("■");
            }
            //绘制两个纵墙
            for (int i = 0; i <= height - 1; i++)
            {
                vGameWall.x = 0;
                vGameWall.y = i;
                Console.SetCursorPosition(vGameWall.x, vGameWall.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("■");
            }
            for (int i = 0; i <= height - 1; i++)
            {
                vGameWall.x = width - 2;
                vGameWall.y = i;
                Console.SetCursorPosition(vGameWall.x, vGameWall.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("■");
            }
        }
    }
}