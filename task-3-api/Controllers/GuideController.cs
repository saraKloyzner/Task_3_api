using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace task_3_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GuideController : ControllerBase
    {
        //static int count = 0;
        //static List<Guide> guides = new List<Guide>() 
        //{ new Guide() { Id = count++, FirstName = "Orly", LastName = "Ben Menachem", Days = new List<int>(){1,2,4} },
        //new Guide() { Id=count++,FirstName="Ruth",LastName="Nankansky",Days= new List<int>() {2, 3, 5 }} };
        // GET: api/<Guide>
        private readonly DataContext _guide;
        public GuideController(DataContext lessonController)
        {
            _guide = lessonController;
        }
        [HttpGet]
        public IEnumerable<Guide> Get()
        {
            return _guide.Guides;
        }

        // GET api/<Guide>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var obj = _guide.Guides.Find(x => x.Id == id);
            if(obj==null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/<Guide>
        [HttpPost]
        public void Post([FromBody] Guide value)
        {
            value.Id= _guide.Count++;
            _guide.Guides.Add(value);
        }

        // PUT api/<Guide>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Guide value)
        {
            var obj = _guide.Guides.Find(y => y.Id == value.Id);
            if (obj == null)
                return NotFound();
            obj.FirstName=value.FirstName;
            obj.LastName=value.LastName;
            obj.Days = value.Days;
            return Ok();

        }

        // DELETE api/<Guide>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var obj = _guide.Guides.Find(u=>u.Id==id);
            if(obj==null)
                return NotFound();
            _guide.Guides.Remove(obj);
            return Ok();
        }
    }
}
