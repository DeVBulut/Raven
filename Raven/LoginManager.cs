using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raven
{
    internal class LoginManager
    {
        //logtype : 1 Guest
        //logtype : 2 Admin 
        //logtype : 0 unauthorized
        public short logType;
        private short Login(string Username, string Password)
        {
            //Check the encrypted SQL server for user info


            KeyVaultManager keyVaultManager = new KeyVaultManager();
            SqlConnection _connection = new SqlConnection(keyVaultManager.GetSecret("UserInfoConnString"));

            short loginType = 0;

            if (_connection != null)
            {
                try
                {
                    bool containAdmin = Username.IndexOf("admin", StringComparison.OrdinalIgnoreCase) >= 0;
                    String querry = "SELECT * FROM Login_Information Where Username = '" + Username + "' AND Password = '" + Password + "'";
                    SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(querry, _connection);
                    DataTable dTable = new DataTable();
                    _sqlDataAdapter.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        if (containAdmin == true)
                        {
                            //admin access
                            loginType = 2;
                        }
                        else
                        {
                            //guest access
                            loginType = 1;
                        }
                    }
                    else
                    {
                        //not found
                        loginType = 0;
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    _connection.Close();
                }
            }

            return loginType;
        }

        public void Intro()
        {  
            //Ask User for Input

            Console.WriteLine("> Enter Username and Password"); //first line don't loop

            Console.Write("> ");
            string Username = Console.ReadLine();
            Console.Write("> ");
            string Password = Console.ReadLine();

            Thread.Sleep(350);
            Console.Clear();

            Console.WriteLine("> Enter Username and Password");
            Console.WriteLine("******************************");
            Thread.Sleep(350);
            Console.WriteLine(">> Authorizing Connection...");
            LoginDetection(Username, Password);
        }

        public void LoginDetection(string Username, string Password)
        {
            //Return the type of Login;
            short loginType = Login(Username, Password);
            logType = loginType;

            switch (loginType)
            {
                case 0:
                    //not found any login data
                    Console.WriteLine(">> Data not detected");
                    Thread.Sleep(450);
                    Console.WriteLine(">> Connection Unauthorized");
                    Intro();
                    break;
                case 1:
                    //guest access
                    Console.WriteLine("******************************");
                    Thread.Sleep(250);
                    Console.WriteLine(">> Guest Access Authorized");
                    break;
                case 2:
                    //admin acccess
                    Console.WriteLine(">> Admin Access Authorized");
                    Thread.Sleep(250);
                    Console.WriteLine("******************************");
                    Thread.Sleep(350);
                    Console.WriteLine("> Welcome Back Sir " + Username);
                    break;
            }
        }
    }
}
