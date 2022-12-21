using System.Globalization;

namespace Blazornew.Data;


    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public HashSet<Actor>? Actors { get; set; }
        public HashSet<Tag>? Tags { get; set; }

        // public top10? Top10s { get; set; }
        public string? Rating { get; set; }

        public HashSet<Movie>? top10 { get; set; }

        //ublic int? top10id { get; set; }

        public Movie(string name, HashSet<Actor> actors, HashSet<Tag> tags, string rating)
        {
            Name = name;
            Actors = actors;
            Tags = tags;
            Rating = rating;
        }

        public float intersection(Movie t1)
        {
            float act = new();
            float tag = new();
            if (Actors != null && t1.Actors != null)
            {
                // Tags != null && t1.Tags != null
                HashSet<Actor> interseptionActors = new HashSet<Actor>(Actors);

                interseptionActors.IntersectWith(t1.Actors);

                //  HashSet<TagsDb> interTags = new HashSet<TagsDb>(Tags);

                //interTags.IntersectWith(t1.Tags);

                act = (float)interseptionActors.Count / (4 * Actors.Count);
                // float tag = (float)interTags.Count / (4 * Tags.Count);
                // float rat = float.Parse(Rating, CultureInfo.InvariantCulture) / 20;

                //return act + tag + rat;
            }
            // else
            // {
            //     act = 0;
            // }

            if (Tags != null && t1.Tags != null)
            {
                HashSet<Tag> interTags = new HashSet<Tag>(Tags);
                interTags.IntersectWith(t1.Tags);
                tag = (float)interTags.Count / (4 * Tags.Count);
            }
            // else
            // {
            //     tag = 0;
            // }


            return (float.Parse(t1.Rating, CultureInfo.InvariantCulture) / 20) + tag + act;
        }

        public void writeactor()
        {
            foreach (var item in Actors)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void writetags()
        {
            foreach (var item in Tags)
            {
                Console.WriteLine(item.Name);
            }
        }

        // public void top10()
        // {
        //     Console.WriteLine(Top10s.topfilms);
        // }

        public Movie(string name)
        {
            Name = name;
        }
    }

