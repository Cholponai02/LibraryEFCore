using LibraryEFCore.Context;
using LibraryEFCore.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEFCore.DML
{/// <summary>
/// Извлекает данные
/// </summary>
    internal class Select
    {/// <summary>
    /// Показывает все книги
    /// </summary>
        public static void ShowAllBooks()
        {
            var connectionString = @"Server=.;Database=QALibrary;Trusted_Connection=True;TrustServerCertificate=True";

            string sqlExpression = "SELECT * FROM Book";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("{0} \t{1}    \t{2}    \t{3}  \t\t{4}    \t{5} ", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4),  reader.GetName(5) );
                    Console.ForegroundColor = ConsoleColor.White;

                    while (reader.Read()) 
                    {
                        object id = reader.GetValue(0);
                        object title = reader.GetValue(1);
                        object genre = reader.GetValue(2);
                        object releaseDate = reader.GetValue(3);
                        object page = reader.GetValue(4);
                        object price = reader.GetValue(5);
                        Console.WriteLine("{0}   \t{1}    \t{2}    \t{3}   \t{4}    \t{5} ", id, title, genre, releaseDate, page, price);
                    }
                }
                reader.Close();
            }
        }
        /// <summary>
        /// Показывает всех авторов
        /// </summary>
        public static void ShowAllAuthors()
        {
            var connectionString = @"Server=.;Database=QALibrary;Trusted_Connection=True;TrustServerCertificate=True";

            string sqlExpression = "SELECT * FROM Author";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("{0}   \t{1}    \t{2}       \t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                    Console.ForegroundColor = ConsoleColor.Green;

                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        Console.ForegroundColor = ConsoleColor.White;

                        object country = reader.GetValue(2);
                        object birthDay = reader.GetValue(3);

                        Console.WriteLine("{0}   \t{1}      \t{2}       \t{3}", id, name, country, birthDay);
                    }
                }

                reader.Close();
            }
        }
        /// <summary>
        /// Поиск книг по названию
        /// </summary>
        public static void SearchTitleBook()
        {
            ShowAllBooks();
            Console.WriteLine("----------------------------------------------------\nВведите название книги: ");
            string inputTitle = Console.ReadLine()??"".ToLower();
            var connectionString = @"Server=.;Database=QALibrary;Trusted_Connection=True;TrustServerCertificate=True";
            var context = new AuthorDbContext(connectionString);
            var books = context.Book.Where(p => EF.Functions.Like(p.TitleBook, inputTitle.ToLower()));
            foreach (Book book in books)
            {
                Console.WriteLine($"Вы выбрали книги под номером: {book.Id}\nО книге");
                Console.WriteLine($"\t Жанр: {book.Genre}, {book.Page}страниц, Релиз: {book.ReleaseDate}, Цена: {book.Price}сом");
            }
        }
        
    }
}
