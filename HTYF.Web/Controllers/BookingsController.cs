using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTYF.Web.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        [HttpGet]
        public IActionResult Create(int eventId)
        {
            ViewBag.EventId = eventId;
            return View();
        }
    }
}
