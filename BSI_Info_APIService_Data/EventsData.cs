using BSI_Info_APIService_Data.Interface;
using BSI_Info_APIService_Domain;
using Microsoft.EntityFrameworkCore;


namespace BSI_Info_APIService_Data
{
    public class EventsData : IEventsData
    {
        private readonly AppDbContext _context;
        public EventsData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var events = await GetById(id);
                if (events == null)
                {
                    throw new ArgumentException("Events not found");
                }
                _context.Events.Remove(events);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Events>> GetAll()
        {
            var Events = await _context.Events.FromSqlRaw("usp_GetEvents").ToListAsync();
            return Events;
        }

        public async Task<Events> GetById(int id)
        {
            var Events = await _context.Events.FindAsync(id);
            return Events;
        }

        public async Task<IEnumerable<Events>> GetByName(string name)
        {
            var Events = await _context.Events
              .Where(c => c.event_name.Contains(name))
              .OrderBy(c => c.event_name)
              .ToListAsync();
            return Events;
        }

        public async Task<Events> Insert(Events entity)
        {
            try
            {
                _context.Events.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Task<int> InsertWithIdentity(Events events)
        {
            throw new NotImplementedException();
        }

        public async Task<Events> Update(int id, Events entity)
        {
            try
            {
                var Events = await GetById(id);
                if (Events == null)
                {
                    throw new ArgumentException("Events not found");
                }
                Events.event_name = entity.event_name;
                await _context.SaveChangesAsync();
                return Events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
