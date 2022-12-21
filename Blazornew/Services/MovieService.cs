using Blazornew.Data;
using Microsoft.EntityFrameworkCore;

namespace Blazornew.Services
{
    public class MovieService
    {
        protected readonly ApplicationContext _dbContext;
        public MovieService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Movie GetMovieFromTitle(string inputValue)
        {
            var movie = _dbContext.Movies
                .Include(m => m.Actors)
                .Include(m => m.Tags)
                .Where(m => m.Name.ToLower() == inputValue.ToLower()).FirstOrDefault();
            return movie;
        }
        public Actor GetActorFromTitle(string inputValue)
        {
            return _dbContext.Actors
                .Include(a => a.Movies)
                .Where(a => a.Name.ToLower() == inputValue.ToLower()).FirstOrDefault();
        }
        public List<Movie> GetMoviesFromTag(string inputValue)
        {
            return _dbContext.Tags.Include(t => t.Movies).Where(t => t.Name.ToLower() == inputValue.ToLower()).First().Movies.ToList();
        }
        public List<Movie> GetMoviesFromActor(string inputValue)
        {
            return _dbContext.Actors.Include(a => a.Movies).Where(a => a.Name.ToLower() == inputValue.ToLower()).First().Movies.ToList();
        }
    }
}