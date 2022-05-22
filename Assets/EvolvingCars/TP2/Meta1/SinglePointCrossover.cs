using GeneticSharp.Domain.Chromosomes;
using System;
using System.Linq;
using UnityEngine;
using GeneticSharp.Domain.Randomizations;
using System.Collections.Generic;
using GeneticSharp.Domain.Crossovers;

/*
    AIF Project 2
    André Carvalho, no.2019216156
    Paulo Cortesão, no.2019216517
*/

namespace GeneticSharp.Runner.UnityApp.Commons
{
    public class SinglePointCrossover : ICrossover
    {




        public int ParentsNumber { get; private set; }

        public int ChildrenNumber { get; private set; }

        public int MinChromosomeLength { get; private set; }

        public bool IsOrdered { get; private set; } // indicating whether the operator is ordered (if can keep the chromosome order).

        protected float crossoverProbability;


        public SinglePointCrossover(float crossoverProbability) : this(2, 2, 2, true)
        {
            this.crossoverProbability = crossoverProbability;
        }

        public SinglePointCrossover(int parentsNumber, int offSpringNumber, int minChromosomeLength, bool isOrdered)
        {
            ParentsNumber = parentsNumber;
            ChildrenNumber = offSpringNumber;
            MinChromosomeLength = minChromosomeLength;
            IsOrdered = isOrdered;
        }

        public IList<IChromosome> Cross(IList<IChromosome> parents)
        {
            IChromosome parent1 = parents[0];
            IChromosome parent2 = parents[1];
            IChromosome offspring1 = parent1.CreateNew();
            IChromosome offspring2 = parent2.CreateNew();

            //YOUR CODE HERE
            int i = 0;
            if (RandomizationProvider.Current.GetDouble() <= crossoverProbability) // with probability crossoverProbability, perform crossover
            {
                var cutPoint = RandomizationProvider.Current.GetInt(1, parent1.Length); // determine the cut point
                while (i < cutPoint)
                {
                    offspring1.ReplaceGene(i, parent2.GetGene(i)); // replace the genes in the offspring
                    offspring2.ReplaceGene(i, parent1.GetGene(i));
                    i++;
                }
            }

            //end of pseudo code




            return new List<IChromosome> { offspring1, offspring2 };

        }
    }
}