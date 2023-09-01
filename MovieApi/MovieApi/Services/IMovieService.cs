namespace MovieApi.Services
{
    public interface IMovieService
    {

        Task<IEnumerable<Movie>> GetAll(byte id=0);

        Task<Movie> GetById(int id);
        Task<Movie> Adds(Movie movies);

        Movie Update(Movie movies);

        Movie Delete(Movie movies);
    }
}
