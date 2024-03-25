using System.Collections.Generic;
using System.Threading.Tasks;
using BSI_Info_APIService_BLL.DTOs;
using BSI_Info_APIService_BLL.Interface;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace BSI_Info_APIService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsBLL _EventsBLL;
        //Validation
        private readonly IValidator<EventsCreateDTO> _validatorEventsCreateDto;
        private readonly IValidator<EventsUpdateDTO> _validatorEventsUpdateDto;

        public EventsController(IEventsBLL EventsBLL,
          IValidator<EventsCreateDTO> validatorEventsCreateDto,
          IValidator<EventsUpdateDTO> validatorEventsUpdateDto)
        {
            _EventsBLL = EventsBLL;
            _validatorEventsCreateDto = validatorEventsCreateDto;
            _validatorEventsUpdateDto = validatorEventsUpdateDto;
        }

        //Get All Events
        [HttpGet]
        [Authorize(Roles = "Organizer,Participant")]
        public async Task<IEnumerable<EventsDTO>> Get()
        {
            var results = await _EventsBLL.GetAllEvents();
            return results;
        }

        //Get By event_id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _EventsBLL.GetEventById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //Add Events
        [HttpPost]
        [Authorize(Roles = "Organizer,Participant")]
        public async Task<IActionResult> Post(int id, EventsCreateDTO eventsCreateDTO)
        {
            var validateResult = await _validatorEventsCreateDto.ValidateAsync(eventsCreateDTO);

            if (!validateResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validateResult, ModelState);
                return BadRequest(ModelState);
            }
            try
            {
                var newEvents = await _EventsBLL.AddEvent(eventsCreateDTO);
                return CreatedAtAction("Get", new { id = id }, newEvents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Edit Events
        [HttpPut("{id}")]
        [Authorize(Roles = "Organizer,Participant")]
        public async Task<IActionResult> Put(int id, EventsUpdateDTO eventsUpdateDTO)
        {
            var validateResult = await _validatorEventsUpdateDto.ValidateAsync(eventsUpdateDTO);

            if (!validateResult.IsValid)
            {
                Helpers.Extensions.AddToModelState(validateResult, ModelState);
                return BadRequest(ModelState);
            }

            try
            {
                await _EventsBLL.UpdateEvent(id, eventsUpdateDTO);
                return Ok("Update data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Delete Events
        [HttpDelete("{id}")]
        [Authorize(Roles = "Organizer,Participant")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _EventsBLL.DeleteEvent(id);
                return Ok("Delete data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
