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
        //static int count = 1;
        //static List<Gymnast> gymnasts = new List<Gymnast>() { new Gymnast() { Id = count++, FirstName = "sara", LastName = "kloyzner", Day = 3 },
        //new Gymnast() { Id = count++, FirstName = "Chana", LastName = "Cohen", Day = 6 },
        //new Gymnast(){ Id = count++, FirstName = "Yona", LastName = "Nachmani", Day = 9 }};
        private readonly DataContext _gym;
        public GymnastController(DataContext lessonController)
        {
            _gym = lessonController;
        }
        // GET: api/<GymnastController>
        [HttpGet]
        public IEnumerable<Gymnast> Get()
        {
            return _gym.Gymnasts;
        }

        // GET api/<GymnastController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var obj= _gym.Gymnasts.Find(d=>d.Id == id);
            if(obj==null)
                return NotFound();
            
            return  Ok(obj);
        }

        // POST api/<GymnastController>
        [HttpPost]
        public void Post([FromBody] Gymnast value)
        {
            value.Id = _gym.Count1++;
            _gym.Gymnasts.Add(value);
            
        }

        // PUT api/<GymnastController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Gymnast value)
        {
            var obj= _gym.Gymnasts.Find(g=>g.Id == id);
            if (obj == null)
                return NotFound();
            obj.FirstName=value.FirstName;
            obj.LastName=value.LastName;
            obj.Day=value.Day;
            return Ok();
        }

        // DELETE api/<GymnastController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var obj = _gym.Gymnasts.Find(g => g.Id == id);
            if(obj==null)
                return NotFound();
            _gym.Gymnasts.Remove(obj);
            return Ok();
        }
    }
}
