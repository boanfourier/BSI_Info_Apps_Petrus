using AutoMapper;
using BSI_Info_APIService_BLL.DTOs;
using BSI_Info_APIService_BLL.Interface;
using BSI_Info_APIService_Data.Interface;
using BSI_Info_APIService_Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_Info_APIService_BLL
{
    public class TasksBLL : ITasksBLL
    {
        private readonly ITasksData _TasksData;
        private readonly IMapper _mapper;

        public TasksBLL(ITasksData TasksData, IMapper mapper)
        {
            _TasksData = TasksData;
            _mapper = mapper;
        }

        public async Task<TasksDTO> AddTasks(TasksCreateDTO entity)
        {
            try
            {
                var tasks = _mapper.Map<Tasks>(entity);
                var result = await _TasksData.Insert(tasks);
                var TasksDTO = _mapper.Map<TasksDTO>(result);
                return TasksDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTasks(int task_id)
        {
            try
            {
                await _TasksData.Delete(task_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TasksDTO>> GetAllTasks()
        {
            var tasks = await _TasksData.GetAll();
            var TasksDto = _mapper.Map<IEnumerable<TasksDTO>>(tasks);
            return TasksDto;
        }

        public async Task<TasksDTO> GetTasks(int task_id)
        {
            var tasks = await _TasksData.GetById(task_id);
            var TasksDto = _mapper.Map<TasksDTO>(tasks);
            return TasksDto;
        }

        public async Task<TasksDTO> UpdateTasks(int task_id, TasksUpdateDTO entity)
        {
            try
            {
                var tasks = _mapper.Map<Tasks>(entity);
                await _TasksData.Update(task_id, tasks);
                var TasksDTO = _mapper.Map<TasksDTO>(tasks);
                return TasksDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
