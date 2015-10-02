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
        
        public static int CheckPinCodeSimbols(this string inputObject)
        {
            inputObject = DataInputOutputManager.InputMessanger();
            int number;
            Int32.TryParse(inputObject, out number);
            return number;
        }
        public static string CheckCommandSimbols(this string inputObject)
        {
            inputObject = DataInputOutputManager.InputMessanger();
            string command = string.Empty;
            int number;
            foreach (UserCommand u in Enum.GetValues(typeof(UserCommand)))
            {
                if (u.ToString() == inputObject)
                {
                    command = u.ToString();
                }
                else if (Int32.TryParse(inputObject, out number) && (int)u == number)
                {
                    command = number.ToString();
                }
                else
                {
                    if (inputObject.Length >= Enum.GetNames(typeof(UserCommand)).Length)
                    {
                       break;
                    }
                }
            }
            return command;
        }
        public static double CheckSumSimbols(this string inputObject)
        {
            inputObject = DataInputOutputManager.InputMessanger();
            double number;
            Double.TryParse(inputObject, out number);
            return number;
        }
    }
}
