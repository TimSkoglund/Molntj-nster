using Application.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Persistence.Entities;
using Persistence.Repositories;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services;
public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<EventResult> CreateEventAsync(CreateEventRequest request)
    {
        try
        {
            var eventEntity = new EventEntity
            {
                Image = request.Image,
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                EventDate = request.EventDate
            };

            var result = await _eventRepository.AddAsync(eventEntity);
            return result.Success
                ? new EventResult { Success = true }
                : new EventResult { Success = false, Error = result.Error };
        }

        catch (Exception ex)
        {
            return new EventResult
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public async Task<EventResult<IEnumerable<Event>>> GetEventAsync()
    {
        var result = await _eventRepository.GetAllAsync();
        if (result.Success  && result.Result != null)
        {
            var currentEvent
        }
        var events = result.Result?.Select(x => new Event
        {
            Image = x.Image,
            Title = x.Title,
            Description = x.Description,
            Location = x.Location,
            EventDate = x.EventDate
        });

        return new EventResult<IEnumerable<Event>> { Success = true, Result = events };
    }

}

