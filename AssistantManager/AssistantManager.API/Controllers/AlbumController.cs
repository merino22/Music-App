using AssistantManager.API.DataTransferObjects;
using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssistantManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IService<Album> _albumService;
        private readonly IService<Song> _songService;

        public AlbumController(IService<Album> albumService, IService<Song> songService)
        {
            _albumService = albumService;
            _songService = songService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlbumDTO>> Get()
        {
            return Ok(_albumService.Get().Select(x => new AlbumDTO
            {
                Id = x.Id,
                Name = x.Name,
                Artist = x.Artist,
                Review = x.Review,
                Rating = x.Rating,
                Price = x.Price,
                ReleaseDate = x.ReleaseDate,
                Genre = x.Genre,
                Label = x.Label
            }).ToList()
            );
        }

        [HttpPost]
        public ActionResult<AlbumDTO> Post([FromBody] AlbumDTO newAlbum)
        {
            var result = _albumService.Add(new Album
            {
                Id = newAlbum.Id,
                Name = newAlbum.Name,
                Artist = newAlbum.Artist,
                Review = newAlbum.Review,
                Rating = newAlbum.Rating,
                Price = newAlbum.Price,
                ReleaseDate = newAlbum.ReleaseDate,
                Genre = newAlbum.Genre,
                Label = newAlbum.Label
            });
            return result.Success ? Ok(new AlbumDTO
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Artist = result.Value.Artist,
                Review = result.Value.Review,
                Rating = result.Value.Rating,
                Price = result.Value.Price,
                ReleaseDate = result.Value.ReleaseDate,
                Genre = result.Value.Genre,
                Label = result.Value.Label
            }) : BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            var result = _albumService.Delete(name);
            return result.Success ? Ok(new AlbumDTO
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                Artist = result.Value.Artist,
                Review = result.Value.Review,
                Rating = result.Value.Rating,
                Price = result.Value.Price,
                ReleaseDate = result.Value.ReleaseDate,
                Genre = result.Value.Genre,
                Label = result.Value.Label
            }) : NotFound("Album not found!");
        }

        [HttpGet("{name}")]
        public ActionResult<IEnumerable<AlbumDTO>> Get(string name)
        {
            var result = _albumService.Get(name);
            if (result.Success)
            {
                return Ok(result.Value.Songs.Select(x => new SongDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Artist = x.Artist,
                    Time = x.Time,
                    Popularity = x.Popularity,
                    Price = x.Price
                }).ToList());
            }
            return NotFound(result.ErrorMessage);
        }

        [HttpGet("x/{name}")]
        public ActionResult<IEnumerable<AlbumDTO>> GetAlbum(string name)
        {
            var result = _albumService.Get(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.ErrorMessage);
        }

        [HttpPut]
        public ActionResult<IEnumerable<SongDTO>> AddSong([FromBody] ListSongsDTO listSongs)
        {
            var list = _albumService.Get(listSongs.ListName);

            if (list.Success)
            {
                listSongs.Songs.ToList()
                    .ForEach(song => list.Value.Songs
                   .Add(_songService.Get(song).Value));

                var result = _albumService.Update(list.Value);
                return Ok(result.Value.Songs.Select(x => new SongDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Artist = x.Artist,
                    Time = x.Time,
                    Popularity = x.Popularity,
                    Price = x.Price
                }));
            }
            return NotFound(list.ErrorMessage);
        }

        [HttpPut("{name}")] //Eliminar ingredientes de una lista
        public ActionResult<IEnumerable<SongDTO>> RemoveSong([FromBody] ListSongsDTO listSongs)
        {
            var list = _albumService.Get(listSongs.ListName);

            if (list.Success)
            {
                listSongs.Songs.ToList()
                    .ForEach(song => list.Value.Songs
                    .Remove(_songService.Get(song).Value));

                var result = _albumService.Update(list.Value);
                return Ok(result.Value.Songs.Select(x => new SongDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Artist = x.Artist,
                    Time = x.Time,
                    Popularity = x.Popularity,
                    Price = x.Price
                }));
            }
            return NotFound(list.ErrorMessage);
        }
    }
}
