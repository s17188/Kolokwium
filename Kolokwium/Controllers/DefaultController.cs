using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IDBService dBService;
        public DefaultController(IDBService service)
        {
            dBService = service;
        }

        [HttpGet]
        [Route("championship")]
        public IActionResult GetTracks()
        {
            var res = 0;
            return Ok(res);
        }

        [HttpPost]
        [Route("teams/{teamId}/players")]

        public IActionResult InsertPlayer()
        {
            //IActionResult res;
            //try
            //{
            //    res = Ok(dBService.GetTrackById(id));
            //}
            //catch (Exception e)
            //{
            //   res = NotFound($"Not found track with id {id}");
            //}
            //return res;
            return null;
        }

    }
}