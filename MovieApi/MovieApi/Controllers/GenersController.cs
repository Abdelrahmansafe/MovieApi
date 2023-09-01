using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Services;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenersController : ControllerBase
    {
        private readonly IGenerservices _db;
        
        public GenersController(IGenerservices db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> Getallsync()
        {


            var geners = await  _db.GetAll();

            return Ok(geners);

        }



        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateGenerDto dto)
        {

            Genre genre = new Genre() { Name = dto.Name };
            _db.Adds(genre);
            return Ok(genre);






        }

        [HttpPut("{id}")]

        public async Task<IActionResult> updateAsync(byte  id,[FromBody]CreateGenerDto dto)
        {

            var genre = await _db.GetById(id);
            if(genre == null) {

                return NotFound($"no genere was  found with id{id}");
            }

            genre.Name=dto.Name;    
            _db.Update(genre);  
            return Ok(genre);






        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {

            var genre = await _db.GetById(id);
            if (genre == null)
            {

                return NotFound($"no genere was  found with id{id}");
            }

            _db.Delete(genre);

        




            return Ok(genre);
        }







        }
}
