using Kolokwium.DTOs;
using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class SqlServerService : IDBService
    {
        private readonly s17188Context _context;

        public SqlServerService(s17188Context context)
        {
            _context = context;
        }

        public ArtistResponse GetArtist(int id)
        {
            var artistExist = _context.Artist.Any(t => t.IdArtist.Equals(id));
            if (!artistExist)
            {
                throw new Exception("Nie ma Artysty");
            }
            else
            {
                var artist = _context.Artist.Where(e => e.IdArtist == id).Single();

                var artistEvent = _context.ArtistEvent.Where(e => e.IdArtist == id).ToList();

                List<Event> eventResults = new List<Event>();

                foreach (var eventItem in artistEvent)
                {
                    eventResults.Add(
                        _context.Event.Single(x => x.IdEvent.Equals(eventItem.IdEvent))
                    );
                }

                List<Event> sortList = new List<Event>(eventResults.OrderByDescending(e => e.StartDate));

                ArtistResponse artistResponse = new ArtistResponse{ 
                    IdArtist= artist.IdArtist,
                    Nickname= artist.Nickname,
                    Events= sortList
                };
                return artistResponse;
            }
        }

        public ArtistEvent UpdateArtistEvent(int id, int idEvent,ArtistEvent artistEventRequest)
        {
            var artistEventExist = _context.ArtistEvent.Where(e => e.IdEvent == idEvent && e.IdArtist == id).Any();
            if (!artistEventExist)
            {
                throw new Exception($"Nie ma eventu w ktorym wystepuje artysta z id = {id} oraz eventu z id = {idEvent}");
            }
            else
            {

                var artistEvent = _context.Event.Where(e => e.IdEvent == idEvent).Single();

                if(artistEvent.StartDate < artistEventRequest.PerformanceDate && artistEvent.EndDate > artistEventRequest.PerformanceDate)
                {
                    var e1 = new ArtistEvent
                    {
                        IdArtist = id,
                        IdEvent = idEvent,
                        PerformanceDate = artistEventRequest.PerformanceDate
                    };

                    _context.Attach(e1);
                    _context.Entry(e1).Property("PerformanceDate").IsModified = true;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"Nieprawidlowa data, lub data nie miesci sie pomiedzy rozpoczeciem eventu a jego zakonczeniem.");
                }


            }
            return artistEventRequest;
        }
    }
}
