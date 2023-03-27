using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 除去城墙，剩下的格子合集静态类
    /// </summary>
    static internal class Map
    {
        //除去城墙，剩下的格子数是17*38=646个格子
        public static Grid[] grids = new Grid[646];

        //静态构造函数，初始化各个格子的格子属性、格子坐标
        static Map()
        {
            int count = 0;
            for (int j = 1; j <= 17; j++)
            {
                for (int i = 2; i <= 76; i += 2)
                {
                    //以下这句十分重要，在给grids数组赋值之前，要先实例化。
                    //public static Grid[] grids =new Grid[646];这句只是实际上实例化了一个包含646个Grid对象引用的数组，但数组中的每个Grid对象引用本身尚未实例化。
                    //所以需要进一步实例化
                    grids[count] = new Grid();
                    grids[count].typeOfGrid = E_TypeOfGrid.Empty;
                    grids[count].vGrid.x = i;
                    grids[count].vGrid.y = j;
                    count++;
                }
            }
        }
    }
}
