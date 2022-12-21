using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Blazornew.Data;

[Table("Movie")]

public class Movie
{
    [Display(AutoGenerateField = false)]
    internal float value;

    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public Movie()
    {

    }
    public Movie(string title, string rating, HashSet<Actor> actors, HashSet<Tag> tags)
    {
        Title = title;
        Rating = rating;
        Actors = actors;
        Tags = tags;
    }

    public Movie(string name, string rating)
    {
        Title = name;
        Rating = rating;
    }
    public string Rating { get; set; }
    public HashSet<Actor> Actors { get; set; } = new();
    public HashSet<Tag> Tags { get; set; } = new();
    public HashSet<Movie> Tops { get; set; }

    public float MakeTop(Movie movie)
    {
        float act = new();
        float tag = new();
        if (Actors != null && movie.Actors != null)
        {
            HashSet<Actor> interseptionActors = new HashSet<Actor>(Actors);
            interseptionActors.IntersectWith(movie.Actors);
            act = (float)interseptionActors.Count / (4 * Actors.Count);
        }

        if (Tags != null && movie.Tags != null)
        {
            HashSet<Tag> interTags = new HashSet<Tag>(Tags);
            interTags.IntersectWith(movie.Tags);
            tag = (float)interTags.Count / (4 * Tags.Count);
        }

        return (float.Parse(movie.Rating, CultureInfo.InvariantCulture) / 20) + tag + act;

        /*if (movie.Title.Equals(Title)) { return 0f ; }
        float i = 0;
        float c1 = movie.Actors.Intersect(Actors).Count();
        float c2 = movie.Tags.Intersect(Tags).Count();
        if (c1 + c2 != 0)
        {
            i += (c1/(4*Actors.Count) + c2/(4* Tags.Count));
        }
        if (movie.Rating != null)
        {
            i += float.Parse(Rating, CultureInfo.InvariantCulture) / 20;
            *//*i += Math.Abs(1 - (MathF.Abs(float.Parse(Rating, CultureInfo.InvariantCulture) - float.Parse(movie.Rating, CultureInfo.InvariantCulture))) / 10f) / 2f;*//*
        }

        return i;*/
    }
    public string GetInfo()
    {
        System.Console.WriteLine($"Фильм - {Title}");

        if (Actors != null)
        {
            System.Console.WriteLine("Актеры");
            foreach (var a in Actors)
            {
                System.Console.Write(a.Name + ", ");
            }
            System.Console.WriteLine();
        }
        if (Tags != null)
        {
            System.Console.WriteLine("Теги:");
            foreach (var t in Tags)
            {
                System.Console.Write(t.Title + ", ");
            }
        }
        System.Console.WriteLine($"Рейтинг {Rating}");
        System.Console.WriteLine("TOP:");
        if (Tops != null)
        {
            foreach (var movie in Tops)
            {
                System.Console.Write(movie.Title + ", ");
            }
        }
        return "";
    }
}

