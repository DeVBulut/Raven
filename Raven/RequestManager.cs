using Azure.Core;
using System;
using System.Collections.Generic;
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
            AnimationManager animationManager = new AnimationManager();


            Thread.Sleep(350);

            animationManager.slowText("> Which function would you like me to assist you ?", 30, true, 150);
            animationManager.slowText("Desktop", 25, true, 100);
            animationManager.slowText("House", 25, true, 100);
            animationManager.slowText("ChatGpt", 25, true, 100);

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

                case "gpt":
                    Thread.Sleep(150);
                    animationManager.LoadAnimation(5);
                    Console.WriteLine("Navigating to ChatGPT Panel");
                    //note: Maybe not be in the final build
                    //chaptGBTManager.Intro();
                    break;
            }
        }

        public string CheckRequest(string request)
        {
            string[] keywordList = {"volume", "dsk"};
            
            for (int i = 0; i < keywordList.Length; i++)
            {
                bool containsWord = request.IndexOf(keywordList[i], StringComparison.OrdinalIgnoreCase) > 0;
                if (containsWord)
                {
                    // 'i' will be the index of the word found the in the request.
                    switch (i)
                    {
                        case 1:
                            return "volume";
                        case 2:
                            return "desktop";
                    }
                }
            }
            return "null";

        }

        public int GetVolumeText(string request)
        {
            if (CheckRequest(request) == "volume")
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