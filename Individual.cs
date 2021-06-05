using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_9
{
    class Individual
    {

        private int[] genome = new int[4];
        public float likelihood { get; Sset; }
        public int[] GetGenome()
        {
            return genome;
        }
        public void SetGenome(int[] newgenome)
        {
            genome = newgenome;
        }

        public Individual(int a, int b, int c, int d)
        {
            genome[0] = a;
            genome[1] = b;
            genome[2] = c;
            genome[3] = d;
        }

        public int Fitness()
        {
            return genome[0] + 2 * genome[1] + 3 * genome[2] + 4 * genome[3] - 30;
        }
        
        public void Mutate()
        {
            Random rand = new Random();
            var rnd = rand.Next(4);
            genome[rnd] = rand.Next(31); 
        }

        public String ToString()
        {
            var result = new String("[ ");
            for(int i=0; i< 4; i++)
            {
                result += genome[i] + " ";
            }
            result += "]";
            return result;
        }



    }
}
