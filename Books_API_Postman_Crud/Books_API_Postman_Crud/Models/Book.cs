using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_API_Postman_Crud.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public int Pages { get; set; }
    }
}
