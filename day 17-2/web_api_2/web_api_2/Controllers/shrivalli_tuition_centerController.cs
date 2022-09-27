using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_2.Models;

namespace Web_API_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class shrivalli_tuition_centerController : ControllerBase
    {
        private readonly shrivalli_tuition_centerContext db;
        public shrivalli_tuition_centerController(shrivalli_tuition_centerContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> getStudents()
        {
            return Ok(await db.Students.ToListAsync());
        }

        [HttpGet]
        [Route("GetStudById(id)")]

        public async Task<ActionResult<Student>> getStudentById(int id)
        {
            Student S = await db.Students.FindAsync(id);
            return Ok(S);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] Student S)
        {
            if (S == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                db.Students.Add(S);
                await db.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPut]

        public async Task<ActionResult> EditStudent(int id,[FromBody] Student S)
        {
            db.Students.Update(S);
            await db.SaveChangesAsync();
            return Ok(S);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteStudent(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }
            else
            { 
                Student S=await db.Students.FindAsync(id);
                db.Students.Remove(S);
                db.SaveChanges();
                return Ok(S);
            }
            
        }
    }
}
