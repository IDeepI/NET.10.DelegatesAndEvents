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
            TheTimer.StartTimer += new TimerDelegate(TimerStart);
            TheTimer.CountDown += new TimerDelegate(TimerCount);
            TheTimer.TimesUpEvent += new TimerDelegate(TimerReciever);
            TheTimer.Start();

            Console.ReadKey();
            TheTimer.ToString();
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

        public static void GenerateTimer(out string timerName, out int timerValue)
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
