using NET._10.DelegatesAndEvents.Handlers;
using System;



namespace NET._10.DelegatesAndEvents
{
    class Program
    {

        static void Main(string[] args)
        {
            Timer TheTimer;

            GenerateTimer(out string timerName, out int timerValue);

            TheTimer = new Timer(timerName, timerValue);

            var methodTimer = new MethodTimer();
            ((ICutDownNotifier)methodTimer).Init(TheTimer);
            ((ICutDownNotifier)methodTimer).Run(TheTimer);

            Console.ReadKey();
            TheTimer.ToString();
        }



        private static void GenerateTimer(out string timerName, out int timerValue)
        {
            Console.WriteLine("Введите имя таймера: ");
            timerName = Console.ReadLine();
            // Время в мс
            timerValue = GetNumericInput("Введите время, с: ") * 1000;
        }

        private static int GetNumericInput(string text)
        {
            Console.WriteLine(text);
            bool success = Int32.TryParse(Console.ReadLine(), out int parsed);
            if (success)
            {
                return parsed;
            }
            else
            {
                Console.WriteLine("Число не введено.");
                return 0;
            }
        }
    }
}
