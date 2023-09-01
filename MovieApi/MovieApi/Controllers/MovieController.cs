using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dtos;
using MovieApi.Services;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private List<string> Extention = new List<string>() { ".png", ".jpg" };
        private long maxsize = 1048576;


        private readonly IMovieService _db;
        private readonly IGenerservices _dbc;
        private readonly IMapper _mapper;


        public MovieController(IMovieService db, IGenerservices dbc, IMapper mapper)
        {
            _dbc = dbc;
            _db = db;
            _mapper = mapper;
        }

        //three get when use get onather take id another name variable

        [HttpGet]
        public async Task<IActionResult> GetAlleAsyn()
        {
            var Movies = await _db.GetAll();

            var data= _mapper.Map<IEnumerable<MovieDto>>(Movies);
            return Ok(data);

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlleAsynByid(int id)
        {
            var Movies = await _db.GetById(id);

            if (Movies == null)
            {
                return NotFound();
            }



            return Ok(Movies);

        }


        [HttpGet("ByGenerId")]

        public async Task<IActionResult> GetAlleAsynBygenerid(byte Gener_Id)
        {

            var Movies = await _db.GetAll(Gener_Id);
            var data = _mapper.Map<IEnumerable<MovieDto>>(Movies);
            return Ok(data);

          


        }










        [HttpPost]

        public async Task<IActionResult> CreateAsyn([FromForm] MovieDto dto)
        {

            if (dto.Poster == null) return BadRequest("poster is required");

            //to get extention of photo
            if (!Extention.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
            {


                return BadRequest("error not allow this Extension ");

            }


            if (dto.Poster.Length > maxsize) { return BadRequest("error file size more than 1 MG"); }
            var valid = await _dbc.isvalid(dto.GenreId);

            if (!valid)
            {
                return BadRequest("id not valid");
            }
                //to store ifile to byte
                using var dataStream = new MemoryStream();
                await dto.Poster.CopyToAsync(dataStream);
                var Movie = new Movie()
                {
                    GenreId = dto.GenreId,
                    Title = dto.Title,

                    rate = dto.rate,
                    Poster = dataStream.ToArray(),
                    Year = dto.Year,
                    StoreLine = dto.StoreLine,


                };


           _db.Adds(Movie); 
            return Ok(Movie);

        }




    

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var movie = await _db.GetById(id);
            if (movie == null)
            {

                return NotFound($"no genere was  found with id{id}");
            }

            _db.Delete(movie);



            return Ok(movie);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpateAsyn(int id,[FromForm] MovieDto dto)
        {

            var movie = await _db.GetById(id);
            if (movie == null)
            {

                return NotFound($"no genere was  found with id{id}");
            }
            var valid = await _dbc.isvalid(dto.GenreId);

            if (!valid)
            {
                return BadRequest("id not valid");
            }




            movie.Title = dto.Title;    
            movie.StoreLine = dto.StoreLine;    
            movie.Year = dto.Year;
            movie.GenreId = dto.GenreId;    
            movie.StoreLine= dto.StoreLine;
            if (dto.Poster != null)
            {

                if (!Extention.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                {


                    return BadRequest("error not allow this Extension ");

                }


                if (dto.Poster.Length > maxsize) { return BadRequest("error file size more than 1 MG"); }

                using var dataStream = new MemoryStream();
                await dto.Poster.CopyToAsync(dataStream);
                movie.Poster = dataStream.ToArray();
                //return Ok(dto);
            }

           _db.Update(movie);
            return Ok(movie);   
        }








    }
    }

