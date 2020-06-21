using Kolokwium.DTOs;
using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IDBService
    {
        public ArtistResponse GetArtist(int id);

        public ArtistEvent UpdateArtistEvent(int id, int idEvent,ArtistEvent artistEvent);

    }
}
