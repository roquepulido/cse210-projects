class Program
{

    static void Main(string[] args)
    {
        GoalManager goalManager = new();
        System.Console.WriteLine("Welcome");
        goalManager.Start();
        System.Console.WriteLine("Goodbye");

        //db.Insert(goal.ToJson(), 1);
        // TableGoal tableGoal = db.SelectById(2);

        // System.Console.WriteLine(tableGoal.ToString());

        // List<TableGoal> list = db.SelectAll();

        // goal.Points = 5000;

        // db.Update(goal.ToJson(), 2);
        // list = db.SelectAll();
        // db.Delete(2);

    }
}