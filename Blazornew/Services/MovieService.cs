using Blazornew.Data;
using Microsoft.EntityFrameworkCore;

namespace Blazornew.Services
{
    public class MovieService
    {
        protected readonly ApplicationContext dbContext;
        public MovieService(ApplicationContext dbcontext)
        {
            dbContext = dbcontext;
        }
        public Movie GetMovieFromTitle(string inputValue)
        {
            var findedMovies = dbContext.Movies.Include(a => a.Tops).Include(a => a.Tags).Include(a => a.Actors)
                .Where(m => m.Title.Contains(inputValue)).ToList().FirstOrDefault();
            return findedMovies;
        }
        public Actor GetActorFromTitle(string inputValue)
        {
            return dbContext.Actors
                .Include(a => a.Movies)
                .Where(a => a.Name.ToLower() == inputValue.ToLower()).FirstOrDefault();
        }
        public List<Movie> GetMoviesFromTag(string inputValue)
        {
            return dbContext.Movies.Include(m => m.Tags)
                .Where(m => m.Tags.Any(n => n.Title.ToLower() == inputValue.ToLower())).ToList();
            //dbContext.TagsDbs.Include(t => t.movie).Where(t => t.name.ToLower() == inputValue.ToLower()).First().movie.ToList();
        }
        public List<Movie> GetMoviesFromActor(string inputValue)
        {
            //return dbContext.ActorsDBs.Include(a => a.movie).Where(a => a.name.ToLower() == inputValue.ToLower()).First().movie.ToList();
            return dbContext.Movies.Include(m => m.Actors)
               .Where(m => m.Actors.Any(n => n.Name.ToLower() == inputValue.ToLower())).ToList();
        }
    }
}