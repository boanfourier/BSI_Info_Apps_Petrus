using BSI_Info_APIService_BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_Info_APIService_BLL.Interface
{
    public interface IEventsBLL
    {
        Task<IEnumerable<EventsDTO>> GetAllEvents();

        Task<EventsDTO> GetEventById(int event_id);

        Task<EventsDTO> AddEvent(EventsCreateDTO entity);

        Task<EventsDTO> UpdateEvent(int eventId, EventsUpdateDTO entity);

        Task<bool> DeleteEvent(int event_id);
    }
}
