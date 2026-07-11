using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Owns the complete collection of journal entries.
public class Journal
{
    // Keep all Entry objects together in one list.
    public List<Entry> _entries = new List<Entry>();

    // Add one completed entry to the journal.
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Ask each entry to display itself.
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Save every entry as formatted JSON, including public fields.
    public void SaveToFile(string filename)
    {
        // IncludeFields is needed because Entry stores its data in public fields.
        // WriteIndented makes the saved JSON file easier for people to read.
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true,
            WriteIndented = true
        };

        // Convert the complete entry list to JSON and write it to the file.
        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(filename, json);
    }

    // Replace the current entries with those stored in the selected file.
    public void LoadFromFile(string filename)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true
        };

        // Read the complete file and convert its JSON back into Entry objects.
        string json = File.ReadAllText(filename);
        List<Entry> loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json, options);

        // Loading replaces the current journal, as required by the assignment.
        // If the saved JSON contains null, use an empty list instead.
        _entries = loadedEntries ?? new List<Entry>();
    }
}
