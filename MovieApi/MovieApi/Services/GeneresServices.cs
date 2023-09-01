namespace MovieApi.Services
{
    public class GeneresServices : IGenerservices
    {

        private readonly AplicationDbContext _db;

        public GeneresServices(AplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Genre> Adds(Genre genre)
        {

            await _db.AddAsync(genre);
            _db.SaveChanges();
          return genre;
        }

        public Genre Delete(Genre genre)
        {

            _db.Remove(genre);
            _db.SaveChanges();


            return genre;
        }

        public  async Task<IEnumerable<Genre>> GetAll()
        {
            var geners = await _db.Genres.OrderBy(c => c.Name).ToListAsync();

            return geners;
        }

        public async Task<Genre> GetById(byte id)
        {
            var genre = await _db.Genres.SingleOrDefaultAsync(c => c.Id == id);

            return genre;
        }

        public async Task<bool> isvalid(byte id)
        {
            return await _db.Genres.AnyAsync(c => c.Id == id);
            
        }

        public Genre Update(Genre genre)
        {
            _db.Update(genre);
            _db.SaveChanges();


            return genre;

        }
    }
}
