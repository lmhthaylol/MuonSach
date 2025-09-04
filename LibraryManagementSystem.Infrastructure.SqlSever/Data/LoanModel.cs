using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.SqlSever.Data
{
    [Table("Loan")]
    public class LoanModel
    {
        public Guid Id { get; set; }
        public required Guid BookId { get; set; }
        public required Guid ReaderId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BookModel Book { get; set; }
        public ReaderModel Reader { get; set; }
    }
}
