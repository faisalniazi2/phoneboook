
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace phoneboook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        // GET: api/PhoneBook
        [HttpGet]
        public IEnumerable<PhoneBook> Get()
        {
            var listPhoneBooks = _db.PhoneBooks.ToList();
            return listPhoneBooks;
        }

        // GET: api/PhoneBook/5
        [HttpGet("{id}", Name = "Get")]
        public PhoneBook Get(int id)
        {
            var getPhoneBook = _db.PhoneBooks.Find(id);
            return getPhoneBook;
        }

        // POST: api/PhoneBook
        [HttpPost]
        public void Post([FromBody] PhoneBook phoneBook)
        {
            var dbModel = new PhoneBooks();
            dbModel.propert1 = phoneBook.FirstName;
            dbModel.propert2 = phoneBook.LastName;
            dbModel.propert3 = phoneBook.PhoneNumber;
            _db.PhoneBooks.add(dbModel);
            _db.saveChanges();


        }

        // PUT: api/PhoneBook/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PhoneBook phoneBook)
        {

            var dbModel = _db.PhoneBooks.Find(id);
            dbModel.propert1 = phoneBook.FirstName;
            dbModel.propert2 = phoneBook.LastName;
            dbModel.propert3 = phoneBook.PhoneNumber;
            _db.entry(dbModel).EntityState = Modified;
            _db.saveChanges();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            var dbModel = _db.PhoneBooks.Find(id);
            _db.PhoneBooks.remove(dbModel);
            _db.saveChanges();

        }
    }
}
