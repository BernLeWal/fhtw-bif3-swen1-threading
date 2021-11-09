using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemos
{
    class AsyncDemo
    {
        private void SyncMethod1() {
            Console.WriteLine("Method1 called");
            Thread.Sleep(100);
        }

        private void SyncMethod2() {
            Console.WriteLine("Method2 called");
            Thread.Sleep(200);
        }

        private void SyncMethod3() {
            Console.WriteLine("Method3 called");
            Thread.Sleep(300);
        }

        public static void Demo()
        //public static async Task Demo()
        {
            AsyncDemo ad = new AsyncDemo();
            //Task<object> task = ad.RunAsyncCalls();
            ad.SyncMethod1();
            ad.SyncMethod2();   //
            ad.SyncMethod3();   //
            //object result = await task;
            //Console.WriteLine(result);
        }

        private async Task<string> AsyncMethod() {
            return await Task.Run(() =>
            {
                Task.Delay(5000).Wait();
                return "test object";
            });
        }

        private async Task<object> RunAsyncCalls() {
            SyncMethod2();
            object result = await AsyncMethod();
            SyncMethod3();
            return result;
        }
    }
}