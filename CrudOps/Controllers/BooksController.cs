using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudOps.Models;
using CrudOps.Common;

namespace CrudOps.Controllers
{
    [RoutePrefix("api/books")]
    [RequireHttps]
    public class BooksController : ApiController
    {
        List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Name = "Book 1", Segment = Enums.SegmentType.Action, Author = "Author 1", Price = 125 },
            new Book { Id = 2, Name = "Book 2", Segment = Enums.SegmentType.Drama, Author = "Author 2", Price = 250 },
            new Book { Id = 3, Name = "Book 3", Segment = Enums.SegmentType.Fiction, Author = "Author 1", Price = 375 }
        };

        // GET api/books
        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        // GET api/books/5
        [Route("{id:int}")]
        public IHttpActionResult GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IHttpActionResult CreateBook(Book book)
        {
            books.Add(book);

            return Ok(book);
        }


        // PUT api/books
        [HttpPut]
        public IHttpActionResult UpdateBook(Book book)
        {
            var bookInDb = books.FirstOrDefault(b => b.Id == book.Id);

            if (bookInDb == null)
            {
                return NotFound();
            }

            bookInDb.Name = book.Name;
            bookInDb.Segment = book.Segment;
            bookInDb.Author = book.Author;
            bookInDb.Price = book.Price;

            return Ok(book);
        }

        // DELETE api/books/3
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = books.FirstOrDefault(b => b.Id == id);

            if (bookInDb == null)
            {
                return NotFound();
            }

            books.Remove(bookInDb);

            return Ok(true);
        }

    }
}
