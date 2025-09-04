using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Address { get; set; }
    }
}
