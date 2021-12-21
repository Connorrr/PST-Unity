using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomNumbers
{
    /// <summary>
    /// Generates a random index between (and including) the upper and lower range.  
    /// If the random value that is frst selected is in the excluding list then it will shift up and down the range until 
    /// a unique variable has been seleceted.
    /// </summary>
    /// <param name="lowerRange"></param>
    /// <param name="upperRange"></param>
    /// <param name="excluding"></param>
    /// <returns></returns>
    public static int getRandomNumberExcluding(int lowerRange, int upperRange, List<int> excluding)
    {
        int value = 0;

        System.Random rnd = new System.Random();
        value = rnd.Next(lowerRange, upperRange);
        bool isGoingUp = true;

        while (excluding.Contains(value))
        {
            if (value == lowerRange)
            {
                isGoingUp = true;
                value += 1; ;
            }
            else if (value == upperRange)
            {
                isGoingUp = false;
                value -= 1;
            }
            else
            {
                if (isGoingUp)
                {
                    value += 1;
                }
                else
                {
                    value -= 1;
                }
            }
        }

        return value;
    }

    /// <summary>
    /// This ist the same as the Get Random number excluding except this time the RandomNumber object is passed thorugh
    /// </summary>
    /// <param name="rnd">The random number object</param>
    /// <param name="lowerRange"></param>
    /// <param name="upperRange"></param>
    /// <param name="excluding"></param>
    /// <returns></returns>
    public static int getRandomNumberExcludingWRand(System.Random rnd, int lowerRange, int upperRange, List<int> excluding)
    {
        int value = 0;

        value = rnd.Next(lowerRange, upperRange);
        bool isGoingUp = true;

        while (excluding.Contains(value))
        {
            if (value == lowerRange)
            {
                isGoingUp = true;
                value += 1; ;
            }
            else if (value == upperRange)
            {
                isGoingUp = false;
                value -= 1;
            }
            else
            {
                if (isGoingUp)
                {
                    value += 1;
                }
                else
                {
                    value -= 1;
                }
            }
        }

        return value;
    }
}
