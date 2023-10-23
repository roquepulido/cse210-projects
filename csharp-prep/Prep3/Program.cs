using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepPlaying = true;
        int rndNum, numTry = 0, guessNum;
        string continueGame, guessLetter;
        Random randomGenerator = new Random();
        rndNum = randomGenerator.Next(1, 101);

        while (keepPlaying)
        {
            numTry++;
            Console.Write("What is your guess? ");
            guessLetter = Console.ReadLine();
            if (guessLetter == "") { guessNum = 0; }
            else { guessNum = int.Parse(guessLetter); }
            if (guessNum == 0)
            {
                Console.WriteLine("You put blank write a number please!!!");
            }
            else if (guessNum < rndNum)
            {
                Console.WriteLine("Lower!!!");
            }
            else if (guessNum > rndNum)
            {
                Console.WriteLine("Higher!!!");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"And just take {numTry} times.");
                Console.Write("Do you want to start again? (Y)es/(N)o ");
                continueGame = Console.ReadLine();
                if (continueGame == "No" || continueGame == "N" || continueGame == "no" || continueGame == "n")
                {
                    keepPlaying = false;
                }
                else
                {
                    numTry = 0;
                    rndNum = randomGenerator.Next(1, 101);
                }
            }
        }
        Console.WriteLine("See you next time...");
    }
}