using DonorSPA.Data;
using DonorSPA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DonorSPA.Controllers
{
    public class HomeController : Controller
    {
        private readonly DonorDbContext _context;

        public HomeController(DonorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Donate(DonationInputViewModel model)
        {
            if (ModelState.IsValid)
            {
                //SERVER SIDE VALIDATION

                //PROCESS CREDIT CARD 

                //RECORD DONATION

                _context.DonationRecords.Add(new DonationRecord
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    Amount = model.Amount
                });

                _context.SaveChanges();

                return Json(new { success = true });
            }

            return Json(new { success = false });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
