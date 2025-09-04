using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.SqlSever.Data
{
    [Table("Author")]
    public class AuthorModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Biography { get; set; }
        public ICollection<BookAuthorModel> BookAuthors { get; set; } 

    }
}
