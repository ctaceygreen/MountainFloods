using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int maxFloodDepth = 0;
        int currentPeak = 0;
        int currentTrough = 0;
        int latestHeight = 0;
        bool withinAFlood = false;
        for(int i = 0; i < A.Length; i++)
        {
            int height = A[i];
            if (height > latestHeight)
            {
                if (withinAFlood)
                {
                    maxFloodDepth = Math.Max(maxFloodDepth, Math.Min(currentPeak, height) - currentTrough);
                }
            }
            if (height >= currentPeak)
            {
                currentPeak = height;
                currentTrough = height;
                withinAFlood = false;
            }
            else if(height < currentTrough)
            {
                withinAFlood = true;
                currentTrough = height;
            }
            latestHeight = A[i];
        }
        //Also do at the end because we might have not have chance to finish the peak again
        maxFloodDepth = Math.Max(maxFloodDepth, A[A.Length - 1] - currentTrough);
        return maxFloodDepth;
    }
}