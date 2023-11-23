using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace task_3_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly DataContext _lesson;
        public LessonController(DataContext lessonController)
        {
            _lesson = lessonController;
        }
        // GET: api/<LessonController>
        //static int numOfLessom = 0;
        //static List<Lesson> lessons = new List<Lesson>() {
        //    new Lesson() { Id=numOfLessom++,Day=1,CountOfWomen=10,Type="Eroby"},
        // new Lesson() { Id=numOfLessom++,Day=4,CountOfWomen=12,Type="Yoge"}};
        [HttpGet]
        public IEnumerable<Lesson> Get()
        {
            return _lesson.Lessons;
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var obj = _lesson.Lessons.Find(u=>u.Id==id);

            if (obj == null)
                return NotFound();
            return Ok(obj);
        }
 
        [HttpGet("type")]
        public ActionResult Get(string type)
        {
            var obj = _lesson.Lessons.Find(u => u.Type== type);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }
        // POST api/<LessonController>
        [HttpPost]
        public void Post([FromBody] Lesson value)
        {
            value.Id= _lesson.numOfLessom++;
            _lesson.Lessons.Add(value); 

        }

        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Lesson value)
        {
            var obj = _lesson.Lessons.Find(u=>u.Id==id);
            if (obj == null)
                return NotFound();
            obj.Type = value.Type;
            obj.Day = value.Day;
            obj.CountOfWomen = value.CountOfWomen;
            return Ok();
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var obj = _lesson.Lessons.Find(u => u.Id == id);
            if (obj == null)
                return NotFound();
            _lesson.Lessons.Remove(obj);
            return Ok();
        }

    }
}
