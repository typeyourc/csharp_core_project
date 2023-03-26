using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 城墙静态类
    /// </summary>
    static internal class Wall
    {
        //城墙一共114块
        public static Grid[] gWall = new Grid[114];
        //public static Vector[] vWall = new Vector[114];

        static Wall()
        {
           
            //存储两个横向城墙的坐标
            for (int i = 0, j = 0; i <= 78 && j < 40; i += 2, j++)
            {
                gWall[j] = new Grid();
                gWall[j].vGrid.x = i;
                gWall[j].vGrid.y = 0;
                gWall[j].typeOfGrid = E_TypeOfGrid.Wall;
            }
            for (int i = 0, j = 40; i <= 78 && j < 80; i += 2, j++)
            {
                gWall[j] = new Grid();
                gWall[j].vGrid.x = i;
                gWall[j].vGrid.y = 18;
                gWall[j].typeOfGrid = E_TypeOfGrid.Wall;
            }
            //存储两个纵向城墙的坐标
            for (int i = 1, j = 80; i <= 18 && j < 97; i++, j++)
            {
                gWall[j] = new Grid();
                gWall[j].vGrid.x = 0;
                gWall[j].vGrid.y = i;
                gWall[j].typeOfGrid = E_TypeOfGrid.Wall;
            }
            for (int i = 1, j = 97; i <= 18 && j < 114; i++, j++)
            {
                gWall[j] = new Grid();
                gWall[j].vGrid.x = 78;
                gWall[j].vGrid.y = i;
                gWall[j].typeOfGrid = E_TypeOfGrid.Wall;
            }
        }
    }
}
