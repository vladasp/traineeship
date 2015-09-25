using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter14
{
    class Exercise4
    {
        public void Show()
        {
            Console.WriteLine(@"
Попробуйте исправить код следующего метода расширения, в котором 
присутствует ошибка:
public static string ToAcronym(this string inputString)     - right with static
{
  inputString = inputString.Trim();
  if (inputString == "")
  {
    return "";
  }
  string[] inputStringAsArray = inputString.Split(' ');
  StringBuilder sb = new StringBuilder();
  for (int i = 0; i < inputStringAsArray.Length; i++)
  {
   if (inputStringAsArray[i].Length > 0)
   {
     sb.AppendFormat('{0}', inputStringAsArray[i].Substring(0, 1).ToUpper());
   }
    }
  return sb.ToString();
}
                            ");
        }
    }
}
