using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MeetUp.DataContext.Models;
using MeetUp.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetUp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ValuesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status302Found, Type = typeof(IEnumerable<JsonResult>))]
        public async Task<IActionResult> GetValues()
        {
            var dataList = await _context.Values.ToListAsync();
            return Ok(dataList);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(long id)
        {
            var value =await _context.Values.FirstOrDefaultAsync(c => c.Id == id);
            return Ok(value);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}