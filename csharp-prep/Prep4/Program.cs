using System;

class Program
{
    static void Main(string[] args)
    {
        string inputUser;
        List<int> numberList = new List<int>();
        List<int> sortedNumberList = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            inputUser = Console.ReadLine();

            if (inputUser != "0" && inputUser != "") numberList.Add(int.Parse(inputUser));
        } while (inputUser != "0");
        numberList.Sort();
        int sumNumber = numberList.Aggregate(0, (accum, current) => accum + current);
        float aveNumber = (float)sumNumber / numberList.Count;
        int largestNumber = numberList[(numberList.Count - 1)];
        int smallestNumber = numberList.Aggregate(largestNumber, (carry, actual) =>
        {
            if (carry > actual && actual > 0)
            {
                return actual;
            }
            return carry;
        });

        Console.WriteLine($"The sum is: {sumNumber}");
        Console.WriteLine($"The average  is: {aveNumber:0.000}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestNumber}");
        Console.WriteLine($"The sorted list is:");
        foreach (int number in numberList)
        {
            Console.WriteLine($"{number}");
        }
    }
}