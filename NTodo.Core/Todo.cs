namespace NTodo.Core;

public record Todo(string Description, char? Priority, DateTime? CreatedOn, DateTime? CompletedOn)
{
    public IEnumerable<string> Projects => Description.Split().Where(s => s.StartsWith('+'));
    public IEnumerable<string> Contexts => Description.Split().Where(s => s.StartsWith('@'));

    public override string ToString()
    {
        var isComplete = CompletedOn == null ? "" : "x ";
        var priority = Priority == null ? "" : $"({Priority.Value}) ";
        var completed = CompletedOn?.ToString("yyyy-MM-dd ") ?? "";
        var created = CreatedOn?.ToString("yyyy-MM-dd ") ?? "";
        return $"{isComplete}{priority}{completed}{created}{Description}";
    }
}