using System.Net.NetworkInformation;

namespace 测试专用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //2023年3月27日测试问题
            //1.(好像done，没有复现)食物有时候生成在城墙上
            //2.(done)玩家头部移动的时候，原先打印的标志一直存在，没有消失
            //3.(done)玩家撞墙并没有到达游戏结束场景
            //3.1(done)玩家撞自身并没有到达游戏结束场景
            //4.(done)感觉玩家没有吃到食物 ,首次吃到食物的时候身体跟头部变为一体了，应该是头部到
            //到达食物位置，原先头部的位置生成一个身体
            //4.1(done)玩家移动一下就不见了
            //4.2(done)吃到食物的时候，当时食物没有变成身体，而是移动了一下之后才变成身体
            //5.(done)还有一个时而出现时而小时的bug，FOOD这个类中gFood.vGrid = Map.grids[randomIndex].vGrid;执行时报错Object reference not set to an instance of an object
            //done 原因 for (int j = 1; j <= 18; j++)越界，改成j<=17
            //6.(done)玩家能够移动到墙上
            //7.(done)开始位置绘制了身体----原因是由于数组默认存储了两个坐标，原先的draw方法把隐藏的用于存储尾巴的坐标给打印出来了
            //8.(done)还没有实现吃了一个食物后出现另一个食物
            //9.可以增加个随机生成障碍块的需求
            //10.可以增加显示吃了多少个食物的需求
            //11.可以增加显示分数的需求
            //12.可以增加显示速度的需求or显示花费的时间
            //13.可以增加失败的原因显示界面，比如撞墙或者撞到自身
        }
    }
}