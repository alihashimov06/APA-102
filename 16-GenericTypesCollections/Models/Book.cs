using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace _16_GenericTypesCollections.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }
        public Book(int id, string title, string author, int year, int pageCount)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
            PageCount = pageCount;
        }
        public Book() { }
        public string DisplayInfo()
        {
            return $"[{Id}] {Title} - {Author} ({Year}) - {PageCount} sehife";
        }


    }
}
