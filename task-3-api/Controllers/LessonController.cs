using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace task_3_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        // GET: api/<LessonController>
        static int numOfLessom = 0;
        static List<Lesson> lessons = new List<Lesson>() {
            new Lesson() { Id=numOfLessom++,Day=1,CountOfWomen=10,Type="Eroby"},
         new Lesson() { Id=numOfLessom++,Day=4,CountOfWomen=12,Type="Yoge"}};
        [HttpGet]
        public IEnumerable<Lesson> Get()
        {
            return lessons;
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public Lesson Get(int id)
        {
            var obj=lessons.Find(u=>u.Id==id);
            return obj;
        }
 
        [HttpGet("type")]
        public Lesson Get(string type)
        {
            var obj = lessons.Find(u => u.Type== type);
            return obj;
        }
        // POST api/<LessonController>
        [HttpPost]
        public void Post([FromBody] Lesson value)
        {
            value.Id= numOfLessom++;    
            lessons.Add(value); 

        }

        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Lesson value)
        {
            var obj=lessons .Find(u=>u.Id==id);
            obj.Type = value.Type;
            obj.Day = value.Day;
            obj.CountOfWomen = value.CountOfWomen;

        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = lessons.Find(u => u.Id == id);
            lessons.Remove(obj);
        }

    }
}
