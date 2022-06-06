using AssistantManager.API.DataTransferObjects;
using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistantManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private readonly IService<Song> _songService;

        public SongController(IService<Song> songService)
        {
            _songService = songService;
        }

        [HttpGet] //Listado de ingredientes en su tabla
        public ActionResult<IEnumerable<SongDTO>> Get()
        {
            return Ok(_songService.Get().Select(x => new SongDTO
            {
                Id = x.Id,
                Name = x.Name,
                Artist = x.Artist,
                Time = x.Time,
                Popularity = x.Popularity,
                Price = x.Price
            }).ToList()
            );
        }

        [HttpPost] //Agregar ingrediente a tabla
        public ActionResult<SongDTO> Post([FromBody] SongDTO newSong)
        {
            var result = _songService.Add(new Song
            {
                Id = newSong.Id,
                Name = newSong.Name,
                Artist = newSong.Artist,
                Time = newSong.Time,
                Popularity = newSong.Popularity,
                Price = newSong.Price
            });
            return result.Success ? Ok(new SongDTO
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Artist = result.Value.Artist,
                Time = result.Value.Time,
                Popularity = result.Value.Popularity,
                Price = result.Value.Price
            }) : BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{name}")] //Eliminar ingrediente de tabla
        public ActionResult Delete(string name)
        {
            var result = _songService.Delete(name);
            return result.Success ? Ok(new SongDTO
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Artist = result.Value.Artist,
                Time = result.Value.Time,
                Popularity = result.Value.Popularity,
                Price = result.Value.Price
            }) : NotFound("Song not found!");
        }
    }
}
