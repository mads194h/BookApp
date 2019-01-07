using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using BookApp.Services;

namespace BookApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly GiftApiProxy _giftApi;
        public HomeController(GiftApiProxy giftApi)
        {
            _giftApi = giftApi;
        }

        public IActionResult Index()
        {
            var gifts = _giftApi.GetAllGiftItems().Result;
            return View(gifts);
        }

        public IActionResult GetGiftFromNumber(int id)
        {
            var giftItem = _giftApi.GetGiftsByNumber(id).Result;
            return View(giftItem);
        }

        public IActionResult GetGiftForBoys()
        {
            var giftItem = _giftApi.GetBoyGifts().Result;
            return View("Index", giftItem);
        }

        public IActionResult GetGiftForGirls()
        {
            var giftItem = _giftApi.GetGirlGifts().Result;
            return View("Index", giftItem);
        }

        public IActionResult AddGift([FromForm] GiftItem giftItem)
        {
            if (!ModelState.IsValid) return View(giftItem);
            var result = _giftApi.CreateGiftItem(giftItem).Result;
            return result ? (IActionResult)RedirectToAction("Index") : View(giftItem);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new GiftItem());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
