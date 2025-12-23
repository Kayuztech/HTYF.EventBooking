using HTYF.Application.Interfaces;
using HTYF.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTYF.Web.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult Create(int eventId)
        {
            return View(new CreateEventBookingViewModel { EventId = eventId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventBookingViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _bookingService.CreateBookingAsync(model);

            TempData["Success"] = "Your booking submitted successfully.";
            return RedirectToAction("Index", "Events");
        }
    }
}
