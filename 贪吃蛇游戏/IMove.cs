using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇游戏
{
    /// <summary>
    /// 移动接口
    /// </summary>
    internal interface IMove
    {
        public int Move(ref E_Scene sceneID, Food xFood);
    }
}
