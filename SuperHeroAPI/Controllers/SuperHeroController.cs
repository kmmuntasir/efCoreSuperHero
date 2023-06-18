using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext context;

        public SuperHeroController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await context.SuperHeros.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            SuperHero hero = await context.SuperHeros.FindAsync(id);
            if (hero == null)
            {
                return NotFound("Hero Not Found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            context.SuperHeros.Add(hero);
            await context.SaveChangesAsync();
            return Ok(await context.SuperHeros.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero UpdatedHero)
        {
            SuperHero hero = await context.SuperHeros.FindAsync(UpdatedHero.Id);
            if (hero == null)
            {
                return NotFound("Hero Not Found");
            }
            hero.Name = UpdatedHero.Name;
            hero.FirstName = UpdatedHero.FirstName;
            hero.LastName = UpdatedHero.LastName;
            hero.Place = UpdatedHero.Place;

            await context.SaveChangesAsync();

            return Ok(await context.SuperHeros.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            SuperHero hero = await context.SuperHeros.FindAsync(id);
            if (hero == null)
            {
                return NotFound("Hero Not Found");
            }
            context.SuperHeros.Remove(hero);

            await context.SaveChangesAsync();

            return Ok(await context.SuperHeros.ToListAsync());
        }
    }
}
