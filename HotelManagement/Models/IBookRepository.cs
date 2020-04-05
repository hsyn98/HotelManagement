using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public interface IBookRepository
    {
        Book Add(Book book);
        Book Update(Book book);
        Book Delete(int id);
        Book GetBook(int id);
        List<Book> Search(string search);
        IEnumerable<Book> GetAllBooks();
    }
}
