using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using AssistantManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantManager.Core.Services
{
    public class SongService : IService<Song>
    {
        private readonly IRepository<Song> _songRepository;

        public SongService(IRepository<Song> songRepository)
        {
            _songRepository = songRepository;
        }

        public IEnumerable<Song> Get()
        {
            return _songRepository.Get();
        }

        public Result<Song> Get(string name)
        {
            var song = _songRepository.Get(name);
            if (song == null)
            {
                song = new Song
                {
                    Name = name
                };
                song = _songRepository.Add(song);
            }
            return new Result<Song>(song);
        }

        public Result <Song> Get(int id)
        {
            var song = _songRepository.Get(id);
            if (song == null)
            {
                song = new Song
                {
                    Id = id
                };
                song = _songRepository.Add(song);
            }
            return new Result<Song>(song);
        }

        public Result<Song> Add(Song entity)
        {
            if (_songRepository.Get().Any(x => x.Name == entity.Name))
            {
                return new Result<Song>($"Song {entity.Name} already exists");
            }
            var entry = _songRepository.Add(entity);
            return new Result<Song>(entry);
        }

        public Result<Song> Update(Song entity)
        {
            throw new NotImplementedException();
        }

        public Result<Song> Delete(string name)
        {
            var entity = _songRepository.Get(name);
            if (entity == null)
            {
                return new Result<Song>($"Song {name} doesn't exist");
            }
            return new Result<Song>(_songRepository.Delete(entity));
        }
    }
}
