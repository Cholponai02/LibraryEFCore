using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace LibraryEFCore.DML
{
    internal class Update
    {/// <summary>
    /// ОБновляет данные (книгу или автора)
    /// </summary>
        public static void ChangeBook()
        {
            SqlConnection sqlConnection;

            var connectionString = @"Server=.;Database=QALibrary;Trusted_Connection=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.Write("Если хотите изменить автора или книгу, тогда выберите цифру 1 для автора или 2 для книги: ");
            string input = Console.ReadLine()??"";
            if (input == "1")
            {
                try
                {
                    Console.WriteLine("Вы изменяете автора");
                    Select.ShowAllAuthors();
                    Console.WriteLine("---------------------------------------------------");
                    Console.Write("Введите id автора у которого вы хотите поменять значения: ");
                    int authorId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите новое ФИО автора ");
                    string authorName = Console.ReadLine()??"".ToLower();
                    Console.Write("Введите новую страну автора ");
                    string authorCountry = Console.ReadLine()??"".ToLower();
                    Console.Write("Введите дату рождения:  ДД.ММ.ГГ   ");
                    DateTime birthDay = DateTime.Parse(Console.ReadLine()??"");

                    string updateQuery = $"UPDATE Author SET FullName = '{authorName}', Country = '{authorCountry}', DateOfBirth = '{birthDay}' WHERE Id = {authorId}  ";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);

                    updateCommand.ExecuteNonQuery();
                    Console.WriteLine("Данные успешно изменены");
                    sqlConnection.Close();
                }
                catch
                {
                    Console.WriteLine("В базе нету автора с таким id !");
                }
            }
            else if (input == "2")
            {
                try
                {
                    Console.WriteLine("Вы изменяете книгу");
                    Select.ShowAllBooks();
                    Console.WriteLine("-----------------------------------------------");
                    Console.Write("Введите id книги у которого вы хотите поменять значения: ");
                    int bookId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите новое название книги: ");
                    string bookName = Console.ReadLine()??"".ToLower();
                    Console.Write("Введите жанр книги: ");
                    string bookGenre = Console.ReadLine()??"".ToLower();
                    Console.Write("Введите новую дату выпуска книги:  ДД.ММ.ГГ   ");
                    DateTime bookRelease = DateTime.Parse(Console.ReadLine()??"");
                    Console.Write("Введите новую цену (просто цифру): ");
                    decimal bookPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Введите количество страниц (просто цифру):");
                    int bookPage = Convert.ToInt32(Console.ReadLine());

                    string updateQuery = $"UPDATE Book SET TitleBook = '{bookName}', Genre = '{bookGenre}', ReleaseDate = '{bookRelease}', Price = '{bookPrice}', Page = '{bookPage}' WHERE Id = {bookId}  ";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);

                    updateCommand.ExecuteNonQuery();
                    Console.WriteLine("Данные успешно изменены");
                    sqlConnection.Close();
                }
                catch
                {
                    Console.WriteLine("В базе нету книги с таким id !");
                }
            }
        }
    }
}
