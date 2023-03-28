using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 专门的单个空的格子(空(假)食物类）
    /// </summary>
    internal class EmptyGrid
    {
        //格子类型的成员变量
        public Grid gEmpty = new Grid();
        //构造函数
        public EmptyGrid()
        {
            gEmpty.typeOfGrid = E_TypeOfGrid.Empty;
        }
    }
}
