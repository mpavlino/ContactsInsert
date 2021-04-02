using ContactsWebApp.Data;
using ContactsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactApiController : ControllerBase
    {
        private ContactDbContext _dbContext;

        public ContactApiController(ContactDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<ContactApiController>
        //Dohvati sve kontakte iz baze i kreiraj listu
        [HttpGet]
        public IActionResult GetContacts()
        {
            var contacts = _dbContext.Contact.Select(x => new Contact()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                MobilePhone = x.MobilePhone,
                Address = x.Address

            }).ToList();
            return Ok(contacts);
        }

        // GET api/<ContactApiController>/5
        [HttpGet("{id}")]
        public string AddContact(int id)
        {
            return "value";
        }

        // POST api/<ContactApiController>
        //Spremi novi kontakt u bazu uz uvjet da je validacija svih polja uspješna
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(new Contact()
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    MobilePhone = contact.MobilePhone,
                    Address = contact.Address
                });
                _dbContext.SaveChanges();
            }

            return Ok();
        }

        // PUT api/<ContactApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
