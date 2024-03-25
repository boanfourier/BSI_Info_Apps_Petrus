using BSI_Info_APIService_Data.Interface;
using BSI_Info_APIService_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_Info_APIService_Data
{
    public class TasksData : ITasksData
    {
        private readonly AppDbContext _context;
        public TasksData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var Tasks = await GetById(id);
                if (Tasks == null)
                {
                    throw new ArgumentException("Tasks not found");
                }
                _context.Tasks.Remove(Tasks);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Tasks>> GetAll()
        {
            var Tasks = await _context.Tasks.FromSqlRaw("usp_GetTasks").ToListAsync();
            return Tasks;
        }

        public async Task<Tasks> GetById(int id)
        {
            var Tasks = await _context.Tasks.FindAsync(id);
            return Tasks;
        }

        public async Task<Tasks> Insert(Tasks entity)
        {
            try
            {
                _context.Tasks.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Task<int> InsertWithIdentity(Tasks tasks)
        {
            throw new NotImplementedException();
        }

        public async Task<Tasks> Update(int id, Tasks entity)
        {
            try
            {
                var Tasks = await GetById(id);
                if (Tasks == null)
                {
                    throw new ArgumentException("Tasks not found");
                }
                Tasks.task_id = entity.task_id;
                await _context.SaveChangesAsync();
                return Tasks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
