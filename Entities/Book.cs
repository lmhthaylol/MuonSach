using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Book
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int PublicationYear { get; set; }
        public Guid PublisherId { get; set; }

    }
}
