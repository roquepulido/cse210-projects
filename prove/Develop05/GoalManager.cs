using System.Text.Json;

class GoalManager
{
    private List<Goal> _goals;
    public List<Goal> Goals
    {
        get { return _goals; }
        set { _goals = value; }
    }
    private int _score;
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    private DBConnect db;

    public GoalManager(List<Goal> goals, int score)
    {
        this.Goals = goals;
        this.Score = score;
    }
    public GoalManager()
    {
        this.Goals = new();
        this.Score = 0;
        this.db = new();
    }
    enum GoalType
    {
        Simple = 1,
        Eternal,
        CheckList
    }
    public void Start()
    {
        int option;
        bool keep = true;
        this.LoadGoals();
        while (keep)
        {
            option = this.MenuDisplay();
            switch (option)
            {
                case 1: // Create Goals
                    this.CreateGoal();
                    break;

                case 2: // List Goals
                    this.ListGoalDetails();
                    break;

                case 3: // Record Goal
                    this.RecordEvent();
                    break;
                case 4:// Quit
                    keep = false;
                    break;
            }
        }

    }
    private int MenuDisplay()
    {
        ConsoleKeyInfo option;
        int number = 0;
        while (number == 0)
        {
            System.Console.Clear();
            this.DisplayPlayerInfo();
            System.Console.WriteLine("Menu Options:");
            System.Console.WriteLine("\t1. Create New Goal");
            System.Console.WriteLine("\t2. List Goals");
            System.Console.WriteLine("\t3. Record Goal");
            System.Console.WriteLine("\t4. Quit");
            System.Console.Write("Select a choice from the menu: ");

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
                    System.Console.WriteLine($"The option '{option.KeyChar}' is no correct. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
        return number;
    }
    public void DisplayPlayerInfo()
    {
        System.Console.WriteLine($"-------Player Info-------");
        System.Console.WriteLine($"You have {this.Goals.Count} goals.");
        System.Console.WriteLine($"You you score is: {this.Score}.");
        System.Console.WriteLine();
    }
    public void ListGoalNames()
    {
        System.Console.WriteLine("Goal names:");
        int index = 1;
        this.Goals.ForEach(goal =>
        {
            if (goal.IsComplete())
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"{index}. {goal.ShortName}");
                System.Console.ResetColor();

            }
            else
            {
                System.Console.WriteLine($"{index}. {goal.ShortName}");
            }
            index += 1;
        });
        System.Console.WriteLine();
    }
    public void ListGoalDetails()
    {
        System.Console.Clear();
        System.Console.WriteLine("Goal details:");
        int index = 1;
        this.Goals.ForEach(goal =>
        {
            System.Console.WriteLine($"{index}. {goal.GetDetailsString()}");
            index += 1;
        });
        System.Console.WriteLine();
        System.Console.WriteLine("Press any key to continue");
        System.Console.ReadKey();
    }
    public void CreateGoal()
    {
        string select, name, desc, points;
        int option = 0;

        while (option == 0)
        {
            System.Console.Clear();
            System.Console.WriteLine("Create new Goal, select type:");
            System.Console.WriteLine("1. Simple Goal");
            System.Console.WriteLine("2. Eternal Goal");
            System.Console.WriteLine("3. Check List Goal");
            select = System.Console.ReadLine();
            switch (select)
            {
                case "1":
                    option = 1;
                    break;
                case "2":
                    option = 2;
                    break;
                case "3":
                    option = 3;
                    break;
                default:
                    System.Console.WriteLine("Opcion invalida. Press any key to continue.");
                    System.Console.ReadKey();
                    option = 0;
                    break;
            }
        }

        System.Console.Write("Enter a name for the goal: ");
        name = System.Console.ReadLine();
        System.Console.WriteLine();
        System.Console.Write("Enter a description for the goal: ");
        desc = System.Console.ReadLine();
        System.Console.WriteLine();
        System.Console.Write("Enter the base points for the goal: ");
        points = System.Console.ReadLine();
        System.Console.WriteLine();
        while (!int.TryParse(points, out _))
        {
            System.Console.WriteLine($"{points} is not a number.");
            System.Console.Write("Enter the base points for the goal: ");
            points = System.Console.ReadLine();
            System.Console.WriteLine();
        }
        int rowCreated;
        switch (option)
        {
            case 1:
                SimpleGoal sg = new(name, desc, int.Parse(points));
                if (db.IsOnline)
                {
                    rowCreated = db.Insert(JsonSerializer.Serialize<SimpleGoal>(sg), (int)GoalType.Simple);
                    sg.IdGoal = rowCreated;
                }
                this.Goals.Add(sg);
                break;
            case 2:
                EternalGoal eg = new(name, desc, int.Parse(points));
                if (db.IsOnline)
                {
                    rowCreated = db.Insert(JsonSerializer.Serialize<EternalGoal>(eg), (int)GoalType.Eternal);
                    eg.IdGoal = rowCreated;
                }
                this.Goals.Add(eg);
                break;
            case 3:
                string bonus, target;
                System.Console.Write("Enter the target of times for the goal: ");
                target = System.Console.ReadLine();
                System.Console.WriteLine();
                while (!int.TryParse(target, out _))
                {
                    System.Console.WriteLine($"{target} is not a number.");
                    System.Console.Write("Enter the target of times for the goal: ");
                    target = System.Console.ReadLine();
                    System.Console.WriteLine();
                }
                System.Console.Write("Enter the bonus points for the goal: ");
                bonus = System.Console.ReadLine();
                System.Console.WriteLine();
                while (!int.TryParse(target, out _))
                {
                    System.Console.WriteLine($"{bonus} is not a number.");
                    System.Console.Write("Enter the bonus points for the goal: ");
                    bonus = System.Console.ReadLine();
                    System.Console.WriteLine();
                }

                ChecklistGoal chg = new(name, desc, int.Parse(points), int.Parse(target), int.Parse(bonus));
                if (db.IsOnline)
                {
                    rowCreated = db.Insert(JsonSerializer.Serialize<ChecklistGoal>(chg), (int)GoalType.CheckList);
                    chg.IdGoal = rowCreated;
                }
                this.Goals.Add(chg);
                break;
        }

    }
    public void RecordEvent()
    {

        int optionNum = 0;
        System.Console.WriteLine("-------Record event-------");
        System.Console.WriteLine("Select the goal to record the event: (Green completed)");
        this.ListGoalNames();
        System.Console.Write("Goal to record: ");
        string option = System.Console.ReadLine();
        do
        {

            while (!int.TryParse(option, out _))
            {
                System.Console.WriteLine($"{option} is not a number.");
                System.Console.Write("Select the goal to record the event: ");
                option = System.Console.ReadLine();
                System.Console.WriteLine();
            }
            optionNum = int.Parse(option);

            if (optionNum < 1 || optionNum > this.Goals.Count)
            {
                System.Console.WriteLine($"{option} is not a option.");
                System.Console.Write("Select the goal to record the event: ");
                option = System.Console.ReadLine();
                System.Console.WriteLine();
            }

        } while (optionNum < 1 || optionNum > this.Goals.Count);
        int index = optionNum - 1;
        this.Score += this.Goals[index].RecordEvent();
        if (this.db.IsOnline)
        {
            this.db.Update(JsonSerializer.Serialize(this.Goals[index], this.Goals[index].GetType()), this.Goals[index].IdGoal);
        }
    }
    public void LoadGoals()
    {
        List<TableGoal> list = db.SelectAll();
        list.ForEach(goal =>
        {
            switch (goal.GoalType)
            {
                case (int)GoalType.Simple:
                    SimpleGoal sg = JsonSerializer.Deserialize<SimpleGoal>(goal.GoalJson);
                    this.Goals.Add(sg);
                    if (sg.IsComplete())
                    {
                        this.Score += sg.Points;
                    }
                    if (sg.IdGoal == 0)
                    {
                        sg.IdGoal = goal.Id;
                    }
                    break;
                case (int)GoalType.Eternal:
                    EternalGoal eg = JsonSerializer.Deserialize<EternalGoal>(goal.GoalJson);
                    this.Goals.Add(eg);
                    if (eg.TimesDone > 0)
                    {
                        this.Score += eg.Points * eg.TimesDone;
                    }
                    if (eg.IdGoal == 0)
                    {
                        eg.IdGoal = goal.Id;
                    }
                    break;
                case (int)GoalType.CheckList:
                    ChecklistGoal chg = JsonSerializer.Deserialize<ChecklistGoal>(goal.GoalJson);
                    this.Goals.Add(chg);
                    if (chg.AmountCompleted > 0)
                    {
                        this.Score += chg.AmountCompleted * chg.Points;
                        if (chg.IsComplete()) { this.Score += chg.Bonus; }
                    }
                    if (chg.IdGoal == 0)
                    {
                        chg.IdGoal = goal.Id;
                    }
                    break;

            }
        });

    }

}