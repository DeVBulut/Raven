using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raven
{
    internal class AnimationManager
    {
        public void LoadAnimation(int WaitTime)
        {
            slowText("Loading", 100, true);

            int cycle = WaitTime * 3;
            for (int i = 0; i < cycle; i++)
            {
                string[] LoadChars = { "|", "/", "-", "\\", };
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(LoadChars[j]);
                    Thread.Sleep(120);
                    Console.Write("\b"); //backspace for ASCII
                }
            }
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r"); //clean the line
        }


        public void slowText(string rawText, int timeGap, bool leaveGap)
        {
            for (int i = 0; i < rawText.Length; i++)
            {
                Console.Write(rawText[i]);
                Thread.Sleep(timeGap);
            }

            if (leaveGap){ Console.Write(' ');}
        }

        public void slowText(string rawText, int timeGap, bool leaveGap, int WaitTime)
        {

            for (int i = 0; i < rawText.Length; i++)
            {
                Console.Write(rawText[i]);
                Thread.Sleep(timeGap);
            }

            if (leaveGap) { Console.WriteLine();}

            Thread.Sleep(WaitTime);
        }
    }
}
