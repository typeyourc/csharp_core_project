using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 增长接口(吃掉一个食物的时候，实现身体增长)
    /// </summary>
    internal interface IGrow
    {
        public void Grow(Food food);
        public void Grow(EmptyGrid emptyGrid, Grid x);
    }
}
