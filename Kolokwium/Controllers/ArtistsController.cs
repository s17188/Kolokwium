using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IDBService dBService;
        public ArtistsController(IDBService service)
        {
            dBService = service;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetArtist(int id)
        {
            IActionResult res;
            try
            {
                res = Ok(dBService.GetArtist(id));
            }
            catch (Exception e)
            {
                res = NotFound($"Nie znaleziono artysty z id = {id}");
            }
            return res;
        }

        [HttpPut]
        [Route("{id}/events/{idEvent}")]

        public IActionResult UpdateArtist(int id,int idEvent,ArtistEvent artistEvent)
        {
            IActionResult res;
            try
            {
                res = Ok(dBService.UpdateArtistEvent(id,idEvent,artistEvent));
            }
            catch (Exception e)
            {
                res = NotFound($"Nie ma eventu w ktorym wystepuje artysta z id = {id} oraz eventu z id = {idEvent}, lub data nie miesci sie pomiedzy rozpoczeciem eventu a jego zakonczeniem.");
            }



            return res;
        }

    }
}