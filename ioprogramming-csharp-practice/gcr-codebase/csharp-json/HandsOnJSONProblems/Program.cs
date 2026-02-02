using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

class Program
{
    static void Main()
    {
        Console.WriteLine("HandsOn JSON Problems - Running samples...");

        CreateStudentJson();
        SerializeCar();
        ReadJsonExtractFields();
        MergeTwoJsonObjects();
        ValidateJsonWithSchema();
        ConvertListToJsonArray();
        FilterAgeGreaterThan25();
        PrintAllKeysAndValues();
        ConvertCsvToJson();
        ConvertJsonToXml();

        Console.WriteLine("Done.");
    }

    static void CreateStudentJson()
    {
        var student = new JObject {
            ["name"] = "Alice",
            ["age"] = 23,
            ["subjects"] = new JArray("Math","Physics","CS")
        };
        Console.WriteLine("Student JSON: " + student.ToString(Formatting.None));
    }

    class Car { public string Make {get;set;} = ""; public string Model {get;set;} = ""; public int Year {get;set;} }
    static void SerializeCar()
    {
        var car = new Car{ Make="Toyota", Model="Corolla", Year=2020 };
        var json = JsonConvert.SerializeObject(car);
        Console.WriteLine("Car JSON: " + json);
    }

    static void ReadJsonExtractFields()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "input_users.json");
        if (!File.Exists(path)) return;
        var text = File.ReadAllText(path);
        var arr = JArray.Parse(text);
        foreach(var item in arr)
        {
            Console.WriteLine($"Name: {item["name"]}, Email: {item["email"]}");
        }
    }

    static void MergeTwoJsonObjects()
    {
        var a = JObject.Parse("{\"a\":1,\"x\":10}");
        var b = JObject.Parse("{\"b\":2,\"x\":20}");
        a.Merge(b, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
        Console.WriteLine("Merged: " + a.ToString(Formatting.None));
    }

    static void ValidateJsonWithSchema()
    {
        var schemaJson = @"{
  'type':'object',
  'properties':{
    'name':{'type':'string'},
    'age':{'type':'integer'},
    'email':{'type':'string','format':'email'}
  },
  'required':['name','age']
}";
        var schema = JSchema.Parse(schemaJson);
        var instance = JObject.Parse("{ 'name':'Bob', 'age':30, 'email':'bob@example.com' }");
        bool ok = instance.IsValid(schema, out IList<string>? msgs);
        Console.WriteLine("Schema valid: " + ok);
        if (!ok) Console.WriteLine(string.Join(";", msgs));
    }

    static void ConvertListToJsonArray()
    {
        var list = new[]{ new { Name="Tom", Age=28 }, new { Name="Jen", Age=22 } };
        var json = JsonConvert.SerializeObject(list);
        Console.WriteLine("List->JSON: " + json);
    }

    static void FilterAgeGreaterThan25()
    {
        var json = "[{'name':'A','age':30},{'name':'B','age':20}]";
        var arr = JArray.Parse(json);
        var filtered = new JArray(arr.Children<JObject>().Where(o => (o.Value<int?>("age") ?? 0) > 25));
        Console.WriteLine("Filtered: " + filtered.ToString(Formatting.None));
    }

    static void PrintAllKeysAndValues()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "input_users.json");
        if (!File.Exists(path)) return;
        var text = File.ReadAllText(path);
        var token = JToken.Parse(text);
        void Recurse(JToken t)
        {
            if (t is JObject obj)
            {
                foreach (var prop in obj.Properties())
                {
                    Console.WriteLine($"{prop.Path} : {prop.Value}");
                    Recurse(prop.Value);
                }
            }
            else if (t is JArray arr)
            {
                foreach (var child in arr) Recurse(child);
            }
        }
        Recurse(token);
    }

    static void ConvertCsvToJson()
    {
        var csvPath = Path.Combine(AppContext.BaseDirectory, "sample.csv");
        if (!File.Exists(csvPath)) return;
        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<dynamic>().ToList();
        var json = JsonConvert.SerializeObject(records);
        File.WriteAllText(Path.Combine(AppContext.BaseDirectory, "sample_from_csv.json"), json);
        Console.WriteLine("CSV -> JSON written to sample_from_csv.json");
    }

    static void ConvertJsonToXml()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "input_users.json");
        if (!File.Exists(path)) return;
        var json = File.ReadAllText(path);
        var doc = JsonConvert.DeserializeXmlNode(json, "root");
        if (doc != null)
        {
            File.WriteAllText(Path.Combine(AppContext.BaseDirectory, "input_users.xml"), doc.OuterXml);
            Console.WriteLine("JSON -> XML written to input_users.xml");
        }
    }
}
