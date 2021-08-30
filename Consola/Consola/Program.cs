using System;
using System.Diagnostics;

namespace Path
{
    class Program
    {
        static Stopwatch timer = new Stopwatch();
        static void Main(string[] args)
        {
            SearchPath sp = new SearchPath();
            timer.Start();

            sp.CreateNodes();
            sp.BFS();
            sp.CreatePath();
            sp.GetPath();

            timer.Stop();
            Console.WriteLine("The time the program took was: " + timer.ElapsedMilliseconds + " miliseconds");


        }
    }
}