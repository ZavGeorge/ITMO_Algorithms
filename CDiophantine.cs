using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_lab_9
{
    class CDiophantine
    {
        public List<Individual> population = new List<Individual>();
        public int CountOfIndividuals  { get; private set; }

        public CDiophantine(int countofindividuals)
        {
            Random rand = new Random();
            CountOfIndividuals = countofindividuals;
            for(int i =0; i < CountOfIndividuals; i++)
            {
                
                population.Add(new Individual(rand.Next(30), rand.Next(30), rand.Next(30), rand.Next(30)));

            }
        }

        public void Cross(Individual ind1, Individual ind2)
        {
            var genome1 = ind1.GetGenome();
            var genome2 = ind2.GetGenome();

            Random rand = new Random();
            var crossindex = rand.Next(4);

            if (crossindex == genome1.Length - 1)
            {
                var tmp = genome1[crossindex];
                genome1[crossindex] = genome2[crossindex];
                genome2[crossindex] = tmp;
                ind1.SetGenome(genome1);
                ind2.SetGenome(genome2);
            }
            else
            {
                var tmp = genome1;
                for (int i =crossindex; i< genome1.Length; i++)
                {
                    genome1[i] = genome2[i];
                    genome2[i] = tmp[i];
                }
                ind1.SetGenome(genome1);
                ind2.SetGenome(genome2);
            }
        }

        public Individual Generate(Individual ind1, Individual ind2)
        {
            Random rand = new Random();

            var genome1 = ind1.GetGenome();
            var genome2 = ind2.GetGenome();

            var genomes = new int[8];
            for(int i=0; i < 4; i++)
            {
                genomes[i] = genome1[i];
                genomes[i + 4] = genome2[i];
            }
            var newgenome = new int[4];
            for(int i =0; i <4; i++)
            {
                genomes[i] = genomes[rand.Next(genomes.Length)];

            }

            return new Individual(newgenome[0], newgenome[1], newgenome[2], newgenome[3]);
        }

        public void Selection(double MutationCoefficient)
        {
            Random rand = new Random();
            var numberOfSelections = rand.Next(population.Count);

            for(int i =0; i < numberOfSelections; i++)
            {
                var index1 = rand.Next(population.Count);
                var index2 = rand.Next(population.Count);
                Cross(population[index1], population[index2]);
            }

            for(int i =0; i< numberOfSelections/2; i++)
            {
                var index1 = rand.Next(population.Count);
                var index2 = rand.Next(population.Count);
                population.Add(Generate(population[index1], population[index2]));
            }

            for(int i=0; i< numberOfSelections* MutationCoefficient; i++)
            {
                var index = rand.Next(population.Count);
                population[index].Mutate();
            }

        }


    }
}
