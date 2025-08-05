using Application.Models;

namespace Application.Services;

public interface IEventService
{
    Task<EventResult> CreateEventAsync(CreateEventRequest request);
}

