using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Chromosomes;
using System.Threading;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System;
using System.Linq;

namespace GeneticSharp.Runner.UnityApp.Car
{
    public class CarFitness : IFitness
    {
        public CarFitness()
        {
            ChromosomesToBeginEvaluation = new BlockingCollection<CarChromosome>();
            ChromosomesToEndEvaluation = new BlockingCollection<CarChromosome>();
        }

        public BlockingCollection<CarChromosome> ChromosomesToBeginEvaluation { get; private set; }
        public BlockingCollection<CarChromosome> ChromosomesToEndEvaluation { get; private set; }
        public double Evaluate(IChromosome chromosome)
        {
            var c = chromosome as CarChromosome;
            ChromosomesToBeginEvaluation.Add(c);

            float fitness = 0;
            do
            {
                Thread.Sleep(1000);

                /*YOUR CODE HERE: You should define de fitness function here!!
                 * 
                 * 
                 * You have access to the following information regarding how the car performed in the scenario:
                 * MaxDistance: Maximum distance reached by the car;
                 * MaxDistanceTime: Time taken to reach the MaxDistance;
                 * MaxVelocity: Maximum Velocity reached by the car;
                 * NumberOfWheels: Number of wheels that the cars has;
                 * CarMass: Weight of the car;
                 * IsRoadComplete: This variable has the value 1 if the car reaches the end of the road, 0 otherwise.
                 * 
                */
                float MaxDistance = c.MaxDistance;
                float MaxDistanceTime = c.MaxDistanceTime;
                float MaxVelocity = c.MaxVelocity;
                float NumberOfWheels = c.NumberOfWheels;
                float CarMass = c.CarMass;
                int IsRoadComplete = c.IsRoadComplete ? 1 : 0;
                float nw = (NumberOfWheels > 2 ? 3 : 0);
                fitness = MaxDistance;
                // fitness = (MaxDistance/50 + MaxVelocity / 5 + IsRoadComplete*100 + nw)/ CarMass;
                /* FITNESS FUNCTION HERE!!!
                 * if (MaxDistance > 670)  fitness = 0;
                // else if (NumberOfWheels > 4 || CarMass > 400)  fitness = 0;
                // else fitness = MaxDistance + 2500 * NumberOfWheels/ CarMass; 
                */
                // MaxDistance / 50;// -CarMass/50; // + MaxVelocity / 10 + IsRoadComplete * 100;
                // maxDistance + 2500 * NumberOfWheels/ CarMass -> the hard hill was not overcome in any of the 500 generations
                // now changes were made to make the fitness of cars with too many wheels or too much mass be zero, even though this could harm the selection process.
                c.Fitness = fitness;

            } while (!c.Evaluated);

            ChromosomesToEndEvaluation.Add(c);

            do
            {
                Thread.Sleep(1000);
            } while (!c.Evaluated);


            return fitness;
        }

    }
}