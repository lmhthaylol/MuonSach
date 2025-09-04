using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.UseCase
{
    internal interface IAdminService
    {
        IEnumerable<Author> GetAllAuthors();

        IEnumerable<Publisher> GetAllPublishers();

        IEnumerable<Reader> GetAllReaders();

        IEnumerable<Loan> GetAllLoans();
    }
}
