using HTYF.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTYF.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly EventSyncService _eventSyncService;

        public AdminController(EventSyncService eventSyncService)
        {
            _eventSyncService = eventSyncService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SyncEvents()
        {
            await _eventSyncService.SyncEventsAsync();
            TempData["Success"] = "Events synced successfully from Memberbase.";
            return RedirectToAction("Index", "Events");
        }
    }
}
