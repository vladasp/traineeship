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
        Timer timerState = new Timer(timeState * 1000);
        Timer timerSession = new Timer(timeSession * 1000);
        //Limitation of entering bad sum
        int counBadSum = 3;
        //Limitation of entering bad pincode               
        int countBadPinCode = 3;
        //Limitation of entering bad command           
        int countBadCommand = 5;
        //Limitation of entering all of command         
        int countCommandLimit = 100;       
        int counterBadCommand;
        //Limitation of time session in sec
        static int timeSession = 120;
        //Limitation of time state in sec             
        static int timeState = 30;         
        public static bool blockStateTimer = false;
        public static bool blockSassionTimer = false;

        #region Block card
        public bool BlockCardPinCode(int counter)
        {
            if (counter < countBadPinCode)
            {
                ++counterBadCommand;
                DataInputOutputManager.OutputMessager("Wrong pin code, you have attempts: ", countBadPinCode - counter);
                return false;
            }
            else
            {
                DataInputOutputManager.OutputMessager("Wrong pin code. YOUR CARD WAS BLOCKED!");
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
                DataInputOutputManager.OutputMessager("Wrong sum, you have attempts: ", counBadSum - counter);
                return false;
            }
            else
            {
                DataInputOutputManager.OutputMessager("So much bad sum. YOUR CARD WAS BLOCKED!");
                return true;
            }
        }
        public bool BlockBadCommand(int counter)
        {
            if (counter < countBadCommand)
            {
                DataInputOutputManager.OutputMessager("Limit of bad attempts ", countBadCommand - counter);
                return false;
            }
            else
            {
                DataInputOutputManager.OutputMessager("Bad command. YOURS CARD WAS BLOCK!");
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
                DataInputOutputManager.OutputMessager("So much command!");
                return true;
            }
        }
        //Timers
        public bool BlockTimeLimitState(bool i)
        {
            if (i)
            {
                blockStateTimer = false;
                timerState.Stop();
                timerState.Start();
            }
            timerState.Elapsed += TimerStateElapsed;
            if (blockStateTimer) DataInputOutputManager.OutputMessager("Time state is out!");
            return blockStateTimer;
        }
        public bool BlockTimeLimitSassion(bool i)
        {
            if (i)
            {
                blockStateTimer = false;
                timerSession.Start();
            }
            timerSession.Elapsed += TimerSassionElapsed;
            if (blockSassionTimer) DataInputOutputManager.OutputMessager("Time session is out!");
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
