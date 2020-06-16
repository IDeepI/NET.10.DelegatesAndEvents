using NET._10.DelegatesAndEvents.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET._10.DelegatesAndEvents
{
    class MethodTimer : ICutDownNotifier
    {
        void ICutDownNotifier.Init(Timer theTimer)
        {
            theTimer.StartTimer += new TimerDelegate(TimerStart);
            theTimer.CountDown += new TimerDelegate(TimerCount);
            theTimer.TimesUpEvent += new TimerDelegate(TimerReciever);
        }

        void ICutDownNotifier.Run(Timer theTimer)
        {
            theTimer.Start();
        }

        private static void TimerStart(object sender, TimesUpEventArgs e)
        {
            Console.WriteLine($"Timer '{ e.Name }' установлен на { e.Delay / 1000 } с.");
        }

        private static void TimerCount(object sender, TimesUpEventArgs e)
        {
            Console.WriteLine($"Timer '{ e.Name }' - { e.RemainTime } с.");
        }

        private static void TimerReciever(object sender, TimesUpEventArgs e)
        {
            Console.WriteLine($"Timer '{ e.Name }' завершен за { e.Delay / 1000 } с.");
        }

    }
}
