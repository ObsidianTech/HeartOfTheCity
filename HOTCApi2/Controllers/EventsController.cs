﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HOTCAPILibrary.Data;
using HOTCAPILibrary.DTOs;
using HOTCAPILibrary.Managers;
using HOTCAPILibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOTCApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EventsManager _EM;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
            _EM = new EventsManager(_context);

        }

        // GET api/values - for testing 
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("{City}")]
        public List<Event> GetLocalEventsAtStartup(string City)
        {
            List<Event> LocalEvents = new List<Event>();
            return _EM.GetLocalEvents(City);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<Event> Post([FromBody]Event newEvent)
        {
            var newEventLocation = new Event();
            return await _EM.CreateNewEvent(newEvent);
        }

        [HttpPut]
        [Route("image/{EventID}")]
        public void AddImageToEvent([FromBody]byte[] ByteArray, int EventID)
        {
            _EM.AttachImage(ByteArray, EventID);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
