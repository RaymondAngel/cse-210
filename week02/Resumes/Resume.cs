using System;
using System.Collections.Generic;

// Represents a person's resume and employment history.
public class Resume
{
    // Store the person's name and all jobs included on the resume.
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Display the resume heading followed by every job in the list.
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Let each Job object display its own information.
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
