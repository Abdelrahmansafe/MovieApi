namespace MovieApi.Services
{
    public interface IGenerservices
    {
        Task<IEnumerable<Genre>> GetAll();

        Task<Genre> GetById(byte id);
        Task<Genre> Adds(Genre genre);

        Genre Update(Genre genre);

        Genre Delete(Genre genre);
        Task<bool> isvalid(byte id);    

    }
}
