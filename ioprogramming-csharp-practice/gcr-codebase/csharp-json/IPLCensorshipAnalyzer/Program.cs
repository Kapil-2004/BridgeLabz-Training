using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("IPLCensorshipAnalyzer - starting...");
        var baseDir = AppContext.BaseDirectory;

        var jsonIn = Path.Combine(baseDir, "matches.json");
        var csvIn = Path.Combine(baseDir, "matches.csv");

        if (File.Exists(jsonIn)) ProcessJson(jsonIn, Path.Combine(baseDir, "matches.censored.json"));
        if (File.Exists(csvIn)) ProcessCsv(csvIn, Path.Combine(baseDir, "matches.censored.csv"));

        Console.WriteLine("Finished.");
    }

    static string MaskTeam(string team)
    {
        if (string.IsNullOrWhiteSpace(team)) return team;
        var parts = team.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return parts.Length==1 ? parts[0] + " ***" : parts[0] + " ***";
    }

    static void ApplyCensorship(JObject match)
    {
        if (match.TryGetValue("team1", out var t1)) match["team1"] = MaskTeam(t1.ToString());
        if (match.TryGetValue("team2", out var t2)) match["team2"] = MaskTeam(t2.ToString());
        if (match.TryGetValue("playerOfMatch", out var p)) match["playerOfMatch"] = "REDACTED";
    }

    static void ProcessJson(string inPath, string outPath)
    {
        var text = File.ReadAllText(inPath);
        var arr = JArray.Parse(text);
        foreach(var item in arr.OfType<JObject>()) ApplyCensorship(item);
        File.WriteAllText(outPath, arr.ToString(Formatting.Indented));
        Console.WriteLine($"Wrote censored JSON to {outPath}");
    }

    static void ProcessCsv(string inPath, string outPath)
    {
        using var reader = new StreamReader(inPath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<dynamic>().Select(r => (IDictionary<string, object>)r).ToList();

        // Apply censorship
        foreach(var r in records)
        {
            if (r.ContainsKey("team1") && r["team1"] is string t1) r["team1"] = MaskTeam(t1);
            if (r.ContainsKey("team2") && r["team2"] is string t2) r["team2"] = MaskTeam(t2);
            if (r.ContainsKey("playerOfMatch")) r["playerOfMatch"] = "REDACTED";
        }

        using var writer = new StreamWriter(outPath);
        using var csvOut = new CsvWriter(writer, CultureInfo.InvariantCulture);
        var first = records.FirstOrDefault();
        if (first==null) return;
        foreach(var h in first.Keys) csvOut.WriteField(h);
        csvOut.NextRecord();
        foreach(var row in records)
        {
            foreach(var h in first.Keys) csvOut.WriteField(row[h]);
            csvOut.NextRecord();
        }

        Console.WriteLine($"Wrote censored CSV to {outPath}");
    }
}
