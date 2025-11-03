using _16_GenericTypesCollections.Models;

#region 1 ci senari
Book Book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
Book Book2 = new Book(2, "1984", "George Orwell", 1949, 328);
Book Book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
Book Book4 = new Book(4, "Ağ Gemi", "Cingiz Aytmatov", 1970, 200);
Book Book5 = new Book(5, "Qırıq Budaq", "Elçin", 1998, 350);

Console.WriteLine(Book1.DisplayInfo());
Console.WriteLine(Book2.DisplayInfo());
Console.WriteLine(Book3.DisplayInfo());
Console.WriteLine(Book4.DisplayInfo());
Console.WriteLine(Book5.DisplayInfo());
#endregion

#region 2 ci senari
Library<Book> library = new Library<Book>("Milli Kitapxana");
library.Add(new Book { Id = 1, Title = "What is Programing", Author = "Ali", Year = 2025, PageCount = 1 });
library.Add(new Book { Id = 2, Title = "What is Programing!", Author = "Ali", Year = 2025, PageCount = 2 });
library.Add(new Book { Id = 3, Title = "What is Programing!!", Author = "Ali", Year = 2025, PageCount = 3 });
library.Add(new Book { Id = 4, Title = "What is Programing!!!", Author = "Ali", Year = 2025, PageCount = 4 });
library.Add(new Book { Id = 5, Title = "What is Programing!!!!", Author = "Ali", Year = 2025, PageCount = 5 });

Console.WriteLine(library.Count());
Book firstBook = library.FindByIndex(0);

if (firstBook != null)
{
    Console.WriteLine("İndeks 0-dakı kitab:");
    Console.WriteLine(firstBook.DisplayInfo());
}
else
{
    Console.WriteLine("İndeks 0-dakı kitab tapılmadı!");
}
Book firstBook1 = library.FindByIndex(2);

if (firstBook != null)
{
    Console.WriteLine("İndeks 0-dakı kitab:");
    Console.WriteLine(firstBook.DisplayInfo());
}
else
{
    Console.WriteLine("İndeks 0-dakı kitab tapılmadı!");
}
Console.WriteLine("Bütün kitablar:");
foreach (var book in library.GetAll())
{
    Console.WriteLine(book.DisplayInfo());
}
#endregion

#region 3 cu senari
List<Member> members = new List<Member>();


members.Add(new Member(1, "Ali Məmmədov", "ali@mail.com"));
members.Add(new Member(2, "Leyla Həsənova", "leyla@mail.com"));
members.Add(new Member(3, "Vüqar Əliyev", "vuqar@mail.com"));


Member ali = members[0];
ali.BorrowBook(Book1);
ali.BorrowBook(Book2);


Console.WriteLine("\nAli-nin borc kitabları:");
ali.DisplayBorrowedBooks();


ali.ReturnBook(1);


Console.WriteLine("\nAli-nin borc kitabları (1 kitab qaytarıldıqdan sonra):");
ali.DisplayBorrowedBooks();


ali.BorrowBook(Book3);
ali.BorrowBook(Book4);
ali.BorrowBook(Book5);
#endregion

#region 4 cu senari
BookManager manager = new BookManager();

manager.AddBook(Book1);
manager.AddBook(Book2);
manager.AddBook(Book3);
manager.AddBook(Book4);
manager.AddBook(Book5);

// 3️⃣ Müəllifə görə axtarış - Dictionary
Console.WriteLine("\nGeorge Orwell-in kitabları:");
foreach (var b in manager.GetBooksByAuthor("George Orwell"))
{
    Console.WriteLine(b.DisplayInfo());
}

Console.WriteLine("\nCingiz Aytmatov-un kitabları:");
foreach (var b in manager.GetBooksByAuthor("Cingiz Aytmatov"))
{
    Console.WriteLine(b.DisplayInfo());
}

Console.WriteLine("\nJack London-un kitabları:");
foreach (var b in manager.GetBooksByAuthor("Jack London"))
{
    Console.WriteLine(b.DisplayInfo());
}

Console.WriteLine("\nDostoyevski-nin kitabları:");
var dostBooks = manager.GetBooksByAuthor("Dostoyevski");
if (dostBooks.Count == 0)
    Console.WriteLine("0 kitab");
#endregion


#region 5 ci senari
manager.AddToWaitingQueue("Nigar");
manager.AddToWaitingQueue("Reşad");
manager.AddToWaitingQueue("Sebine");

Console.WriteLine($"\nNövbede {manager.WaitingQueue.Count} nefer var");

string next = manager.ServeNextInQueue();
Console.WriteLine($"Xidmet edilir: {next}");
Console.WriteLine($"Növbede {manager.WaitingQueue.Count} nefer qaldı");

next = manager.ServeNextInQueue();
Console.WriteLine($"Xidmət edilir: {next}");
Console.WriteLine($"Növbede {manager.WaitingQueue.Count} nefer qaldı");

next = manager.ServeNextInQueue();
Console.WriteLine($"Xidmet edilir: {next}");
Console.WriteLine($"Növbede {manager.WaitingQueue.Count} nefer qaldı");
#endregion


#region 6 ci senari

manager.ReturnBook(Book1);
manager.ReturnBook(Book2);
manager.ReturnBook(Book3);

Console.WriteLine($"\nStack-də {manager.RecentlyReturned.Count} kitab var");
Console.WriteLine("Son qaytarılan kitab: " + manager.GetLastReturnedBook().DisplayInfo());


Book popped = manager.RecentlyReturned.Pop();
Console.WriteLine($"Stack-dan çıxarılan kitab: {popped.DisplayInfo()}");

Console.WriteLine($"İndi Stack-da {manager.RecentlyReturned.Count} kitab var");
Console.WriteLine("Yeniden son kitab: " + manager.GetLastReturnedBook().DisplayInfo());
#endregion

#region 7 ci senari

Console.WriteLine("\nAxtarış testi:");


Book foundBook = manager.SearchByTitle("1984");

if (foundBook != null)
{
    Console.WriteLine("Tapılan kitab:");
    Console.WriteLine(foundBook.DisplayInfo());
}
else
{
    Console.WriteLine("Kitab tapılmadı.");
}

Book notFound = manager.SearchByTitle("Harry Potter");

if (notFound != null)
{
    Console.WriteLine("Tapılan kitab:");
    Console.WriteLine(notFound.DisplayInfo());
}
else
{
    Console.WriteLine("Bu adda kitab yoxdur!");
}
#endregion

#region 8 ci senari
Console.WriteLine("\n📚 Kitabxana statistikası:");


Console.WriteLine($"Ümumi kitab sayı: {manager.Books.Count}");


Console.WriteLine($"Ümumi üzv sayı: {members.Count}");


Console.WriteLine($"Növbede nefer sayı: {manager.WaitingQueue.Count}");


Console.WriteLine($"Son qaytarılan kitabların sayı (Stack): {manager.RecentlyReturned.Count}");


if (manager.Books.Count > 0)
{
    int minYear = manager.Books[0].Year;
    int maxYear = manager.Books[0].Year;

    foreach (Book book in manager.Books)
    {
        if (book.Year < minYear)
            minYear = book.Year;

        if (book.Year > maxYear)
            maxYear = book.Year;
    }

    Console.WriteLine($"En köhne kitabın ili: {minYear}");
    Console.WriteLine($"En yeni kitabın ili: {maxYear}");
}
else
{
    Console.WriteLine("Kitab siyahısı boşdur!");
} 
#endregion
