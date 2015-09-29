using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeCup
{
    public enum UserCommand {BALANCE = 1, CASH, EXIT};
    public static class DataValidator
    {
        public static int ChackPinCodeSimbols(this string inputObgect)
        {
            inputObgect = Console.ReadLine();
            int number;
            Int32.TryParse(inputObgect, out number);
            return number;
        }
        public static string ChackCommandSimbols(this string inputObgect)
        {
            inputObgect = Console.ReadLine();
            string command = string.Empty;
            int number;
            foreach (UserCommand u in Enum.GetValues(typeof(UserCommand)))
            {
                if (u.ToString() == inputObgect)
                {
                    command = u.ToString();
                }
                else if (Int32.TryParse(inputObgect, out number) && (int)u == number)
                {
                    command = number.ToString();
                }
                else
                {
                    if (inputObgect.Length < Enum.GetNames(typeof(UserCommand)).Length)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return command;
        }
        public static double ChackSumSimbols(this string inputObgect)
        {
            inputObgect = Console.ReadLine();
            double number;
            Double.TryParse(inputObgect, out number);
            return number;
        }
    }
}
