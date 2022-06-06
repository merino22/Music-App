using AssistantManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistantManager.API.DataTransferObjects
{
    public class SongDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }
        public int Time { get; set; }
        public double Popularity { get; set; }
        public double Price { get; set; }
    }
}
