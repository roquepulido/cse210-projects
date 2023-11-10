class WorkingScripture
{
    private List<WordWork> _words = new();

    public List<WordWork> Words
    {
        set { _words = value; }
        get { return _words; }
    }
    public void Clear()
    {
        this.Words.Clear();
    }

    public void SetVerses(List<Verse> verses)
    {
        string[] arrayText;
        verses.ForEach(delegate (Verse verse)
        {
            arrayText = verse.GetWordList();
            foreach (string text in arrayText)
            { this.Words.Add(new WordWork(text)); }
        });
    }
    public void PrintVerses()
    {
        Console.Clear();
        this.Words.ForEach(delegate (WordWork word)
        {
            Console.Write($"{word.Print()} ");
        });
        Console.WriteLine();
    }
    public void Clearlist()
    {
        this.Words.Clear();
    }
    private bool SetRandomHide(int times = 3)
    {
        var rand = new Random();
        List<int> unhiddenIndex = new();
        for (int i = 0; i < Words.Count; i++)
        {
            if (!Words[i].IsHidden) unhiddenIndex.Add(i);
        }
        if (unhiddenIndex.Count == 0) return false;
        for (int i = 0; i < times; i++)
        {
            if (unhiddenIndex.Count != 0)
            {
                int randIndex = rand.Next(unhiddenIndex.Count);
                Words[unhiddenIndex[randIndex]].IsHidden = true;
                unhiddenIndex.RemoveAt(randIndex);
            }
        }
        return true;
    }
    public void Start()
    {
        do
        {
            this.PrintVerses();
            Console.WriteLine();
            Console.WriteLine("Press enter to continue hidding words or type quit for back to the menu.");
            string op = Console.ReadLine();
            if (op == "quit" || op == "QUIT" || op == "Quit" || op == "qUIT" || op == "Q" || op == "q")
            {
                return;
            }
        } while (this.SetRandomHide());
        Console.WriteLine("End of this scripture, I hope you have been able to memorize.");
        Console.WriteLine("Press enter to back to the menu.");
        Console.ReadLine();
    }
}