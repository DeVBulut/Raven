using Azure.Core;
using System;
using System.Reflection;
using System.Threading;

namespace Raven
{
    internal class RequestManager
    {
        public void Ask()
        {
            DesktopManager desktopManager = new DesktopManager();
            HouseManager houseManager = new HouseManager();
            ChaptGBTManager chaptGBTManager = new ChaptGBTManager();


            Thread.Sleep(350);
            Console.WriteLine("> Which function would you like me to assist you ?");
            Thread.Sleep(150);
            //Future Note to Developer : think of a better solution than shortcuts.
            Console.WriteLine("dsk : Desktop");
            Thread.Sleep(150);
            Console.WriteLine("hom : House");
            Thread.Sleep(150);
            Console.WriteLine("gbt : ChatGpt");
            Thread.Sleep(150);
            string request = Console.ReadLine();

            switch(request)
            {
                case "dsk":
                    Thread.Sleep(150);
                    Console.WriteLine("Navigating to Desktop Panel");
                    desktopManager.Intro();
                    break;
                case "hom":
                    Thread.Sleep(150);
                    Console.WriteLine("Navigating to House Panel");
                    houseManager.Intro();
                    break;
                case "gbt":
                    Thread.Sleep(150);
                    Console.WriteLine("Navigating to ChatGBT Panel");
                    //note: Maybe not be in the final build
                    //chaptGBTManager.Intro();
                    break;
            }
        }

        public void LoadAnimation()
        {
            for (int i = 0; i < 2; i++)  
            {
                for (int a = 0; a < 3; a++) { Console.Write("."); Thread.Sleep(100);}
                Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            }
        }

        public short CheckRequest(string request)
        {
            bool contains = request.IndexOf("volume", StringComparison.OrdinalIgnoreCase) > 0;
            //return 2 : maybe another keyword in the future.
            //return 1 if contains keyword volume in text.
            //return 0 if doesn't contain the keyword.
            if (contains) {return 1;} else{return 0;}
        }

        public int GetVolume(string request)
        {
            if (CheckRequest(request) == 1)
            {
                int index = request.IndexOf("to");
                string tempString = request.Substring(index + 2); 
                int volumeInt = Convert.ToInt32(tempString);
                return volumeInt;
            }
            else { return 1000; }
        }
    }
}