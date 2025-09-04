using AutoMapper;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Infrastructure.SqlSever.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.SqlSever.MapperProfile
{
    public class SqlServer2EntityProfile : Profile
    {
        public SqlServer2EntityProfile()
        {
            CreateMap<Book, BookModel>();
            CreateMap<BookModel, Book>();
        }
    }
    
}
