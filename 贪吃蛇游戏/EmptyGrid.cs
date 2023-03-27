using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 空的格子
    /// </summary>
    internal class EmptyGrid
    {
        //格子类型的成员变量
        public Grid gEmpty = new Grid();
        public EmptyGrid()
        {
            gEmpty.typeOfGrid = E_TypeOfGrid.Empty;
        }
    }
}
