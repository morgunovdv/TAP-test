using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAP_test.Models;
using System.Collections.Generic;

namespace TAP_test.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private List<Skill> skills(List<Skill> oldSkills, List<Skill> newSkills)
        {
            Skill skill = new Skill();
            for (int i = 0; i < oldSkills.Count; i++)
            {
                if (i != 0)
                {
                    for (int j = 0; j < newSkills.Count; j++)
                    {
                        if(oldSkills[i].Name == newSkills[j].Name)
                        {
                            if (oldSkills[i].Level != newSkills[j].Level)
                            {
                                oldSkills[i].Level = newSkills[j].Level;
                            }
                        }
                        skill = newSkills[j];
                    }
                }

                else
                {
                    oldSkills.Add(skill);
                }
            }


            //foreach (Skill personSkill in oldSkills)
            //{
            //    if (oldSkills != null)
            //    {
            //        foreach (Skill skill in newSkills)
            //        {

            //            if (personSkill.Name == skill.Name)
            //            {
            //                if (personSkill.Level != skill.Level)
            //                {
            //                    personSkill.Level = skill.Level;
            //                }
            //            }

            //            else
            //            {
            //                oldSkills.Add(skill);
            //            }

            //        }
            //    }
            //}

            return oldSkills;
        }   
        

        private readonly Context _context;

        public PersonController(Context context)
        {
            _context = context;
        }

        // GET: api/v1/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {
            var person = await _context.Persons
                                    .Include(x => x.Skills)
                                    .FirstOrDefaultAsync(x => x.Id == id);


            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/v1/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(long id, Person person)
        {

            if (id != person.Id)
            {
                person.Id = id;
            }

            skills(person.Skills, person.Skills);

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/v1/Person
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/v1/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(long id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(long id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
