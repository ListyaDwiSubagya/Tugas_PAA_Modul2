using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PercobaanApi1.Models;

namespace PercobaanApi1.Controllers
{
    public class PersonController : Controller
    {
        private string __constr;

        public PersonController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("WebApiDatabase");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/person")]

        public ActionResult<Person> ListPerson() 
        {

            PersonContext context = new PersonContext(this.__constr);
            List<Person> ListPerson = context.ListPerson();
            return Ok(ListPerson);

        }

        [HttpPost("api/murid/create")]
        public IActionResult CreatePerson([FromBody] Murid person)
        {
            PersonContext context = new PersonContext(this.__constr);
            context.AddPerson(person);
            return Ok("Data berhasil ditambahkan");
        }

        [HttpPut("api/murid/update/{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Murid person)
        {
            person.id_person = id;
            PersonContext context = new PersonContext(this.__constr);
            context.UpdatePerson(person);
            return Ok("Data berhasil di update");
        }

        [HttpDelete("api/murid/delete/{id}")]
        public IActionResult DeletePerson(int id)
        {
            PersonContext context = new PersonContext(this.__constr);
            context.DeletePerson(id);
            return Ok("Data berhasil dihapus");
        }
    }

}