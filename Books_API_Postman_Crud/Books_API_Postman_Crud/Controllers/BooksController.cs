using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books_API_Postman_Crud.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books_API_Postman_Crud.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book() { Id = Guid.NewGuid(), Title="Povestea lui Harap-Alb",Author="Ion Creangă", ReleaseDate=new DateTime(1877,8,1),Description="Povestea lui Harap-Alb este un basm cult scris de Ion Creangă.",Pages=54}
        };

        [HttpGet]
        public Book[] GetAll()
        {
            return Books.ToArray();
        }

        [HttpGet("{id}")]
        public Book GetBook(Guid Id)
        {
            return Books.FirstOrDefault(b => b.Id == Id);
        }

        [HttpPut]
        public void UpdateBook([FromBody] Book book)
        {
            Book bookToUpdate = Books.FirstOrDefault(b => b.Id == book.Id);

            bookToUpdate.Id = Guid.NewGuid();
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.ReleaseDate = book.ReleaseDate;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Pages = book.Pages;
        }

        [HttpPost]
        public void PostBook([FromBody] Book book)
        {
            book.Id = Guid.NewGuid();

            Books.Add(book);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(Guid Id)
        {
            Books.Remove(Books.FirstOrDefault(b => b.Id == Id));
        }
    }
}
