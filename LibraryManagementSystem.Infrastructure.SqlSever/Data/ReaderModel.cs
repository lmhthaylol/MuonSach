using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.SqlSever.Data
{
    [Table("Reader")]
    public class ReaderModel
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Password { get; set; }
        public ICollection<LoanModel> Loans { get; set; } 

    }
}
