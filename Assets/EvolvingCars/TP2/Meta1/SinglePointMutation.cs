using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;

public class SinglePointMutation : IMutation
{
    public bool IsOrdered { get; private set; } // indicating whether the operator is ordered (if can keep the chromosome order).

    public SinglePointMutation()
    {
        IsOrdered = true;
    }


    public void Mutate(IChromosome chromosome, float probability)
    {
        //YOUR CODE HERE

        int i = 0;
        while (i < chromosome.Length)
        {

            if (RandomizationProvider.Current.GetDouble() <= probability)
            {
                var geneValue = chromosome.GetGene(i).Value;
                if ((int)geneValue == 1)
                    chromosome.ReplaceGene(i, new Gene(0));
                else
                    chromosome.ReplaceGene(i, new Gene(1));

                i++;
            }
        }

        //end of pseudo code
    }

}
