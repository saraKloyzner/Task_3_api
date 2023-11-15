using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace task_3_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GuideController : ControllerBase
    {
        static int count = 0;
        static List<Guide> guides = new List<Guide>() 
        { new Guide() { Id = count++, FirstName = "Orly", LastName = "Ben Menachem", Days = new List<int>(){1,2,4} },
        new Guide() { Id=count++,FirstName="Ruth",LastName="Nankansky",Days= new List<int>() {2, 3, 5 }} };
            // GET: api/<Guide>
            [HttpGet]
        public IEnumerable<Guide> Get()
        {
            return guides;
        }

        // GET api/<Guide>/5
        [HttpGet("{id}")]
        public Guide Get(int id)
        {
            var obj=guides.Find(x => x.Id == id);
            return obj;
        }

        // POST api/<Guide>
        [HttpPost]
        public void Post([FromBody] Guide value)
        {
            value.Id=count++;
            guides.Add(value);
        }

        // PUT api/<Guide>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Guide value)
        {
            var obj = guides.Find(y => y.Id == value.Id);
            obj.FirstName=value.FirstName;
            obj.LastName=value.LastName;
            obj.Days = value.Days;

        }

        // DELETE api/<Guide>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj=guides.Find(u=>u.Id==id);
            guides.Remove(obj);
        }
    }
}
