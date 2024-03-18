using BSI_Info_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;



public interface IEventsBLL
{
    void AddEvent(CreateEventsDTO newEvent);
    void UpdateEvent(UpdateEventsDTO updatedEvent);
    void DeleteEvent(int eventId);
    IEnumerable<EventsDTO> GetAllEvents();
    EventsDTO GetEventById(int eventId);
}

