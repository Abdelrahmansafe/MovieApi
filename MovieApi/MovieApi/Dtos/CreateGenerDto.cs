namespace MovieApi.Dtos
{
    public class CreateGenerDto
    {
        [MaxLength(100)]
        public String Name { get; set; }
    }
}
