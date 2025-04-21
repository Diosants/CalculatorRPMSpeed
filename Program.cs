using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPM_Estimator_from_Surface_Speed
{
    internal class Program
    {


        public static  class MachineCalculator
        {
            /// <summary>
            /// Estimates spindle RPM from surface speed and tool diameter.
            /// </summary>
            /// <param name="cuttingSpeed">Cutting speed (m/min).</param>
            /// <param name="diameter">Tool diameter (mm).</param>
            /// <returns>Estimated spindle RPM.</returns>
            /// 
            public static  double  CalculateRPM(double surfaceSpeed, double diameter)
            {
              
                return Math.Round((surfaceSpeed * 1000) / (Math.PI * diameter),0);
            }

        }
        static void Main(string[] args)
        {

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" *** RPM Calculator ***");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Select Units");
            Console.Write("1 - Metric (mm, m/min)");
            Console.Write("1 - Imperial (inch,SFM)");
            Console.Write("\n Your choice ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunMetricMode();
                    break;

                case "2":
                    RunImperialMode();
                    break;

                default:
                    ShowError("Invalid Selection.");
                    break;

            }
            Console.WriteLine("\nPress  any key to exit ...");
            Console.ReadKey();
        }

            static void RunMetricMode()
            {
            Console.Write("\nEnter tool diameter in mm\n");

            if (!double.TryParse(Console.ReadLine(), out double diameter))
            {
                ShowError("Invalid diameter");

                return;
            }
            Console.WriteLine(" Enter Cutting Speed in m/min:\n ");
            if (!double.TryParse(Console.ReadLine(), out double surfaceSpeed)) 
            {
                ShowError("Invalid surface Speed.");
                return;
            }

            double rpm = MachineCalculator.CalculateRPM(surfaceSpeed, diameter);

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($"\n✔ Required spindle speed: {rpm} RPM");

        }

        static void RunImperialMode()
        {
            Console.WriteLine("\nEnter tool diameter in inches: ");
            if(!double.TryParse(Console.ReadLine(),out  double diameter ))
            {
                ShowError("Invalid diameter");

                return;
            }
            Console.Write("Enter cutting speed in SFM");
            if(!double.TryParse(Console.ReadLine(), out double surfaceSpeed))
            {
                ShowError("Invalid surface speed. ");
                return;

            }
            double rpm = Math.Round((surfaceSpeed * 3.82) / diameter, 0);

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($"\n✔ Required spindle speed: {rpm} RPM");
            Console.ResetColor();

        }
        static void ShowError (string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n⚠{ message}");
            Console.ResetColor();

        }
    }
}
