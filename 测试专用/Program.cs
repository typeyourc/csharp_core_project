namespace 测试专用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //2023年3月27日测试问题
            //1.食物有时候生成在城墙上
            //2.(done)玩家头部移动的时候，原先打印的标志一直存在，没有消失 ing
            //3.玩家撞墙并没有到达游戏结束场景
            //4.感觉玩家没有吃到食物
            //5.(done)还有一个时而出现时而小时的bug，FOOD这个类中gFood.vGrid = Map.grids[randomIndex].vGrid;执行时报错Object reference not set to an instance of an object
            //5.done 原因 for (int j = 1; j <= 18; j++)越界，改成j<=17
            //6.玩家能够移动到墙上
            //7.(done)开始位置绘制了身体----原因是由于数组默认存储了两个坐标，原先的draw方法把隐藏的用于存储尾巴的坐标给打印出来了
        }
    }
}