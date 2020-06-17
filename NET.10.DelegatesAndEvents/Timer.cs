using System;
using System.Threading;
using System.Diagnostics;

namespace NET._10.DelegatesAndEvents
{
    public delegate void TimerEventHandler(object sender, TimesUpEventArgs e);

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

    public class Timer
    {
        public event TimerEventHandler StartTimer;
        public event TimerEventHandler CountDown;
        public event TimerEventHandler TimesUp;
        

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

                OnStartTimer( new TimesUpEventArgs(name, delay));

                var sw = Stopwatch.StartNew();               
                do
                {                    
                    OnCountDown( new TimesUpEventArgs(name, delay, (delay - (int)sw.ElapsedMilliseconds) / 1000));
                    Thread.Sleep(900);
                } while (sw.ElapsedMilliseconds < delay);
                sw.Stop();

                OnTimesUp(this, new TimesUpEventArgs(name, delay));
            }));
            thread.Start();

        }

        protected virtual void OnStartTimer( TimesUpEventArgs e)
        {
            StartTimer?.Invoke(this, e);
        }

        protected virtual void OnCountDown( TimesUpEventArgs e)
        {
            CountDown?.Invoke(this, e);
        }

        protected virtual void OnTimesUp(object sender, TimesUpEventArgs e)
        {
            TimesUp?.Invoke(sender, e);
        }

    }
}
