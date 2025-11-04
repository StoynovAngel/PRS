using System.Text.Json;

namespace FormatDifference;

public class JsonFormat : Format
{
    private const string JsonPath = "person.json";

    public override void Display()
    {
        var path = Path.Combine(AppContext.BaseDirectory, JsonPath);
        if (!File.Exists(path))
        {
            Console.WriteLine("File not found.");
            return;
        }

        var json = File.ReadAllText(path);
        using var doc = JsonDocument.Parse(json);
        
        var root = doc.RootElement;
        foreach (var prop in root.EnumerateObject())
        {
            var value = prop.Value;
            Console.WriteLine($"{prop.Name} => {value.ValueKind}");
        }
    }
}