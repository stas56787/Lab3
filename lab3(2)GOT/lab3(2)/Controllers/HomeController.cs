using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using lab3.Models;
using lab3.ViewModels;
using lab3.Services;

namespace lab3.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache _cache;
        public HomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            HomeViewModel homeViewModel = _cache.Get<HomeViewModel>("operation");
            return View(homeViewModel);
        }

        public IActionResult About2()
        {
            HomeViewModel homeViewModel = TakeLast.GetHomeViewModel();
            return View("~/Views/Home/About.cshtml", homeViewModel);
        }

        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult About3()
        {

            HomeViewModel homeViewModel = TakeLast.GetHomeViewModel();
            return View("~/Views/Home/About.cshtml", homeViewModel);
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        public IActionResult TVShow()
        {
            if (HttpContext.Session.Keys.Contains("nameShow"))
            {
                ViewBag.NameShow = HttpContext.Session.GetString("nameShow");
            }
            if (HttpContext.Session.Keys.Contains("duration"))
            {
                ViewBag.Duration = HttpContext.Session.GetString("duration");
            }
            if (HttpContext.Session.Keys.Contains("rating"))
            {
                ViewBag.Rating = HttpContext.Session.GetString("rating");
            }
            if (HttpContext.Session.Keys.Contains("descriptionShow"))
            {
                ViewBag.DescriptionShow = HttpContext.Session.GetString("descriptionShow");
            }
            return View("~/Views/TVShow/Index.cshtml");
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "Caching")]
        public IActionResult CitizensAppeal()
        {
            return View("~/Views/CitizensAppeal/Index.cshtml");
        }

        [HttpGet]
        public IActionResult ScheduleForWeek()
        {
            return View("~/Views/ScheduleForWeek/Index.cshtml");
        }

        [HttpGet]
        public IActionResult Genre()
        {
            string nameGenre = "", descriptionOfGenre = "";
            if (HttpContext.Request.Cookies.ContainsKey("nameGenre"))
            {
                nameGenre = HttpContext.Request.Cookies["nameGenre"];
            }
            if (HttpContext.Request.Cookies.ContainsKey("descriptionOfGenre"))
            {
                descriptionOfGenre = HttpContext.Request.Cookies["descriptionOfGenre"];
            }
            ViewBag.NameGenre = nameGenre;
            ViewBag.DescriptionOfGenre = descriptionOfGenre;
            return View("~/Views/Genre/Index.cshtml");
        }

        [HttpPost]
        public string TVShow(string nameShow, string duration,
            string rating, string descriptionShow)
        {
            HttpContext.Session.SetString("nameShow", nameShow);
            HttpContext.Session.SetString("duration", duration);
            HttpContext.Session.SetString("rating", rating);
            HttpContext.Session.SetString("descriptionShow", descriptionShow);
            return "Шоу \"" + nameShow + "\"" + " c длительностью \"" + duration +
                 "\" мин., рейтингом \"" + rating + "\" и с описанием \"" + descriptionShow + "\" добавлено в базу.";
        }

        [HttpPost]
        public string CitizensAppeal(string lfo, string organization, string goalOfRequest)
        {
            return "Обращение от \"" + lfo + "\" из организации \"" + organization + "\" добавлено в базу. \nОписание обращения: \"" + goalOfRequest + "\"";
        }

        [HttpPost]
        public string Genre(string nameGenre, string descriptionOfGenre)
        {
            HttpContext.Response.Cookies.Append("nameGenre", nameGenre);
            HttpContext.Response.Cookies.Append("descriptionOfGenre", descriptionOfGenre);
            return "Жанр \"" + nameGenre + "\" с описанием: \"" + descriptionOfGenre + "\" добавлен в базу.";
        }

        [HttpPost]
        public string ScheduleForWeek(string startTime, string GuestsEmployees)
        {
            return "Время начала шоу: " + startTime + ". Гости: " + GuestsEmployees;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
