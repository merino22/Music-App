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
    public class AlbumService : IService<Album>
    {
        private readonly IRepository<Album> _albumRepository;

        public AlbumService(IRepository<Album> albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public IEnumerable<Album> Get()
        {
            return _albumRepository.Get();
        }

        public Result<Album> Get(string name)
        {
            var list = _albumRepository.Get(name);
            return list == null ? new Result<Album>($"Album {name} doesn't exist")
                : new Result<Album>(list);
        }

        public Result<Album> Get(int id)
        {
            var list = _albumRepository.Get(id);
            return list == null ? new Result<Album>($"Album {id} doesn't exist.")
                : new Result<Album>(list);
        }

        public Result<Album> Add(Album entity)
        {
            if (_albumRepository.Get().Any(x => x.Name == entity.Name))
            {
                return new Result<Album>($"Album {entity.Name} already exists.");
            }
            var entry = _albumRepository.Add(entity);
            return new Result<Album>(entry);
        }

        public Result<Album> Update(Album entity)
        {
            var list = _albumRepository.Update(entity);
            return new Result<Album>(list);
        }

        public Result<Album> Delete(string name)
        {
            var entity = _albumRepository.Get(name);
            if (entity == null)
            {
                return new Result<Album>($"Album {name} doesn't exists.");
            }
            return new Result<Album>(_albumRepository.Delete(entity));
        }
    }
}
