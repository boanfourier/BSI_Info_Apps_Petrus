using System;
using System.Collections.Generic;
using BSI_Info_Apps;
using BSI_Info_BLL.DTO;
using DAL;
using static Dapper.SqlMapper;

public class EventsBLL : IEventsBLL
{
    private readonly IEvents _eventsDAL;
    public EventsBLL()
    {
        _eventsDAL = new EventsDAL();
    }

    public IEnumerable<EventsDTO> GetAllEvents()
    {
        try
        {
            var events = _eventsDAL.GetAllEvents();
            var eventDTOs = new List<EventsDTO>();

            foreach (var eventObj in events)
            {
                var eventdto = new EventsDTO
                {
                    event_id = eventObj.event_id,
                    event_name = eventObj.event_name,
                    description = eventObj.description,
                    start_date = eventObj.start_date,
                    end_date = eventObj.end_date,
                    location_id = eventObj.location_id,
                    organizer_id = eventObj.organizer_id
                };

                eventDTOs.Add(eventdto);
            }

            return eventDTOs;
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }

    public EventsDTO GetEventById(int eventId)
    {
        try
        {
            var events = _eventsDAL.GetEventById(eventId);
            var eventdto = new EventsDTO
            {
                event_id = events.event_id,
                event_name = events.event_name,
                description = events.description,
                start_date = events.start_date,
                end_date = events.end_date,
                location_id = events.location_id,
                organizer_id = events.organizer_id
            };

            return eventdto;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }

    public void AddEvent(CreateEventsDTO createEvents)
    {

        try
        {
            var events = new Events
            {
                event_name = createEvents.event_name,
                description = createEvents.description,
                start_date = createEvents.start_date,
                end_date = createEvents.end_date,
                location_id = createEvents.location_id,
                organizer_id=createEvents.organizer_id
            };

            if (createEvents != null)
            {
                _eventsDAL.InsertEvent(events);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }

    //public void UpdateEvent(Events updatedEvent)
    //{
    //    try
    //    {
    //        if (updatedEvent == null)
    //        {
    //            throw new ArgumentNullException(nameof(updatedEvent));
    //        }

    //        _eventsDAL.UpdateEvent(updatedEvent);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error occurred: {ex.Message}");
    //        throw;
    //    }
    //}

    //public void DeleteEvent(int eventId)
    //{
    //    try
    //    {
    //        _eventsDAL.DeleteEvent(eventId);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error occurred: {ex.Message}");
    //        throw;
    //    }
    //}

    public void UpdateEvent(UpdateEventsDTO updatedEvent)
    {

        try
        {
            var events = new Events
            {
                event_id = updatedEvent.event_id,
                event_name = updatedEvent.event_name,
                description = updatedEvent.description,
                start_date = updatedEvent.start_date,
                end_date = updatedEvent.end_date,
                location_id = updatedEvent.location_id,
                organizer_id = updatedEvent.organizer_id
            };

            if (updatedEvent != null)
            {
                _eventsDAL.UpdateEvent(events);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }

    public void DeleteEvent(int eventId)
    {
        _eventsDAL.DeleteEvent(eventId);
    }
}
