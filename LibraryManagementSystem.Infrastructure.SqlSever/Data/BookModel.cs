using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.SqlSever.Data
{

    [Table("Book")]
    public class BookModel
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int PublicationYear { get; set; }
        public PublisherModel Publisher { get; set; }
        public ICollection<LoanModel> Loans { get; set; }
        public ICollection<BookAuthorModel> BookAuthors { get; set; }
        public Guid PublisherId { get; internal set; }
    }
}
