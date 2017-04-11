using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAgTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Evo evolution = new Evo();

            evolution.CreatePopulation();
            int generation = 0;
            while(evolution.highestEvo <9)
            {
                Console.WriteLine("Generation: " + generation++);
                evolution.CreateNextGen();
                evolution.Statistic();
            }

            //evolution.WritePopulationOnScreen();

            Console.ReadLine();
        }
    }
}
