namespace InClassTest_Task3.Problems;

public static class Problem2
{
    public static void Run()
    {
        Console.WriteLine("Problem 2");
        Console.WriteLine("The smallest number that is divisible by all the numbers from 1 to 20 is: "
                          + FindSmallestDivisibleBy(Enumerable.Range(1, 20).ToArray()));
    }
    
    /// <summary>
    ///  find the smallest number that is divisible by all the numbers in the array.
    /// </summary>
    /// <param name="numbers"> an array of numbers to find the smallest number that is divisible by all of them </param>
    /// <returns> the smallest number that is divisible by all the numbers in the array </returns>
    /*public static int FindSmallestDivisibleBy(int[] numbers)
    {
        int number = 1;
        while (true)
        {
            if (numbers.All(n => number % n == 0))
            {
                return number;
            }
            number++;
        }
    }*/
    // refactor the code to improve efficiency after implementing the initial solution and test cases.
    // Changes Made:
    // - Removed the LINQ method All() as it was taking up too much memory and time for this function.
    public static int FindSmallestDivisibleBy(int[] numbers)
    {
        int number = 1;

        while (true)
        {
            bool divisibleByAll = true;

            foreach (int n in numbers)
            {
                if (number % n == 0) continue;
                divisibleByAll = false;
                break;
            }

            if (divisibleByAll)
            {
                return number;
            }

            number++;
        }
    }

}
