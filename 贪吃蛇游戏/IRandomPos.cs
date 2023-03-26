using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 随机变化位置接口
    /// </summary>
    internal interface IRandomPos
    {
        public void RandomPos(Player p);
    }
}
