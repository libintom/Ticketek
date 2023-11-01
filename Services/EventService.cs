using Ticketek.Models;

namespace Ticketek.Services;

public class EventService
{
    private ApiClient apiClient = new ApiClient();

    public async Task<APIModel> GetFullApiResponse()
    {
        var apiResponse = await apiClient.GetApi<APIModel>("https://teg-coding-challenge.s3.ap-southeast-2.amazonaws.com/events/event-data.json");
        return apiResponse;

    }

    public ViewModel GetEvents(int venueId = 0)
    {
        ViewModel viewModel;
        
        if (venueId > 0)
        {
            var venueEvents = GetFullApiResponse().Result.Events?.Where(x => x.VenueId == venueId).ToList();
            viewModel = new ViewModel
            {
                Events = venueEvents
            };
        }
        else
        {
            viewModel = new ViewModel
            {
                Events = GetFullApiResponse().Result.Events
            };
        }
        
        viewModel.Venues = GetFullApiResponse().Result.Venues;
        viewModel.selectedVenue = venueId;
        
        return viewModel;
    }

    public Event? GetEventDetails(int eventId)
    {
        var apiResult = GetFullApiResponse().Result;
        var venues = apiResult.Venues;
        var eventDetails = apiResult.Events?.FirstOrDefault(x => x.Id == eventId) ?? null;
        if (eventDetails != null && venues != null)
            eventDetails.VenueName = venues.FirstOrDefault(x => x.id == eventDetails.VenueId)?.name;
        return eventDetails;
    }
}
    
