namespace Blazornew.Data;

public class Actor
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public Actor(string Name)
    {
        this.Name = Name;
    }

    public HashSet<Movie> Movies { get; set; }

    public override int GetHashCode()
    {
        if (Name == null) return 0;
        return Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Actor;
        return other != null && other.Name == Name;
    }
}

