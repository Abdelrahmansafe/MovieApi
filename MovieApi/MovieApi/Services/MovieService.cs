using MovieApi.Model;

namespace MovieApi.Services
{
    public class MovieService : IMovieService
    {

        private readonly AplicationDbContext _db;

        public MovieService(AplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Movie> Adds(Movie movies)
        {
          await  _db.AddAsync(movies);

            _db.SaveChanges();
            return movies;
        }

        public Movie Delete(Movie movies)
        {
            _db.Movies.Remove(movies);

            _db.SaveChanges();
            return movies;

        }

        public async Task<IEnumerable<Movie>> GetAll(byte id = 0)
        {
            var Movies = await _db.Movies.Where(x => x.Id == id || id==0).
              
                OrderByDescending(x => x.rate).
               Include(c => c.Genre).ToListAsync();
            return Movies;

        }

        public async Task<Movie> GetById(int id)
        {
            var Movies = await _db.Movies.Include(m => m.Genre).SingleOrDefaultAsync(c => c.Id == id);
            return Movies;
        }

        public Movie Update(Movie movies)
        {
            _db.Update(movies);     
            _db.SaveChanges();
            return movies;
        }
    }
}
