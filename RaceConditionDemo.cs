using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemos
{
    class RaceConditionDemo
    {
        private volatile int counter = 0;
        //private readonly Object counterLocker = new Object();
        ////private readonly Mutex counterMutex = new Mutex();

        public void FirstThreadFunc() {
            while (counter < 50) {
                ////counterMutex.WaitOne();
                //lock (counterLocker) {
                    Console.WriteLine($"First  thread counting from {counter} to {++counter}");
                    Thread.Sleep(100);
                //}
                ////counterMutex.ReleaseMutex();
            }
        }

        public void SecondThreadFunc() {
            while (counter < 50) {
                ////counterMutex.WaitOne();
                //lock (counterLocker) {
                    Console.WriteLine($"Second thread counting from {counter} to {++counter}");
                    Thread.Sleep(10);
                //}
                ////counterMutex.ReleaseMutex();
            }
        }

        public static void RunThreadsDemo() {
            Console.WriteLine("Demo 1: Race-Condition");
            RaceConditionDemo rc = new RaceConditionDemo();
            Thread threadA = new Thread(rc.FirstThreadFunc);
            Thread threadB = new Thread(rc.SecondThreadFunc);
            threadA.Start();  threadB.Start();
            threadA.Join();   threadB.Join();
            Console.WriteLine("Finished.");
        }

        public static void RunTasksDemo() {
            Console.WriteLine("Demo 2: Race-Condition run as Tasks");
            RaceConditionDemo rc = new RaceConditionDemo();
            Task task1 = Task.Factory.StartNew(rc.FirstThreadFunc);
            Task task2 = Task.Factory.StartNew(rc.SecondThreadFunc);
            Task.WaitAll(task1, task2);
            Console.WriteLine("Finished");
        }
    }
}
