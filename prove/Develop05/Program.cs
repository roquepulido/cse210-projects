/// <summary>
/// Goal Program
/// 
/// Exceeds core requirements:
/// 
/// 1. Added the feature of saving all de data in an online database.
/// 2. All the input data are validated to avoid mistaken typing.
/// 3. All object is Serialize to JSON to be saved in the Database
/// </summary>
class Program
{

    static void Main(string[] args)
    {
        GoalManager goalManager = new();
        System.Console.WriteLine("Welcome");
        goalManager.Start();
        System.Console.WriteLine("Goodbye");

    }
}