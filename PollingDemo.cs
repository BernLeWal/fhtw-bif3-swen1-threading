using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemos
{
    class PollingDemo
    {
        private const int MaxResult = 10;
        private /*volatile*/ string[] results = new string[MaxResult];
        private /*volatile*/ int resultsFinished = 0;
        //private Object resultsLocker = new Object();

        private string CalculateResult(int value)
        {
            return $"calculated value {value}";
        }

        public void RunDemo()
        {
            // start tasks
            for( int i=0; i < MaxResult; i++ ) {
                new Task((counter) => {
                    int nr = (int)counter;
                    string result = CalculateResult(nr);
                    results[nr] = result;
                    //lock (resultsLocker) {
                        resultsFinished++;
                    //}
                }, i).Start();
            }

            // polling - wait until all tasks are finished
            while( resultsFinished < MaxResult ) {
                Console.WriteLine($"Waiting: {resultsFinished} of {MaxResult} finsihed.");
                Thread.Sleep(50);
            }

            // all tasks finished
            for(int i=0; i < MaxResult; i++) {
                Console.WriteLine(results[i]);
            }
        }

        public static void Demo()
        {
            PollingDemo pd = new PollingDemo();
            pd.RunDemo();
        }
    }
}
