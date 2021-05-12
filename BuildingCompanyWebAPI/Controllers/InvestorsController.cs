using BuildingCompanyModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingCompanyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorsController : ControllerBase
    {
        private readonly BuildingCompanyContext _context;

        public InvestorsController(BuildingCompanyContext context)
        {
            _context = context;
        }

        // GET: api/Investors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investor>>> GetInvestors()
        {
            return await _context.Investors.ToListAsync();
        }

        // GET: api/Investors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investor>> GetInvestor(int id)
        {
            var investor = await _context.Investors.FindAsync(id);

            if (investor == null)
            {
                return NotFound();
            }

            return investor;
        }

        // PUT: api/Investors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestor(int id, Investor investor)
        {
            if (id != investor.Id)
            {
                return BadRequest();
            }

            _context.Entry(investor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestorExists(id))
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

        // POST: api/Investors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Investor>> PostInvestor(Investor investor)
        {
            _context.Investors.Add(investor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestor", new { id = investor.Id }, investor);
        }

        // DELETE: api/Investors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestor(int id)
        {
            var investor = await _context.Investors.FindAsync(id);
            if (investor == null)
            {
                return NotFound();
            }

            _context.Investors.Remove(investor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvestorExists(int id)
        {
            return _context.Investors.Any(e => e.Id == id);
        }
    }
}
