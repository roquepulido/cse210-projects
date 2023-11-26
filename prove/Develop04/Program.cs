using System;
///
/// 
/// Autor: Roque Alberto Pulido Morales
/// Github: https://github.com/roquepulido
/// 
/// Program: Prove: Developer—Mindfulness
/// Objective: Consider an app that provides three different kinds of mindfulness opportunities.
/// It could give some guidance and structure to users in the following activities:
/// 
/// * Breathing Activity - Help the user pace their breathing to have a session of deep breathing 
/// for a certain amount of time. They might find more peace and less stress through the exercise.
/// 
/// * Reflection Activity - Guide the user to think deeply, by having them consider a certain experience 
/// when they were successful or demonstrated strength. Then, prompt them with questions to reflect more 
/// deeply about details of this experience. They might discover more depth than they previously realized.
/// 
/// * Listing Activity - Guide the user to think broadly, by helping them list as many things as they can 
/// in a certain area of strength or positivity. They might discover more breadth than they previously realized.
/// The application could additional help the user keep track of the time or frequency they spend in these 
/// activities and give them gentle prompts and reminders.
/// 
/// ** Exceeds core requirements:
/// 
///     - Added a new class for slow print, instead of just printing all the text this class provides a method to print the string,
///     so this starts typing letter by letter.
///     - Added the feature in the menu to avoid mistaken options typed.
///     - Added the feature in the method DisplayStartingMessage in the class Activity when asking for the duration of the session,
///     for ask again in case don't type a number.
///     - In the Reflecting Activity add the feature for don't have duplicated prompt questions and if all the prompt questions
///     are shown the loop ends and prints the actual time of the session.
///     
///
class Program
{
    static int DisplayMenu()
    {
        ConsoleKeyInfo option;
        int number = 0;
        while (number == 0)
        {
            Console.Clear();
            SlowPrintConsole.WriteLine("Menu Options:");
            SlowPrintConsole.WriteLine("\t1. Start breathing activity");
            SlowPrintConsole.WriteLine("\t2. Start reflecting activity");
            SlowPrintConsole.WriteLine("\t3. Start listing activity");
            SlowPrintConsole.WriteLine("\t4. Quit");
            SlowPrintConsole.Write("Select a choice from the menu: ");

            option = Console.ReadKey();
            Console.WriteLine();

            switch (option.KeyChar)
            {
                case '1':
                    number = 1;
                    break;
                case '2':
                    number = 2;
                    break;
                case '3':
                    number = 3;
                    break;
                case '4':
                    number = 4;
                    break;

                default:
                    number = 0;
                    SlowPrintConsole.WriteLine($"The option '{option.KeyChar}' is no correct. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
        return number;
    }
    static void Main(string[] args)
    {
        int option = 0;
        BreathingActivity breathingActivity = new();
        ReflectingActivity reflectingActivity = new();
        ListingActivity listingActivity = new();
        SlowPrintConsole.Speed = 30;
        Console.CursorVisible = false;
        while (option != 4)
        {
            option = DisplayMenu();
            switch (option)
            {
                case 1:
                    breathingActivity.Run();
                    break;
                case 2:
                    reflectingActivity.Run();
                    break;
                case 3:
                    listingActivity.Run();
                    break;
            }
        }
        SlowPrintConsole.WriteLine("Good bye.");
    }
}