using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAgTest
{
    class Evo
    {
              

        bool[][] population = new bool[1000][];
        bool[][] nextGeneration = new bool[1000][];

        int[] evaluation = new int[1000];

        int genCounter;

        public int highestEvo;

        float mutationRate = 0.0001f;

        Random random = new Random();

        public void CreatePopulation()
        {
            random = new Random();

            for (int i = 0; i < population.GetLength(0); i++)
            {    
                population[i] = CreateGen();
            }
        }


        public void CreateNextGen()
        {
            genCounter = 0;
            int counter = 0;
            foreach (bool[] b in population)
            {
                evaluation[counter++] = Evaluate(b);
            }

            int highestEvaluation = HighestEvaluation();
            
            for (int i = 0; i < evaluation.Length; i++)
            {
                if (evaluation[i] > highestEvaluation / 2 || random.Next(0,100)>95)
                {
                    Mutate(ref population[i]);
                    nextGeneration[genCounter++] = population[i];
                }
            }

            for (int i = genCounter; i < 800; i++)
            {
                nextGeneration[i] = Combine(nextGeneration[random.Next(0,genCounter)],nextGeneration[random.Next(0,genCounter)]);
            }

            for (int i = 800; i < 1000; i++)
            {
                nextGeneration[i] = CreateGen();
            }

            population = nextGeneration;

        }

        public bool[] CreateGen()
        {
            bool[] gen = new bool[10];

            for (int j = 0; j < 10; j++)
            {
                gen[j] = random.Next(0, 100) > 99 ? true : false;
            }
            return gen;
        }

        public static int Evaluate(bool[] bArray)
        {
            int counter = 0;
            foreach (bool b in bArray)
            {
                if(b)
                {
                    counter++;
                }
            }
            return counter;
        }

        public int HighestEvaluation()
        {
            int count = 0;
            int highestIndex = 0;
            for (int i = 0; i < evaluation.Length; i++)
            {
                if(evaluation[i]>count)
                {
                    highestEvo = count = evaluation[i];
                    highestIndex = i;
                }
            }
            Console.WriteLine("Highest Evolution: " +highestEvo);
            return count;
        }

        public bool[] Combine(bool[] b1, bool[] b2)
        {
            bool[] tmpArray = new bool[10];

            int range = random.Next(0, b1.Length);

            for (int i = 0; i < b1.Length; i++)
            {
                tmpArray[i] = i <= range ? b1[i] : b2[i];
            }
            return tmpArray;
        }

        public void Mutate( ref bool[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if(random.Next(0,(int)(1/mutationRate))==1)
                {
                    b[i] = !b[i];
                }
            }            
        }

        public void Statistic()
        {
            int[] stats = new int[10];
            for (int i = 0; i < stats.Length; i++)
            {
                stats[i] = 0;
            }

            foreach (int i in evaluation)
            {
                stats[i]++;
            }
            Console.WriteLine();
            int counter = 0;
            foreach (int i in stats)
            {
                Console.WriteLine(++counter + ": " + i);
            }
        }


        public void WritePopulationOnScreen()
        {
            foreach (bool[] bArray in population)
            {
                Console.WriteLine();
                foreach (bool b in bArray)
                {
                    Console.WriteLine(b);
                }
                
            }
        }
    }
}
