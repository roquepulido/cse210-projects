using System;

class Program
{
    static void Main(string[] args)
    {
        Resume resume = new Resume();
        resume._name = "Allison Rose";
        Job job1 = new Job("Microsoft", "Software Engineer", 1987, 2022);
        Job job2 = new Job("Apple", "Software Engineer", 1990, 2021);
        job1.Display();
        job2.Display();
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume.Display();
    }
}