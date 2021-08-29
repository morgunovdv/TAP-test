using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAP_test.Models;

namespace TAP_test.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly Context _context;

        public PersonsController(Context context)
        {
            _context = context;
        }

        // GET: api/v1/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await _context.Persons.Include(x => x.Skills).ToListAsync();
        }
    }
}
