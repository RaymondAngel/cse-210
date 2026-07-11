using System;

class Program
{
    static void Main(string[] args)
    {
        // Create and fill in the first job in the employment history.
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Create and fill in the second job in the employment history.
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // Create the resume and add both Job objects to its job list.
        Resume myResume = new Resume();
        myResume._name = "Allison Rose";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the completed resume.
        myResume.Display();
    }
}
