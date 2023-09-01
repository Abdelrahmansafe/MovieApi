namespace MovieApi.Dtos
{
    public class MovieDto
    {
        public string Title { get; set; }

        public int Year { get; set; }
        public double rate { get; set; }

        [MaxLength(2500)]
        public string StoreLine { get; set; }

        //come as photo
        public IFormFile? Poster { get; set; }

        public byte GenreId { get; set; }
  











    }
}
