using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GenericTypesCollections.Models
{
    internal class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; }
        public Member(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            BorrowedBooks = new List<Book>();
        }
        public Member()
        {
            
        }
        public void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count >= 3)
            {
                Console.WriteLine("Maksimum 3 kitab götüre bilersiniz!");
            }
            else
            {
                BorrowedBooks.Add(book);
                Console.WriteLine($"Kitap goturuldu : {book.Title}");
            }

        }
        public void ReturnBook(int bookId)
        {
            foreach (Book book in BorrowedBooks)
            {
                if (book.Id == bookId)
                {
                    BorrowedBooks.Remove(book);
                    Console.WriteLine($"kitap qaytarildi :{book.Title}");
                    return;
                }
            }
            Console.WriteLine("Bu Id-de kitap tapilmadi");
        }
        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Borc kitab yoxdur");
            }
            foreach (Book book in BorrowedBooks)
            {
                Console.WriteLine(book.DisplayInfo());
            }
        }

    }
}
