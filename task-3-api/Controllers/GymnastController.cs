using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace task_3_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymnastController : ControllerBase
    {
        static int count = 1;
        static List<Gymnast> gymnasts = new List<Gymnast>() { new Gymnast() { Id = count++, FirstName = "sara", LastName = "kloyzner", Day = 3 },
        new Gymnast() { Id = count++, FirstName = "Chana", LastName = "Cohen", Day = 6 },
        new Gymnast(){ Id = count++, FirstName = "Yona", LastName = "Nachmani", Day = 9 }};

        // GET: api/<GymnastController>
        [HttpGet]
        public IEnumerable<Gymnast> Get()
        {
            return gymnasts;
        }

        // GET api/<GymnastController>/5
        [HttpGet("{id}")]
        public Gymnast Get(int id)
        {
            var obj=gymnasts.Find(d=>d.Id == id);

            return obj;
        }

        // POST api/<GymnastController>
        [HttpPost]
        public void Post([FromBody] Gymnast value)
        {
            value.Id = count++;
            gymnasts.Add(value);
            
        }

        // PUT api/<GymnastController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Gymnast value)
        {
            var obj= gymnasts.Find(g=>g.Id == id);
            obj.FirstName=value.FirstName;
            obj.LastName=value.LastName;
            obj.Day=value.Day;
        }

        // DELETE api/<GymnastController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = gymnasts.Find(g => g.Id == id);
            gymnasts.Remove(obj);
        }
    }
}
