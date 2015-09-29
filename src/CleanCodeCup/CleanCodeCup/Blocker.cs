using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CleanCodeCup
{
    public class Blocker
    {
        DataInputOutputManeger inOutManeger = new DataInputOutputManeger();
        Timer timerState = new Timer(timeState*1000);
        Timer timerSession = new Timer(timeSession*1000);
        int counBadSum = 3;                //Limitation of entering bad sum
        int countBadPinCode = 3;           //Limitation of entering bad pincode
        int countBadCommand = 5;           //Limitation of entering bad command
        int countCommandLimit = 100;       //Limitation of entering all of command
        int counterBadCommand;
        static int timeSession = 120;      //Limitation of time session in sec
        static int timeState = 30;         //Limitation of time state in sec
        public static bool blockStateTimer = false;
        public static bool blockSassionTimer = false;

        #region Block card
        public bool BlockCardPinCode(int counter)
        {
            if (counter < countBadPinCode)
            {
                ++counterBadCommand;
                inOutManeger.OutputMasseger("Wrong pin code, you have attempts: ", countBadPinCode - counter);
                return false;
            }
            else
            {
                inOutManeger.OutputMasseger("Wrong pin code. YOURS CARD WAS BLOCK!");
                return true;
            }
        }
        #endregion

        #region Block menu
        //Counters
        public bool BlockBadSum(int counter)
        {
            ++counterBadCommand;
            if (counter < counBadSum && !BlockBadCommand(counterBadCommand))
            {
                inOutManeger.OutputMasseger("Wrong sum, you have attempts: ", counBadSum - counter);
                return false;
            }
            else
            {
                inOutManeger.OutputMasseger("So much bad sum. YOURS CARD WAS BLOCK!");
                return true;
            }
        }
        public bool BlockBadCommand(int counter)
        {
            if (counter < countBadCommand)
            {
                inOutManeger.OutputMasseger("Limit of bad attempts ", countBadCommand - counter);
                return false;
            }
            else
            {
                Console.WriteLine("Bad command. YOURS CARD WAS BLOCK!");
                return true;
            }
        }
        public bool BlockCommandLimit(int counter)
        {
            if (counter < countCommandLimit)
            {
                return false;
            }
            else
            {
                inOutManeger.OutputMasseger("So much command!");
                return true;
            }
        }
        //Timers
        public bool BlockTimeLimitState(bool i)
        {
            if (i)
            {
                timerState.Stop();
                timerState.Start();
            }
            timerState.Elapsed += TimerStateElapsed;
            if (blockStateTimer) inOutManeger.OutputMasseger("Time state is out!");
            return blockStateTimer;
        }
        public bool BlockTimeLimitSassion(bool i)
        {
            if (i) timerSession.Start();
            timerSession.Elapsed += TimerSassionElapsed;
            if (blockSassionTimer) inOutManeger.OutputMasseger("Time session is out!");
            return blockSassionTimer;
        }
        #endregion
        public static void TimerSassionElapsed(object sendler, EventArgs e)
        {
            blockSassionTimer = true;
        }
        public static void TimerStateElapsed(object sendler, EventArgs e)
        {
            blockStateTimer = true;
        }
    }
}
