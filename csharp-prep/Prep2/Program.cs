class Program
{
    static void Main(string[] args)
    {
        string gradeLetter = "";
        Console.Write("What is the grade in number to convert to letter?    ");
        string grade = Console.ReadLine();
        int gradeNumber = int.Parse(grade);
        if (gradeNumber == 100)
        {
            gradeLetter += "A";
        }
        else if (gradeNumber >= 90)
        {
            gradeLetter += "A";
            if (gradeNumber % 10 < 3) { gradeLetter += "-"; }
        }
        else if (gradeNumber >= 80)
        {
            gradeLetter += "B";
            if (gradeNumber % 10 >= 7) { gradeLetter += "+"; }
            else if (gradeNumber % 10 < 3) { gradeLetter += "-"; }
        }
        else if (gradeNumber >= 70)
        {
            gradeLetter += "C";
            if (gradeNumber % 10 >= 7) { gradeLetter += "+"; }
            else if (gradeNumber % 10 < 3)
            {
                gradeLetter += "-";
            }
        }
        else if (gradeNumber >= 60)
        {
            gradeLetter += "D";
            if (gradeNumber % 10 >= 7) { gradeLetter += "+"; }
            else if (gradeNumber % 10 < 3) { gradeLetter += "-"; }
        }
        else
        {
            gradeLetter += "F";
        }
        Console.WriteLine($"The grade is: {gradeLetter}");

        if (gradeNumber >= 70)
        {
            Console.WriteLine("You passed XD!");
        }
        else
        {
            Console.WriteLine("Sorry Bro :(!");
        }
    }
}