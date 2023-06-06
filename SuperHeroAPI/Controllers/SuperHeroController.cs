using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero {
                Id = 1,
                Name = "Captain America",
                FirstName = "Steve",
                LastName = "Roger",
                Place = "Brooklyn"
            },
            new SuperHero {
                Id = 2,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            SuperHero hero = heroes.Find(x => x.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero UpdatedHero)
        {
            SuperHero hero = heroes.Find(x => x.Id == UpdatedHero.Id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found");
            }
            hero.Name = UpdatedHero.Name;
            hero.FirstName = UpdatedHero.FirstName;
            hero.LastName = UpdatedHero.LastName;
            hero.Place = UpdatedHero.Place;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            SuperHero hero = heroes.Find(x => x.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found");
            }
            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
