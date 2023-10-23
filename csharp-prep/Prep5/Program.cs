using System;

class Program
{   
    static string name;
    static int favoriteNumber;
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the program!");
    }
    static void PromptUserName(){
         Console.WriteLine("Please enter your name: ");
         name = Console.ReadLine();
    }
    static void PromptUserNumber (){
         Console.WriteLine("Please enter your favorite number: ");
         favoriteNumber = int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number){
        return number * number;
    }
    static void DisplayResult (){
         Console.WriteLine($"{name}, the square of your number is {SquareNumber(favoriteNumber)}");

    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        PromptUserName();
        PromptUserNumber();
        DisplayResult();
    }
}