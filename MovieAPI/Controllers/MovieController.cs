using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieApp.Business.Services;
using MyMovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieService _movieServices;

        public MovieController(MovieService movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpGet("SelectMovie")]
        public IActionResult SelectMovie()
        {
            return Ok(_movieServices.SelectMovie());
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            return Ok(_movieServices.AddMovie(movieModel));
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(int movieId)
        {
            return Ok(_movieServices.DeleteMovie(movieId));
        }


        [HttpPut("Update")]
        public IActionResult Update(MovieModel movieModel)
        {
            return Ok(_movieServices.UpdateMovie(movieModel));
        }


        [HttpGet("SelectMovieById")]
        public IActionResult GetMovieById(int movieId)
        {
            return Ok(_movieServices.SelectMovieById(movieId));
        }


    }
}
