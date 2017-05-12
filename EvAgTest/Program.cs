using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EvAgTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Evo evolution = new Evo();

            evolution.CreatePopulation();
            int generation = 0;
            while(evolution.highestEvo <10)
            {
                Console.Clear();
                Console.WriteLine("Generation: " + generation++);
                evolution.CreateNextGen();
                evolution.Statistic();
                Thread.Sleep(35);
            }

            //evolution.WritePopulationOnScreen();

            Console.ReadLine();
        }
    }
}
