using System;

namespace protomama
{
    internal class Program
    {

        static ConsoleKey? key = null;
        static DateTime lastFrameUpdate = DateTime.Now;
        static int FPS = 2;
        static int ticksPerMillisecond = 10000;
        static double ticksPerFrame = ((1000 * ticksPerMillisecond) / FPS);


        public static void Main(string[] args)
        {
            int[,] map = Map.testMap;
            Player p = new Player();
            p.xCoord = 1;
            p.yCoord = 1;

            Console.WriteLine(ticksPerFrame);

            new Task(() => {
                KeyListener();
            }).Start();
            Loop();
        }

        public static void KeyListener()
        {
            do
            {
                key = Console.ReadKey().Key;
            } while (true);
        }

        public static void Loop()
        {
            while (true)
            {
                var dat = (DateTime.Now - lastFrameUpdate).Ticks;
                // do the thing
                while( ((dat) < ticksPerFrame))
                {
                    dat = (DateTime.Now - lastFrameUpdate).Ticks;
                }
                Console.Clear();
                Console.WriteLine(key);
                key = null;
                lastFrameUpdate = DateTime.Now;
            }
        }
    }
}