using System;
using System.Runtime.Intrinsics.X86;
using Services.Enums;

namespace Services;

public class PopulationCalculation
{
    /// <summary>
    /// Estimates the population for a given city using a default value.
    /// </summary>
    /// <param name="city">The city for which to estimate the population.</param>
    /// <returns>The estimated population as an integer.</returns>
    public int EstimatedPopulation(Cities city)
    {
        return 1000000;
    }

    
    /// <summary>
    /// Estimates the population for a given city based on an initial population, applying a 1% growth rate.
    /// </summary>
    /// <param name="city">The city for which to estimate the population.</param>
    /// <param name="initialPopulation">The initial population to use as a base for estimation.</param>
    /// <returns>The estimated population after applying the growth rate.</returns>
    public int EstimatedPopulation(Cities city, int initialPopulation)
    {
        return (int)(initialPopulation * 1.01); 
    }
}
