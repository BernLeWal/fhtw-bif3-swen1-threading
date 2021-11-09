using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ThreadingDemos
{
    class ProducerConsumerDemo
    {
        private readonly ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

        private void ProducerFunc(object id)
        {
            for( int nr = 1; nr<=30; nr++) {
                int item = (int)id * 100 + nr;
                queue.Enqueue(item);
                Console.WriteLine($"Producer {id} produced item {item}");
                Thread.Sleep(30);   // simulates long lasting item production....
            }
            Console.WriteLine($"Producer {id} finished production.");
        }

        private void ConsumerFunc(object id)
        {
            int item = 0;
            while( queue.TryDequeue(out item) ) {
                Console.WriteLine($"Consumer {id} consumed item {item}");
                Thread.Sleep(100 + (int)id*10);  // simulate some processing with it
            }
            Console.WriteLine($"Consumer {id} finished.");
        }

        public static void RunDemo()
        {
            ProducerConsumerDemo pc = new ProducerConsumerDemo();
            // generate producers
            new Thread(pc.ProducerFunc).Start(1);
            new Thread(pc.ProducerFunc).Start(2);

            Thread.Sleep(300); // let the producers produce some items

            // generate consumers
            for( int id = 1; id <= 10; id++) {
                new Thread(pc.ConsumerFunc).Start(id);
            }
        }
    }
}
