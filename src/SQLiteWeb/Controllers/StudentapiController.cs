using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLiteWeb.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SQLiteWeb.Controllers
{
    [Route("api/[controller]")]
    public class StudentapiController : Controller
    {
        private SchoolContext _context { get; set; }
        public StudentapiController(SchoolContext context)
        {
            _context = context;
        }
        // GET: api/student
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Students.ToList();
        }
        // GET api/studentapi/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }
        // POST api/studentapi
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        // PUT api/studentapi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        // DELETE api/studentapi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(t => t.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
