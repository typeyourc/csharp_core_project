namespace 测试专用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //2023年3月27日测试问题
            //1.食物有时候生成在城墙上
            //2.玩家头部移动的时候，原先的位置一直存在
            //3.玩家撞墙并没有到达游戏结束场景
            //4.感觉玩家没有吃到食物
            //5.还有一个时而出现时而小时的bug，FOOD这个类中gFood.vGrid = Map.grids[randomIndex].vGrid;执行时报错Object reference not set to an instance of an object
        }
    }
}