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

            //RaceConditionDemo.RunThreadsDemo();
            //RaceConditionDemo.RunTasksDemo();

            //LimitationsDemo.RunDemo();

            //PollingDemo.RunDemo();

            // /*await*/ AsyncDemo.Demo();

            ProducerConsumerDemo.RunDemo();
        }

    }
}
