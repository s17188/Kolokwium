using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.DTOs
{
    public class ArtistResponse
    {
        public int IdArtist { get; set; }
        public String Nickname { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
