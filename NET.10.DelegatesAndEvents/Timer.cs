using System;
using System.Threading;
using System.Diagnostics;

namespace NET._10.DelegatesAndEvents
{
    public delegate void TimerDelegate(object sender, TimerEventArgs e);

    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(string name, int delay) : base()
        {
            this.Name = name;
            this.Delay = delay;
        }

        public TimerEventArgs(string name, int delay, int remainTime) : this(name, delay)
        {
            this.RemainTime = remainTime;
        }

        public string Name { get; private set; }
        public int Delay { get; private set; }
        public int RemainTime { get; private set; }


    }

    class Timer
    {
        public event TimerDelegate TimerEvent;
        public event TimerDelegate CountDown;

        string name;
        int delay;
        

        public Timer(string Name, int Delay)
        {
            this.name = Name;
            this.delay = Delay;
        }

        public void Start()
        {
            Thread thread = new Thread(new ThreadStart(() => {

                var sw = Stopwatch.StartNew();               
                do
                {
                    //Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                    //                  Thread.CurrentThread.ManagedThreadId,
                    //                  sw.ElapsedMilliseconds / 1000.0);
                    OnCountDown(this, new TimerEventArgs(name, delay, (delay - (int)sw.ElapsedMilliseconds) / 1000));
                    Thread.Sleep(900);
                } while (sw.ElapsedMilliseconds <= delay);
                sw.Stop();

                OnTimer(this, new TimerEventArgs(name, delay));
            }));
            thread.Start();
        }

        protected virtual void OnTimer(object sender, TimerEventArgs e)
        {
            TimerEvent?.Invoke(sender, e);
        }

        protected virtual void OnCountDown(object sender, TimerEventArgs e)
        {
            CountDown?.Invoke(sender, e);
        }
    }
}
