using System;
using System.IO;
using System.Threading;

namespace TerminalProphet
{
    class Program
    {
        private static Random r;
        private static ConsoleColor primaryColor;

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 25);
            Console.BackgroundColor = ConsoleColor.Black;

            ConsoleKeyInfo input;

            do
            {
                SetPrimeColor();
                PrintTitle(1000);
                int seed = ReadFeelings();
                string[] prophecy = GenerateProphecy(seed);
                DisplayProphecy(prophecy);

                input = Console.ReadKey();

            } while (input.Key != ConsoleKey.Escape);
        }

        private static void SetPrimeColor()
        {
            r = new Random();
            primaryColor = (ConsoleColor)r.Next(1, 7);
        }

        private static ConsoleColor GetMainColor()
        {
            return (ConsoleColor)r.Next(9, 15);
        }

        private static void DisplayProphecy(string[] prophecy)
        {
            PrintTitle();
            Console.ForegroundColor = primaryColor;
            Console.WriteLine("\t> The Prophecy says:");

            for (int i = 0; i < prophecy.Length; i++)
            {
                Console.ForegroundColor = GetMainColor();
                Thread.Sleep(1000);
                Console.WriteLine($"\t> {prophecy[i].ToUpper()}");
            }
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t------------------");
            Console.WriteLine("\t> Restart [ANYKEY]");
            Console.WriteLine("\t> Quit    [ESCAPE]");
        }

        private static string[] GenerateProphecy(int seed)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "nouns.txt");
            string[] nouns = File.ReadAllLines(path);
            r = new Random(seed);

            string[] prophecy = new string[r.Next(1,5)];

            for (int i = 0; i < prophecy.Length; i++)
            {
                prophecy[i] = nouns[r.Next(0, nouns.Length)];
            }

            return prophecy;
        }

        private static int ReadFeelings()
        {
            Console.ForegroundColor = primaryColor;
            Console.WriteLine("\t> What is on your mind?");
            Console.Write("\t> ");
            Console.ForegroundColor = ConsoleColor.White;

            string feelingSeed = Console.ReadLine();
            int seed = 0;

            for (int i = 0; i < feelingSeed.Length; i++)
            {
                seed += feelingSeed[i];
            }

            return seed;
        }

        private static void PrintTitle(int sleepTime=0)
        {
            Console.ForegroundColor = primaryColor;
            Console.Clear();
            Thread.Sleep(sleepTime);
            Console.WriteLine();
            Console.WriteLine("\t██╗░░████████╗███████╗██████╗░███╗░░░███╗██╗███╗░░██╗░█████╗░██╗░░░░░");
            Console.WriteLine("\t╚██╗░╚══██╔══╝██╔════╝██╔══██╗████╗░████║██║████╗░██║██╔══██╗██║░░░░░");
            Console.WriteLine("\t░╚██╗░░░██║░░░█████╗░░██████╔╝██╔████╔██║██║██╔██╗██║███████║██║░░░░░");
            Console.WriteLine("\t░██╔╝░░░██║░░░██╔══╝░░██╔══██╗██║╚██╔╝██║██║██║╚████║██╔══██║██║░░░░░");
            Console.WriteLine("\t██╔╝░░░░██║░░░███████╗██║░░██║██║░╚═╝░██║██║██║░╚███║██║░░██║███████╗");
            Console.WriteLine("\t╚═╝░░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝╚═╝░░╚═╝╚══════╝");
            Thread.Sleep(sleepTime);
            Console.WriteLine("\t██████╗░██████╗░░░██╗░█████╗░██╗░░██████╗░██╗░░██╗███████╗████████╗░░");
            Console.WriteLine("\t██╔══██╗██╔══██╗░██╔╝██╔══██╗╚██╗░██╔══██╗██║░░██║██╔════╝╚══██╔══╝░░");
            Console.WriteLine("\t██████╔╝██████╔╝██╔╝░██║░░██║░╚██╗██████╔╝███████║█████╗░░░░░██║░░░░░");
            Console.WriteLine("\t██╔═══╝░██╔══██╗╚██╗░██║░░██║░██╔╝██╔═══╝░██╔══██║██╔══╝░░░░░██║░░░░░");
            Console.WriteLine("\t██║░░░░░██║░░██║░╚██╗╚█████╔╝██╔╝░██║░░░░░██║░░██║███████╗░░░██║░░░░░");
            Console.WriteLine("\t╚═╝░░░░░╚═╝░░╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝░░░░░╚═╝░░╚═╝╚══════╝░░░╚═╝░░░░░");
            Console.WriteLine("\t████████████████████████████████████████████████████████████████████╗");
            Console.WriteLine("\t╚═══════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Thread.Sleep(sleepTime);
        }
    }
}
