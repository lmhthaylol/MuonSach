using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.SqlSever.Data
{
    [Table("BookAuthor")]
    public class BookAuthorModel
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        public BookModel Book { get; set; }
        public AuthorModel Author { get; set; }


    }
}
