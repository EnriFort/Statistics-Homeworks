using System;

public class RandomNumberGenerator
{
    private Random random = new Random();

    public int GenerateWithProbability(double p, int x, int y)
    {
        if (random.NextDouble() < p)
        {
            return x;
        }
        else
        {
            return y;
        }
    }
}







