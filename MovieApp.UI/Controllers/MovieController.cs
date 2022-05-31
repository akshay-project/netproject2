using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MyMovieApp.Entity;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.UI.Controllers
{
    public class MovieController : Controller
    {
        
        IConfiguration _configuration;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ShowMovieDetailsAsync()
        {

            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result);
                        //var userModel = JsonSerializer.Deserialize<UserModel>(result);

                        return View(movieModel);
                    }
                }

            }
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> register(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "Movie/AddMovie";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "success";
                        ViewBag.message = "registered!";
                    }
                    else
                    {
                        ViewBag.status = "error";
                        ViewBag.message = "wrong entries@";
                    }
                }

            }
            return View();
        }


        public async Task<IActionResult> EditMovieAsync(int movieId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Movie/SelectMovieById?movieId=" + movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        var movieModel = JsonConvert.DeserializeObject<MovieModel>(result);
                        //var userModel = JsonSerializer.Deserialize<UserModel>(result);

                            return View(movieModel);
                    }
                }

            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditMovieAsync(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Movie/Update";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Updated";
                        ViewBag.message = "registered!";
                    }
                    else
                    {
                        ViewBag.status = "error";
                        ViewBag.message = "wrong entries@";
                    }
                }

            }
            return View();
        }



        public async Task<IActionResult> DeleteMovieAsync(int movieId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Movie/SelectMovieById?movieId=" + movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        var movieModel = JsonConvert.DeserializeObject<MovieModel>(result);
                        //var userModel = JsonSerializer.Deserialize<UserModel>(result);

                        return View(movieModel);
                    }
                }

            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> DeleteMovieAsync(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiURL"] + "Movie/Delete?movieId=" + movieModel.MovieId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Deleted";
                        ViewBag.message = "registered!";
                    }
                    else
                    {
                        ViewBag.status = "error";
                        ViewBag.message = "wrong entries@";
                    }
                }

            }
            return View();
        }
    }
}
