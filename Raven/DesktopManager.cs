using System.Collections.Generic;
using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Threading;

namespace Raven
{
    internal class DesktopManager
    {
        //Manages in Computer Actions.
        public void Intro()
        {
            RequestManager requestManager = new RequestManager();
            string request = Console.ReadLine();
            short requestType = requestManager.CheckRequest(request);

            switch (requestType)
            {
                //Request Type : 1 Includes Volume KeyWord
                case 1: 
                    int volume = requestManager.GetVolume(request);

                    if (volume <= 100 && volume >= 0) { SetVolume(volume); break;}
                    else { Thread.Sleep(100); Console.WriteLine(">> Input an integer between 0-100");  Intro();  break; }
            }
        }

        IEnumerable<CoreAudioDevice> devices = new CoreAudioController().GetPlaybackDevices();
        public static void SetVolume(int volume)
        {
            //Sets the volume of default playBack Device
            CoreAudioDevice defPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            defPlaybackDevice.Volume = volume;
        }
    }
}