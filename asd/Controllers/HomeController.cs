using asd.DTO_s;
using asd.Models;
using asd.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace asd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDBContext _appDBContext;

        public HomeController(ILogger<HomeController> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _appDBContext = appDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IQueryable<Guest> GetGuests()
        {
            return _appDBContext.Guest.AsQueryable();
        }

        public IActionResult GuestsFromExpertSolution()
        {
            try
            {

                var guestsFromExpertSolution = GetGuests()
                    .Where(g => g.Company.CompanyName == "ExpertSolution")
                    .Select(g => new GuestDTO1
                    {
                        ID = g.GuestID,
                        Name = g.Name,
                        CompanyName = g.Company.CompanyName
                    })
                    .ToList();

                return View("Task1", guestsFromExpertSolution);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public IActionResult UpdateTable()
        {

            return View(_appDBContext);
        }
    }
}