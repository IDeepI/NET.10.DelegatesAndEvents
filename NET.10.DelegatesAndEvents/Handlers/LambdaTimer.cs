using NET._10.DelegatesAndEvents.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET._10.DelegatesAndEvents
{
    class LambdaTimer : ICutDownNotifier
    {
        void ICutDownNotifier.Init(Timer theTimer)
        {
            theTimer.StartTimer += new TimerDelegate(
                (object sender, TimesUpEventArgs e) => 
                Console.WriteLine($"Timer '{ e.Name }' установлен на { e.Delay / 1000 } с.")
                );
            theTimer.CountDown += new TimerDelegate(
                (object sender, TimesUpEventArgs e) =>
                Console.WriteLine($"Timer '{ e.Name }' - { e.RemainTime } с.")
                );
            theTimer.TimesUpEvent += new TimerDelegate(
                (object sender, TimesUpEventArgs e) =>
                Console.WriteLine($"Timer '{ e.Name }' завершен за { e.Delay / 1000 } с.")
                );
        }

        void ICutDownNotifier.Run(Timer theTimer)
        {
            theTimer.Start();
        }
    }
}
