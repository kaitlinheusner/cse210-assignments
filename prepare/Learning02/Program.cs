using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new();
        job1._company = "Microsoft";
        job1._jobtitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2022; 

        Job job2 = new();
        job2._company = "Apple";
        job2._jobtitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume resume = new();
        resume._name = "Allison Rose";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume.Display();
    }
}

