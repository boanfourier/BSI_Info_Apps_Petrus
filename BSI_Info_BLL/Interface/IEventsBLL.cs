using System;
using System.Collections.Generic;
using System.Text;
using BSI_Info_Apps;


public interface IEventsBLL
{
    void AddEvent(CreateEventsDTO newEvent);
    void UpdateEvent(UpdateEventsDTO updatedEvent);
    void DeleteEvent(int eventId);
    IEnumerable<EventsDTO> GetAllEvents();
    EventsDTO GetEventById(int eventId);
}

