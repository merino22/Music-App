using AssistantManager.API.DataTransferObjects;
using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssistantManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemindersController : ControllerBase
    {
        private readonly IService<Reminder> _reminderService;
        public RemindersController(IService<Reminder> reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpGet] 
        public ActionResult<IEnumerable<ReminderDTO>> Get()
        {
            return Ok(_reminderService.Get().Select(x => new ReminderDTO
            {
                Id = x.Id,
                Message = x.Message,
                DateTime = x.DateTime
            }).ToList()
            );
        }

        [HttpPost]
        public ActionResult<GroceryListDTO> Post([FromBody] ReminderDTO newReminder)
        {
            var result = _reminderService.Add(new Reminder
            {
                Message = newReminder.Message,
                DateTime = newReminder.DateTime
            });
            return result.Success ? Ok(new ReminderDTO
            {
                Id = result.Value.Id,
                Message = result.Value.Message,
                DateTime = newReminder.DateTime
            }) : BadRequest(result.ErrorMessage);
        }
    }
}
