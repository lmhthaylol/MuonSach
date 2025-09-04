using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.SqlSever.Data
{
    [Table("Publisher")]
    public class PublisherModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Address { get; set; }
        public ICollection<BookModel> Books { get; set; } 

    }
}
