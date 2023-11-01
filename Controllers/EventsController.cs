using System.Diagnostics;

using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ticketek.Models;
using Ticketek.Services;

namespace Ticketek.Controllers;

public class EventsController : Controller
{
    private readonly ILogger<EventsController> _logger;
    private ApiClient apiClient = new ApiClient();
    private EventService eventService = new EventService();

    public EventsController(ILogger<EventsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int venueId)
    {
        return View(eventService.GetEvents(venueId));
    }

    public IActionResult Details(int eventId)
    {
        return View(eventService.GetEventDetails(eventId));
    }

    
}
    
