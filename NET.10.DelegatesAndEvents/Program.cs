using System;
using System.IO;
using System.Windows.Forms;

namespace NET._10.DelegatesAndEvents
{
    class Program
    {
        static Timer TheTimer;
        static void Main(string[] args)
        {

            GenerateTimer(out string timerName, out int timerValue);

            TheTimer = new Timer(timerName, timerValue);
            TheTimer.TimerEvent += new TimerDelegate(TimerReciever);
            TheTimer.CountDown += new TimerDelegate(TimerCount);
            TheTimer.Start();

            Console.ReadKey();
            TheTimer.ToString();
        }

        private static void TimerReciever(object sender, TimerEventArgs e)
        {
            MessageBox.Show($"Timer '{ e.Name }' завершен за { e.Delay / 1000 } с.");
        }
        
        private static void TimerCount(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Timer '{ e.Name }' - { e.RemainTime } с." );
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

        private static void FeedbackToConsole(Int32 value)
        {
            Console.WriteLine("Item=" + value);
        }

        private static void FeedbackToMsgBox(Int32 value)
        {
            MessageBox.Show("Item=" + value);
        }

        private void FeedbackToFile(Int32 value)
        {
            StreamWriter sw = new StreamWriter("Status", true);
            sw.WriteLine("Item=" + value);
            sw.Close();
        }
    }
}
