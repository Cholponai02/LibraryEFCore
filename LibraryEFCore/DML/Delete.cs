using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace LibraryEFCore.DML
{/// <summary>
/// Класс для удаления книги || автора
/// </summary>
    internal class Delete
    {/// <summary>
    /// Удаляет автора
    /// </summary>
        public static void DelAuthor()
        {
            SqlConnection sqlConnection = null;
            var connectionString = @"Server=.;Database=QALibrary;Trusted_Connection=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Select.ShowAllAuthors();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("Выберите Id автора для удаления: ");
            int deleteId = int.Parse(Console.ReadLine());
            string deleteQuery = "DELETE FROM Author WHERE Id =" + deleteId;

            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Автор успешно удалён");
            sqlConnection.Close();

        }
        /// <summary>
        /// Удаляет книгу
        /// </summary>
        public static void DelBook()
        {
            SqlConnection sqlConnection = null;
            var connectionString = @"Server=.;Database=QALibrary;Trusted_Connection=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Select.ShowAllBooks();
            Console.WriteLine("--------------------------------------------------------");
            Console.Write("Выберите Id книги для удаления: ");
            int deleteId = int.Parse(Console.ReadLine());
            string deleteQuery = "DELETE FROM Book WHERE Id =" + deleteId;

            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Книга успешна удалена");
            sqlConnection.Close();

        }
    }
}
