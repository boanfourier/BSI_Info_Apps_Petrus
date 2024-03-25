using AutoMapper;
using BSI_Info_APIService_BLL.DTOs;
using BSI_Info_APIService_BLL.Interface;
using BSI_Info_APIService_Data.Interface;
using BSI_Info_APIService_Domain;

namespace BSI_Info_APIService_BLL
{
    public class EventsBLL : IEventsBLL
    {
        private readonly IEventsData _EventsData;
        private readonly IMapper _mapper;

        public EventsBLL(IEventsData EventsData, IMapper mapper)
        {
            _EventsData = EventsData;
            _mapper = mapper;
        }

        public async Task<EventsDTO> AddEvent(EventsCreateDTO entity)
        {
            try
            {
                var events = _mapper.Map<Events>(entity);
                var result = await _EventsData.Insert(events);
                var EventsDTO = _mapper.Map<EventsDTO>(result);
                return EventsDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int event_id)
        {
            try
            {
                await _EventsData.Delete(event_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EventsDTO>> GetAllEvents()
        {
            var events = await _EventsData.GetAll();
            var EventsDto = _mapper.Map<IEnumerable<EventsDTO>>(events);
            return EventsDto;
        }

        public async Task<EventsDTO> GetEventById(int event_id)
        {
            var events = await _EventsData.GetById(event_id);
            var EventsDto = _mapper.Map<EventsDTO>(events);
            return EventsDto;
        }

        public async Task<EventsDTO> UpdateEvent(int event_id, EventsUpdateDTO entity)
        {
            try
            {
                var events = _mapper.Map<Events>(entity);
                await _EventsData.Update(event_id, events);
                var EventsDto = _mapper.Map<EventsDTO>(events);
                return EventsDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
