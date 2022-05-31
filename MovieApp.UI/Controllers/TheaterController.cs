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
    public class TheaterController : Controller
    {
        IConfiguration _configuration;

        public TheaterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> ShowTheaterDetailsAsync()
        {

            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theater/SelectTheater";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        var theaterModel = JsonConvert.DeserializeObject<List<ThetreModel>>(result);
                        //var userModel = JsonSerializer.Deserialize<UserModel>(result);

                        return View(theaterModel);
                    }
                }

            }
            return View();
        }



        public IActionResult RegisterTheater()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTheater(ThetreModel theaterModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theaterModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "Theater/AddTheater";
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


        public async Task<IActionResult> EditTheaterAsync(int theaterId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theater/SelectTheaterById?theaterId=" + theaterId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        var theaterModel = JsonConvert.DeserializeObject<ThetreModel>(result);
                        //var userModel = JsonSerializer.Deserialize<UserModel>(result);

                        return View(theaterModel);
                    }
                }

            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditTheaterAsync(ThetreModel theaterModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theaterModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Theater/UpdateTheater";
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



        public async Task<IActionResult> TheaterDelete(int theaterId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theater/SelectTheaterById?theaterId=" + theaterId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        var theaterModel = JsonConvert.DeserializeObject<ThetreModel>(result);
                        //var userModel = JsonSerializer.Deserialize<UserModel>(result);

                        return View(theaterModel);
                    }
                }

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TheaterDelete(ThetreModel theaterModel)
        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiURL"] + "Theater/DeleteTheater?movieId=" + theaterModel.Id;
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
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
