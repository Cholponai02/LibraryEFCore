using Microsoft.Data.SqlClient;
using LibraryEFCore;
using LibraryEFCore.DML;
using LibraryEFCore.Context;
using LibraryEFCore.Entities;

class Program
{
    static void Main(string[] args)
    {

        Console.Title = "Книжное хранилище";
        string inputChoice = "0";
        Console.WriteLine("Добро пожаловать в консольное хранилище книг\n Выберите один пункт :  \n Например, Напечатайте цифру 3 и нажмите Enter");
        MenuApp();
        for (int cikl = 0; ; cikl++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" > ");
            inputChoice = Console.ReadLine() ?? "";
            inputChoice = inputChoice.ToLower().Replace(" ", "").Replace("\t", "");

            if (inputChoice == "1")
            {
                Console.Clear();
                Console.WriteLine("Добавить книгу");
                Console.ForegroundColor = ConsoleColor.White;
                Insert.InsertIntoBook();
                MenuApp();
            }
            if (inputChoice == "2")
            {
                Console.Clear();
                Console.WriteLine(" Удалить книгу. ");
                Console.ForegroundColor = ConsoleColor.White;
                Delete.DelBook();
                MenuApp();
            }
            if (inputChoice == "3")
            {
                Console.Clear();
                Console.WriteLine("Добавить автора");
                Console.ForegroundColor = ConsoleColor.White;
                Insert.InsertIntoAuthor();
                MenuApp();
            }
            if (inputChoice == "4")
            {
                Console.Clear();
                Console.WriteLine("Удалить автора");
                Console.ForegroundColor = ConsoleColor.White;
                Delete.DelAuthor();
                MenuApp();
            }
            if (inputChoice == "5")
            {
                Console.Clear();
                Console.WriteLine("Посмотреть все книги.");
                Console.ForegroundColor = ConsoleColor.White;
                Select.ShowAllBooks();
                MenuApp();
            }
            if (inputChoice == "6")
            {
                Console.Clear();
                Console.WriteLine(" Поиск книг по названию.");
                Console.ForegroundColor = ConsoleColor.White;
                Select.SearchTitleBook();
                MenuApp();
            }
            if (inputChoice == "7")
            {
                Console.Clear();
                Console.WriteLine("Посмотреть всех авторов.");
                Console.ForegroundColor = ConsoleColor.White;
                Select.ShowAllAuthors();
                MenuApp();
            }
            if (inputChoice == "8")
            {
                Console.Clear();
                Console.WriteLine("Изменить существующего автора / книгу");
                Console.ForegroundColor = ConsoleColor.White;
                Update.ChangeBook();
                MenuApp();
            }
            if (inputChoice == "9")
            {
                Console.Clear();
                Quit.ExitFromApp();
            }
        }
        static void MenuApp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"***********************************************
     Меню :                                   *
  1. Добавить книгу.                          *
  2. Удалить книгу.                           *
  3. Добавить автора.                         *
  4. Удалить автора.                          *
  5. Посмотреть все книги.                    *
  6. Поиск книг по названию.                  *
  7. Посмотреть всех авторов.                 *
  8. Изменить существующего автора / книгу    *   
  9. Выйти                                    *
***********************************************
");
        }

     
    }
}