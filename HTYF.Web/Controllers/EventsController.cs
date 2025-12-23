using HTYF.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HTYF.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index(DateTime? date)
        {
            var events = await _eventService.GetUpcomingEventsAsync(date);
            return View(events);
        }

        public async Task<IActionResult> Details(int id)
        {
            var evt = await _eventService.GetEventByIdAsync(id);
            if (evt == null) return NotFound();

            return View(evt);
        }
    }
}
