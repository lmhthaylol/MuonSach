using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.UseCase
{
    internal interface ILoanManager
    {
        Loan GetMyLoan(Guid readerId);
        Task LoanBook(Guid readerId, Guid bookId);
        Task ReturnBook(Guid loanId, Guid readerId);
    }
}
