using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        public static List<Book> BooksList = new List<Book>()
        {
            new Book() { Id = 1, Title="Povestea lui Harap-Alb",Author="Ion Creangă", ReleaseDate="1877-8-1",Description="Povestea lui Harap-Alb este un basm cult scris de Ion Creangă.",Pages=54},
            new Book() { Id = 2, Title="Povestea lui Harap-Alb",Author="Ion Creangă", ReleaseDate="1877-8-1",Description="Povestea lui Harap-Alb este un basm cult scris de Ion Creangă.",Pages=54},
            new Book() { Id = 3, Title="Povestea lui Harap-Alb",Author="Ion Creangă", ReleaseDate="1877-8-1",Description="Povestea lui Harap-Alb este un basm cult scris de Ion Creangă.",Pages=54}
        };

        [HttpGet("[action]")]
        public IEnumerable<Book> Books()
        {
            return BooksList;
        }
    }
}