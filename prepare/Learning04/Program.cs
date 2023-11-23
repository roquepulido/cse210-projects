using System;

class Program
{
    static void Main(string[] args)
    {
        WritingAssignment assignment = new("Samuel Bennett","Multiplication", "sec 7.3");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(assignment.GetWrithingInformation());
    }
}