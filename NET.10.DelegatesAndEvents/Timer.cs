using System;
using System.Threading;
using System.Diagnostics;

namespace NET._10.DelegatesAndEvents
{
    public delegate void TimerDelegate(object sender, TimesUpEventArgs e);

    public class TimesUpEventArgs : EventArgs
    {
        public TimesUpEventArgs(string name, int delay) : base()
        {
            this.Name = name;
            this.Delay = delay;
        }

        public TimesUpEventArgs(string name, int delay, int remainTime) : this(name, delay)
        {
            this.RemainTime = remainTime;
        }

        public string Name { get; private set; }
        public int Delay { get; private set; }
        public int RemainTime { get; private set; }


    }

    class Timer
    {
        public event TimerDelegate StartTimer;
        public event TimerDelegate CountDown;
        public event TimerDelegate TimesUpEvent;
        

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

                OnStartTimer(this, new TimesUpEventArgs(name, delay));

                var sw = Stopwatch.StartNew();               
                do
                {                    
                    OnCountDown(this, new TimesUpEventArgs(name, delay, (delay - (int)sw.ElapsedMilliseconds) / 1000));
                    Thread.Sleep(900);
                } while (sw.ElapsedMilliseconds < delay);
                sw.Stop();

                OnTimesUp(this, new TimesUpEventArgs(name, delay));
            }));
            thread.Start();

        }

        protected virtual void OnStartTimer(object sender, TimesUpEventArgs e)
        {
            StartTimer?.Invoke(sender, e);
        }

        protected virtual void OnCountDown(object sender, TimesUpEventArgs e)
        {
            CountDown?.Invoke(sender, e);
        }

        protected virtual void OnTimesUp(object sender, TimesUpEventArgs e)
        {
            TimesUpEvent?.Invoke(sender, e);
        }

    }
}
