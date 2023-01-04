using LibraryEFCore.Context;
using LibraryEFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEFCore.DML
{/// <summary>
/// Класс для добавления автора/книги
/// </summary>
    internal class Insert
    {/// <summary>
    /// Добавляет автора
    /// </summary>
    
        public static void InsertIntoAuthor()
        {
            var connectionString = @"Server=.;Database=QALibrary;Trusted_Connection=True;TrustServerCertificate=True";
            var context = new AuthorDbContext(connectionString);

            Console.WriteLine("Введите ФИО :");
            string authorName = Console.ReadLine()??"".ToLower();
            Console.WriteLine("Введите страну :");
            string authorCountry = Console.ReadLine()??"".ToLower();
            Console.WriteLine("Введите день рождение ДД.ММ.ГГ :");
            DateTime authorBirthDay = DateTime.Parse(Console.ReadLine()??"");

            var author = new Author()
            { FullName = authorName, Country = authorCountry, DateOfBirth = authorBirthDay };

            var findEntity = context.Author.Where(i => i.FullName == author.FullName).FirstOrDefault();
            if (findEntity == null)
            {
                context.Author.Add(author);
                context.SaveChanges();
                Console.WriteLine("Успешно добавлено");
            }
            else
            {
                Console.WriteLine("Автор с таким ФИО уже есть");
            }
            context.Author.Add(author);
            // context.SaveChanges();
        }
        /// <summary>
        /// Добавляет книгу
        /// </summary>
        
        public static void InsertIntoBook()
        {
            var connectionString = @"Server=.;Database=QALibrary;Trusted_Connection=True;TrustServerCertificate=True";
            var context = new AuthorDbContext(connectionString);

            Console.Write("Название книги :");
            string bookTitle = Console.ReadLine()??"".ToLower();
            Console.Write("Жанр книги: ");
            string bookGenre = Console.ReadLine()??"".ToLower();
            Console.Write("Дата публикации: ДД.ММ.ГГ  ");
            DateTime bookRelease = DateTime.Parse(Console.ReadLine()??"");
            Console.Write("Стоимость книги (просто цифру): ");
            decimal bookPrice = Int64.Parse(Console.ReadLine()??"");
            Console.Write("Количество страниц (просто цифру): ");
            int bookPage = Int32.Parse(Console.ReadLine()??"");
           
            var book = new Book()
            { TitleBook = bookTitle, Genre = bookGenre, ReleaseDate = bookRelease, Price = bookPrice, Page = bookPage };

            var findEntity = context.Book.Where(i => i.TitleBook == book.TitleBook).FirstOrDefault();
            if (findEntity == null)
            {
                context.Book.Add(book);
             //   book.Authors.Add(author);
                context.SaveChanges();
                Console.WriteLine("Книга добавлена");
            }
            else
            {
                Console.WriteLine(" Книга уже есть");
            }
            context.Book.Add(book);
        }
    }
}
