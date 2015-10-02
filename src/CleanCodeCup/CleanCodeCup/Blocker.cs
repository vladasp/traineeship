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
        DataInputOutputManager inOutManager = new DataInputOutputManager();
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
                inOutManager.OutputMessager("Wrong pin code, you have attempts: ", countBadPinCode - counter);
                return false;
            }
            else
            {
                inOutManager.OutputMessager("Wrong pin code. YOUR CARD WAS BLOCKED!");
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
                inOutManager.OutputMessager("Wrong sum, you have attempts: ", counBadSum - counter);
                return false;
            }
            else
            {
                inOutManager.OutputMessager("So much bad sum. YOUR CARD WAS BLOCKED!");
                return true;
            }
        }
        public bool BlockBadCommand(int counter)
        {
            if (counter < countBadCommand)
            {
                inOutManager.OutputMessager("Limit of bad attempts ", countBadCommand - counter);
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
                inOutManager.OutputMessager("So much command!");
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
            if (blockStateTimer) inOutManager.OutputMessager("Time state is out!");
            return blockStateTimer;
        }
        public bool BlockTimeLimitSassion(bool i)
        {
            if (i) timerSession.Start();
            timerSession.Elapsed += TimerSassionElapsed;
            if (blockSassionTimer) inOutManager.OutputMessager("Time session is out!");
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
