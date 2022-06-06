using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;

namespace AssistantManager.Infrastructure.Repositories
{
    public class SongEFRepository : IRepository<Song>
    {
        private readonly AssistantDatabaseContext _context;

        public SongEFRepository(AssistantDatabaseContext context)
        {
            _context = context;
        }

        public Song Add(Song entity)
        {
            var entry = _context.Songs.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Song Delete(Song entity)
        {
            var entry = _context.Songs.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<Song> Get()
        {
            return _context.Songs;
        }

        public Song Get(string name)
        {
            return _context.Songs.SingleOrDefault(x => x.Name == name);
        }

        public Song Get(int id)
        {
            return _context.Songs.SingleOrDefault(x => x.Id == id);
        }

        public Song Update(Song entity)
        {
            var entry = _context.Songs.Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
