using AutoMapper;

namespace MovieApi.helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // movie back from db
            //moviedto shape
            CreateMap<Movie, MovieDto>();
        }
    }
}
