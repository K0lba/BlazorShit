namespace Blazornew.Data;

public class Tag
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public Tag(string title)
    {
        Title = title;
    }

    public HashSet<Movie> Movies { get; set; }
}