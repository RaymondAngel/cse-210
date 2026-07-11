using System;

// Represents one job in a person's employment history.
public class Job
{
    // Store the information needed to describe this job.
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // Display the job information in the required resume format.
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
