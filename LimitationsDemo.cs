using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemos
{
    class LimitationsDemo
    {
        private Random rand = new Random();
        //private readonly Semaphore sem = new Semaphore(5, 5);

        private void DownloadFileFunc(object url)
        {
            ////try
            ////{
                //sem.WaitOne();
                Console.WriteLine($" {url} is downloading.");
                Thread.Sleep(1000 + 1000 * rand.Next(5));
                Console.WriteLine($" {url} finished.");
            ////}
            ////finally
            ////{
                //sem.Release();
            ////}
        }

        public void DownloadFiles(IEnumerable<string> urls)
        {
            foreach (var url in urls) {
                new Thread(DownloadFileFunc).Start(url);
                //new Thread(() => DownloadFileFunc(url)).Start();
                ////ThreadPool.QueueUserWorkItem(state => DownloadFileFunc(state), url);
                //////Task.Run(() => DownloadFileFunc(url));
            }
        }

        public static void RunDemo()
        {
            Console.WriteLine("Demo 3: Limited Connections with Semaphore");
            LimitationsDemo lc = new LimitationsDemo();
            IEnumerable<string> urls = new List<String>() {
                "google", "bing", "duckduckgo", "scroogle",
                "google", "bing", "duckduckgo", "scroogle",
                "google", "bing", "duckduckgo", "scroogle",
                "google", "bing", "duckduckgo", "scroogle",
            };
            lc.DownloadFiles(urls);

            // Main Thread waiting to complete when using ThreadPool (uses polling)
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out _);   // get max threads in the pool
            while (true) {
                ThreadPool.GetAvailableThreads(out int workerThreads, out _); // get available threads
                if (workerThreads == maxWorkerThreads)
                    break;
                Thread.Sleep(1000);
            }
        }
    }
}
