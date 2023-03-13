using System;

namespace Raven
{
    //Version: v1.1
    /*Author:
         _   _             
        | | | |            
        | |_| | __ _ _ __  
        |  _  |/ _` | '_ \ 
        | | | | (_| | | | |
        \_| |_/\__,_|_| |_| ??
    */
    //Description: Raven is a multipurpose virtual assistant that attends to both physical and nonphysical tasks.
    internal class Program
    {

        static void Main(string[] args)
        {
            LoginManager loginManager = new LoginManager();
            RequestManager requestManager = new RequestManager();
            //loginManager.logType;  >> Variable that stores the type of Login.


            //Execute Login Sequence
            try { loginManager.Intro(); }
            catch (Exception e) { if (loginManager.logType == 2) { Console.WriteLine("$$$ Error Code : " + e); } }

            //Execute Request Sequence
            try { requestManager.Ask(); }
            catch (Exception e) { if (loginManager.logType == 2) { Console.WriteLine("$$$ Error Code : " + e); } }
            

            Console.ReadLine();
        }
    }
}
