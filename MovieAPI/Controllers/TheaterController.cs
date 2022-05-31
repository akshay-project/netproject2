using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieApp.Business.Services;
using MyMovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : Controller
    {
        TheaterService _theaterServices;


        public TheaterController(TheaterService theaterServices)
        {
            _theaterServices = theaterServices;
        }

        [HttpGet("SelectTheater")]
        public IActionResult SelectTheater()
        {
            return Ok(_theaterServices.SelectThater());
        }


        [HttpPost("AddTheater")]
        public IActionResult AddTheater(ThetreModel theaterModel)
        {
            return Ok(_theaterServices.AddTheater(theaterModel));
        }


        [HttpDelete("DeleteTheater")]
        public IActionResult DeleteTheater(int movieId)
        {
            return Ok(_theaterServices.DeleteTheater(movieId));
        }

        [HttpPut("UpdateTheater")]
        public IActionResult UpdateTheater(ThetreModel TheaterModel)
        {
            return Ok(_theaterServices.UpdateTheater(TheaterModel));
        }


        [HttpGet("SelectTheaterById")]
        public IActionResult SeleSelectTheaterById(int theaterId)
        {
            return Ok(_theaterServices.SelectTheaterById(theaterId));
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
