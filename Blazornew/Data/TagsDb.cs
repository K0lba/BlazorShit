namespace Blazornew.Data;

public class Tag
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public HashSet<Movie>? Movies { get; set; }


    public override int GetHashCode()
    {
        return  Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Tag;
        return other != null && other.Name == this.Name;
    }

    public void writefilms()
    {
        foreach (var item in Movies)
        {
            Console.WriteLine(item.Name);
        }
    }
}