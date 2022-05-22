using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Reinsertions;

/*
    AIF Project 2
    André Carvalho, no.2019216156
    Paulo Cortesão, no.2019216517
*/
public class Elitism : ReinsertionBase
{
    protected int eliteSize = 2;
    public Elitism(int eliteSize) : base(false, false)
    {
        this.eliteSize = eliteSize;
    }

    protected override IList<IChromosome> PerformSelectChromosomes(IPopulation population, IList<IChromosome> offspring, IList<IChromosome> parents)
    {
        // YOUR CODE HERE
        var old_population = population.CurrentGeneration.Chromosomes.OrderByDescending(p => p.Fitness).ToList(); //previous population sorted by fitness

        for (int i = 0; i < eliteSize; i++)
            offspring[i] = old_population[i];
        // the *eliteSize* fittest cars will belong to the next generation without suffering changes
        
        return offspring;
    }

}
