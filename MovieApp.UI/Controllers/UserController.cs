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
    public class UserController : Controller
    {
        IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ShowUserDetailsAsync()
        {

            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/SelectUsers";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        
                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        //var userModel = JsonSerializer.Deserialize<UserModel>(result);

                        return View(userModel);
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
        public async Task<IActionResult> Register(UserModel usermodel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(usermodel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "User/Register";
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


        public async Task<IActionResult> EditUserAsync(int UserId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/SelectUsersById?userId=" + UserId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        //var userModel = JsonSerializer.Deserialize<UserModel>(result);

                        return View(userModel);
                    }
                }

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditUserAsync(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/Update";
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



        public async Task<IActionResult> DeleteUserAsync(int UserId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/SelectUsersById?userId=" + UserId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        //var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        //var userModel = JsonSerializer.Deserialize<UserModel>(result);

                        return View(userModel);
                    }
                }

            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> DeleteUserAsync(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
               
                string endPoint = _configuration["WebApiURL"] + "User/Delete?userId="+ userModel.UserId;
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
