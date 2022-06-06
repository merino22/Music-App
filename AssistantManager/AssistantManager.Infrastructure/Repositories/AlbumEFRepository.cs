using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssistantManager.Infrastructure.Repositories
{
    public class AlbumEFRepository : IRepository<Album>
    {
        private readonly AssistantDatabaseContext _context;

        public AlbumEFRepository(AssistantDatabaseContext context)
        {
            _context = context;
        }

        public Album Add(Album entity)
        {
            var entry = _context.Albums.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Album Delete(Album entity)
        {
            var entry = _context.Albums.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Album Update(Album entity)
        {
            var entry = _context.Albums.Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<Album> Get()
        {
            return _context.Albums;
        }

        public Album Get(string name)
        {
            return _context.Albums.Include(x => x.Songs).SingleOrDefault(x => x.Name == name);
        }

        public Album Get(int id)
        {
            return _context.Albums.Include(x => x.Songs).SingleOrDefault(x => x.Id == id);
        }
    }
}
