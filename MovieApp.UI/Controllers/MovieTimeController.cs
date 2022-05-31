using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyMovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieTimeController : Controller
    {
        IConfiguration _configuration;

        public MovieTimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> AddMovieTime()
        {
            List<ThetreModel> thetreModel = null;
            List<MovieModel> movieModel = null;

            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Theater/SelectTheater";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        thetreModel = JsonConvert.DeserializeObject<List<ThetreModel>>(data);
                        List<SelectListItem> selectListItemsTheatre = new List<SelectListItem>();
                        foreach (var item in thetreModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.Name;
                            selectListItem.Value = item.Id.ToString();
                            selectListItemsTheatre.Add(selectListItem);
                            ViewBag.thetreList = selectListItemsTheatre;
                        }
                    }
                }
            }



            using (HttpClient client = new HttpClient())
            {
                string endpint = _configuration["WebApiURL"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endpint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(data);
                        List<SelectListItem> selectListItemsMovies = new List<SelectListItem>();
                        foreach (var item in movieModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.MovieTitle;
                            selectListItem.Value = item.MovieId.ToString();
                            selectListItemsMovies.Add(selectListItem);
                            ViewBag.movieList = selectListItemsMovies;
                        }

                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieTime(MovieShowTime movieShowTime)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(movieShowTime), Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "MovieShowTime/InsertMovieShowTime";

                using (var response = await client.PostAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowAllMovieShow", "MovieTime");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllMovie()
        {

            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "MovieShowTime/ShowMovieTimeList";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        List<MovieShowTime> list = JsonConvert.DeserializeObject<List<MovieShowTime>>(data);
                        return View(list);
                    }
                }
            }

            return View();
        }
    }
}
