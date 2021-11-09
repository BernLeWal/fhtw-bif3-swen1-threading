using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemos
{
    class Program
    {
        //static void Main(string[] args)
        static async Task Main(string[] args)
        {
            Console.WriteLine("Threading Demos!");
            Console.WriteLine("==============================================");

            RaceConditionDemo.RunThreadsDemo();
            RaceConditionDemo.RunTasksDemo();
            Console.WriteLine("==============================================");

            LimitationsDemo.RunDemo();
            Console.WriteLine("==============================================");

            PollingDemo.RunDemo();
            Console.WriteLine("==============================================");

            AsyncDemo.RunDemo();
            await AsyncDemo.RunDemoAsync();
            Console.WriteLine("==============================================");

            ProducerConsumerDemo.RunDemo();
        }

    }
}
