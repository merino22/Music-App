using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistantManager.API.DataTransferObjects
{
    public class AlbumDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }
        public string Review { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Label { get; set; }
    }
}
