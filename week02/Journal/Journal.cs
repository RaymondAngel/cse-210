using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Owns the complete collection of journal entries.
public class Journal
{
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
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            IncludeFields = true,
            WriteIndented = true
        };

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

        string json = File.ReadAllText(filename);
        List<Entry> loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json, options);
        _entries = loadedEntries ?? new List<Entry>();
    }
}
