using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Randomizations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Infrastructure.Framework.Texts;
using GeneticSharp.Runner.UnityApp.Car;

public class Tournament : SelectionBase
{
    protected int Size { get; set; }
    public Tournament() : this(2)
    {
    }



    public Tournament(int size) : base(2)
    {
        Size = size;
    }

    protected override IList<IChromosome> PerformSelectChromosomes(int number, Generation generation)
    {

        //YOUR CODE HERE
        IList<CarChromosome> population = generation.Chromosomes.Cast<CarChromosome>().ToList(); // Current Population: We will select individuals from here 
        IList<IChromosome> parents = new List<IChromosome>(); //List that will return the individuals that will mate, i.e. that will undergo variation
        for (int i = 0; i < number; i++)
        {
            var randomIndexes = RandomizationProvider.Current.GetUniqueInts(Size, 0, population.Count);
            CarChromosome winner = null;
            double winnerFitness = -1.0;
            for (int k = 0; k < Size; k++)
            {
                int individualIndex = randomIndexes[k];
                if (winner == null || population[individualIndex].Fitness > winnerFitness)
                {
                    winner = population[individualIndex];
                    winnerFitness = winner.Fitness;
                }
            }
            parents.Add(winner);
        }
        //end of pseudo code
        return parents;
    }
}
