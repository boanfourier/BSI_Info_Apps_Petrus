using BSI_Info_APIService_BLL.DTOs;
using BSI_Info_APIService_BLL.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSI_Info_APIService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksBLL _TasksBLL;
        //Validation
        private readonly IValidator<TasksCreateDTO> _validatorTasksCreateDto;
        private readonly IValidator<TasksUpdateDTO> _validatorTasksUpdateDto;

        public TasksController(ITasksBLL tasksBLL,
          IValidator<TasksCreateDTO> validatorTasksCreateDto,
          IValidator<TasksUpdateDTO> validatorTasksUpdateDto)
        {
            _TasksBLL = tasksBLL;
            _validatorTasksCreateDto = validatorTasksCreateDto;
            _validatorTasksUpdateDto = validatorTasksUpdateDto;
        }

        //Get All Tasks
        [HttpGet]
        [Authorize(Roles = "Organizer,Participant")]
        public async Task<IEnumerable<TasksDTO>> Get()
        {
            var results = await _TasksBLL.GetAllTasks();
            return results;
        }

        //Get By task_id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _TasksBLL.GetTasks(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //Add Tasks
        [HttpPost]
        [Authorize(Roles = "Organizer,Participant")]
        public async Task<IActionResult> Post(int id, TasksCreateDTO tasksCreateDTO)
        {
            var validateResult = await _validatorTasksCreateDto.ValidateAsync(tasksCreateDTO);

            if (!validateResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validateResult, ModelState);
                return BadRequest(ModelState);
            }
            try
            {
                var newEvents = await _TasksBLL.AddTasks(tasksCreateDTO);
                return CreatedAtAction("Get", new { id = id }, newEvents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Edit Tasks
        [HttpPut("{id}")]
        [Authorize(Roles = "Organizer,Participant")]
        public async Task<IActionResult> Put(int id, TasksUpdateDTO tasksUpdateDTO)
        {
            var validateResult = await _validatorTasksUpdateDto.ValidateAsync(tasksUpdateDTO);

            if (!validateResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validateResult, ModelState);
                return BadRequest(ModelState);
            }

            try
            {
                await _TasksBLL.UpdateTasks(id, tasksUpdateDTO);
                return Ok("Update data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Delete Tasks
        [HttpDelete("{id}")]
        [Authorize(Roles = "Organizer,Participant")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _TasksBLL.DeleteTasks(id);
                return Ok("Delete data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
