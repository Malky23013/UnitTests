using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event> { new Event {Id=4, Start=new DateTime(2023,09,02)  },
        new Event { Id=5,Start=new DateTime(2023,09,01)  }
        ,new Event {Id=6, Start=new DateTime(2023,09,06)  } };

        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event newE)
        {
            events.Add(new Event {Id=newE.Id,Title=newE.Title, Start = newE.Start ,End=newE.End});
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public Event Put(int id, [FromBody] Event updateEvent)
        {
            //find the object by id
            var eve = events.Find(e => e.Id == id);
            //udpate properties
            eve.Id=updateEvent.Id;
            eve.Title = updateEvent.Title;
            eve.Start = updateEvent.Start;
            eve.End = updateEvent.End;
                
            return eve;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            events.Remove(eve);
        }
    }
}
