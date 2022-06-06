using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using AssistantManager.Core.Models;

namespace AssistantManager.Core.Services
{
    public class ReminderService : IService<Reminder>
    {
        private readonly IRepository<Reminder> _reminderRepository;

        public ReminderService(IRepository<Reminder> reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public Result<Reminder> Add(Reminder entity)
        {
            var entry = _reminderRepository.Add(entity);
            return new Result<Reminder>(entry);
        }

        public Result<Reminder> Delete(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reminder> Get()
        {
            return _reminderRepository.Get();
        }

        public Result<Reminder> Get(string name)
        {
            throw new NotImplementedException();
        }

        public Result<Reminder> Get(int id)
        {
            var reminder = _reminderRepository.Get(id);
            return reminder == null ? new Result<Reminder>("No se encontro recordatorio") 
                : new Result<Reminder>(reminder);
        }

        public Result<Reminder> Update(Reminder entity)
        {
            var reminder = _reminderRepository.Update(entity);
            return new Result<Reminder>(reminder);
        }
    }
}
