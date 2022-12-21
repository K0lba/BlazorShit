namespace Blazornew.Data;

public class Actor
{
    public int Id { get; set; }
    public HashSet<Movie>? Movies { get; set; }

    public string? Name { get; set; }

    // public ActorsDB {}
    public void Write()
    {
        foreach (var item in Movies)
        {
            Console.WriteLine(item.Name);
        }
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Actor;
        return other != null && other.Name == this.Name;
    }
}
