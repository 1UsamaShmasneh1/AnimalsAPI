using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnimalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [BindProperty(SupportsGet = true)]
        public List<AnimalModel> Animals { get; set; }

        public AnimalsController() {
            Animals = new List<AnimalModel>();
            Animals.Add(new AnimalModel() { Name = "cat", age = 5 });
            Animals.Add(new AnimalModel() { Name = "dog", age = 9 });
            Animals.Add(new AnimalModel() { Name = "bird", age = 10 });
            Animals.Add(new AnimalModel() { Name = "fish", age = 4 });
            Animals.Add(new AnimalModel() { Name = "chicken", age = 2 });
        }

        [HttpGet("{name}")]
        public IActionResult GetAnimalByName(string name)
        {
            foreach (var a in Animals)
            {
                if (a.Name == "giraffe")
                    return AcceptedAtAction(nameof(GetSmile));
                else if (a.Name == name)
                    return Ok(a);
            }
            return NotFound();
        }

        [HttpGet("spesial/{name}")]
        public ActionResult<AnimalModel> GetAnimalByName2(string name)
        {
            foreach (var a in Animals)
            {
                if (a.Name == name)
                    return a;
            }
            return NotFound();
        }

        [HttpGet("smile")]
        public IActionResult GetSmile()
        {
            return Ok("It is a giraffe :)");
        }
    }
}
