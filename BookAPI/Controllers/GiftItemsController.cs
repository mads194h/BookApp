using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPI.DataContexts;
using BookAPI.Models;

namespace BookAPI.Controllers
{
    [Route("api/giftitems")]
    [ApiController]
    public class GiftItemsController : ControllerBase
    {
        private readonly GiftDataContext _context;

        public GiftItemsController(GiftDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllGifts()
        {
            return Ok(_context.GiftItem);
        }

        [HttpGet("giftsByNymber")]
        public IActionResult GetGiftsByNumber([FromBody] int giftnumber)
        {
            return Ok(_context.GiftItem.Where(g => g.GiftNumber == giftnumber));
        }

        [HttpGet("giftsForBoys")]
        public IActionResult GetGiftsForBoy()
        {
            return Ok(_context.GiftItem.Where(g => g.BoyGift == true));
        }

        [HttpGet("giftsForGirls")]
        public IActionResult GetGiftsForGirl()
        {
            return Ok(_context.GiftItem.Where(g => g.GirlGift == true));
        }

        [HttpPost("addGift")]
        public async Task<IActionResult> AddGift([FromBody] GiftItem giftItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            giftItem.CreationDate = DateTime.Now;


            _context.GiftItem.Add(giftItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiftItem", new { id = giftItem.GiftNumber }, giftItem);
        }

        // GET: api/GiftItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGiftItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var giftItem = await _context.GiftItem.FindAsync(id);

            if (giftItem == null)
            {
                return NotFound();
            }

            return Ok(giftItem);
        }

        // PUT: api/GiftItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiftItem([FromRoute] int id, [FromBody] GiftItem giftItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != giftItem.GiftNumber)
            {
                return BadRequest();
            }

            _context.Entry(giftItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftItemExists(id))
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

        // POST: api/GiftItems
        [HttpPost]
        public async Task<IActionResult> PostGiftItem([FromBody] GiftItem giftItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GiftItem.Add(giftItem);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiftItem", new { id = giftItem.GiftNumber }, giftItem);
        }

        // DELETE: api/GiftItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiftItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var giftItem = await _context.GiftItem.FindAsync(id);
            if (giftItem == null)
            {
                return NotFound();
            }

            _context.GiftItem.Remove(giftItem);
            await _context.SaveChangesAsync();

            return Ok(giftItem);
        }

        private bool GiftItemExists(int id)
        {
            return _context.GiftItem.Any(e => e.GiftNumber == id);
        }
    }
}