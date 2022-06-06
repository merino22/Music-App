using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;

namespace AssistantManager.Infrastructure.Repositories
{
    public class ReminderEFRepository : IRepository<Reminder>
    {
        private readonly AssistantDatabaseContext _context;

        public ReminderEFRepository(AssistantDatabaseContext context)
        {
            _context = context;
        }

        public Reminder Add(Reminder entity)
        {
            var entry = _context.Reminders.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Reminder Delete(Reminder entity)
        {
            var entry = _context.Reminders.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<Reminder> Get()
        {
            return _context.Reminders;
        }

        public Reminder Get(string name)
        {
            throw new NotImplementedException();
        }

        public Reminder Get(int id)
        {
            return _context.Reminders.SingleOrDefault(x => x.Id == id);
        }

        public Reminder Update(Reminder entity)
        {
            var entry = _context.Reminders.Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
