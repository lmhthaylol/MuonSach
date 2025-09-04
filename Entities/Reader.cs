using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Reader
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName {  get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Password { get; set; }

    }
}
