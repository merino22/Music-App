using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistantManager.Core.Entities
{
    public class Album
    {
        public Album()
        {
            this.Songs = new List<Song>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }
        public string Review { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Label { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}

