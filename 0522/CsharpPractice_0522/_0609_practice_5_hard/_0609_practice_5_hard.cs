using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _0609_practice_5_hard
{
    static class NewStaticClass
    {
        public static bool IsSameAuthor(this Book book, string s)
        {
            return book.IsSameAuthor(s);
        }
    }
    class Book
    {
        public string bookName;
        public string author;
        public int pageCount;

        public Book(string bookName, string author)
        {
            this.bookName = bookName;
            this.author = author;
            Library.availableBooks.Add(this);
        }

        public bool IsSameAuthor(string s)
        {
            try
            {
                if(this == null)
                {
                    throw new BookDoenstExistException();
                    
                }
                else
                {
                    if(this.author == s || this.bookName == s)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                MyExceptions.exceptions.Add(new BookDoenstExistException());
                return false;
            }
        }
    }

    class User
    {
        public string userName;
        public List<Book> borrowedBooks;

        public User(string username)
        {
            this.userName = username;
            borrowedBooks = new List<Book>();
        }
        public void BorrowBook(params Book[] books)
        {
            foreach(Book book in books)
            {
                if(Library.LoanBook(book) != null)
                {
                    borrowedBooks.Add(book);
                }
                

            }
        }

        public void ReturnBook(Book book)
        {
            Library.ReturnBook(book);
            borrowedBooks.Remove(book);
        }

        public void SearchBook(string bookName, bool searchWithAuthor = false)
        {
            Library.SearchBookInLibrary(bookName, searchWithAuthor);
        }

        public void PrintAllBookInMain(List<Book> list)
        {
            int count = 1;
            Console.WriteLine("==============책 목록=======");
            foreach (Book book in list)
            {
                Console.WriteLine($"[{count}].{book.bookName}");
                count++;
            }
            Console.WriteLine("============================");
        }
    }

    static class MyExceptions
    {
        public static List<Exception> exceptions = new List<Exception>();
        
        public static void PrintAllExceptions()
        {
            int count = 1;
            Console.WriteLine("========모아둔 예외들 모두 출력=======");
            foreach(Exception ex in exceptions)
            {
                Console.WriteLine(ex.Message);
                count++;
            }
        }

    }
    class AlreadyBorrowedException : Exception
    {
        public override string Message
        {
            get
            {
                return "그거 이미 빌려 가셨는데??";
            }
        }
    }

    class InvalidReturnException : Exception
    {
        public override string Message
        {
            get
            {
                return "그런거 빌려준적 없는데??";
            }
        }
    }

    class NoResultsException : Exception
    {
        public override string Message
        {
            get
            {
                return "그런책 찾아보니까 없는데??";
            }
        }
    }

    class BookDoenstExistException : Exception
    {
        public override string Message
        {
            get
            {
                return "비교, 참조하려는 책이 없는데??";
            }
        }
    }

    class SelectedOutOfChoiceException : Exception
    {
        public override string Message
        {
            get
            {
                return "그건 메뉴에 없는데??";
            }
        }
    }




    static class Library
    {
        public static List<Book> availableBooks = new List<Book>();
        public static List<Book> loanedBooks = new List<Book>();

        public static void ReturnBook(Book book)
        {
            /*
            try
            {
                loanedBooks.Remove(book);
                availableBooks.Add(book);

            }
            catch
            {
                MyExceptions.exceptions.Add(new Exception($"[{book.bookName}]....그런 책은 빌려준적 없는데??"));
            }
            
            */
            try
            {
                if (loanedBooks.Contains(book))
                {
                    loanedBooks.Remove(book);
                    availableBooks.Add(book);
                    
                }
                else
                {
                    throw new InvalidReturnException();
                    //MyExceptions.exceptions.Add(new Exception($"[{book.bookName}]....그런 책은 빌려준적 없는데??"));
                }
            }
            catch
            {
                //MyExceptions.exceptions.Add(new Exception($"[{book.bookName}]....그런 책은 빌려준적 없는데??"));
                MyExceptions.exceptions.Add(new InvalidReturnException());
            }
        }

        public static Book LoanBook(Book book)
        {
            int index = availableBooks.FindIndex(n => n.bookName == book.bookName);
            try
            {
                if (index != -1)
                {

                    Book toLoanBook = availableBooks[index];
                    loanedBooks.Add(toLoanBook);
                    availableBooks.RemoveAt(index);
                    Console.WriteLine($"이거 빌림 : {book.bookName}");
                    return toLoanBook;
                }
                else
                {
                    throw new AlreadyBorrowedException();
                    //MyExceptions.exceptions.Add(new Exception($"[{book.bookName}]....그런 책은 없어서 못빌려요"));
                }
            }
            catch
            {
                MyExceptions.exceptions.Add(new AlreadyBorrowedException());
                return null;
            }
            
        }

        public static Book SearchBookInLibrary(string bookName, bool searchWithAuthor = false)
        {
            if(searchWithAuthor == true)
            {
                try
                {
                    if (availableBooks.FindIndex(n => n.bookName == bookName) != -1 && availableBooks.FindIndex(n => n.author == bookName) == -1)
                    {
                        Book found = availableBooks.Find(n => n.bookName == bookName);
                        return found;
                    }
                    else if (availableBooks.FindIndex(n => n.bookName == bookName) == -1 && availableBooks.FindIndex(n => n.author == bookName) != -1)
                    {
                        Book found = availableBooks.Find(n => n.author == bookName);
                        return found;
                    }
                    else
                    {
                        //MyExceptions.exceptions.Add(new Exception($"[{bookName}]....그런 책은 검색해보니 없네요"));
                        throw new NoResultsException();
                        //return null;
                    }
                }
                catch
                {
                    MyExceptions.exceptions.Add (new NoResultsException());
                    return null;
                }
                
            }
            else
            {
                try
                {


                    if (availableBooks.FindIndex(n => n.bookName == bookName) != -1)
                    {
                        Book found = availableBooks.Find(n => n.bookName == bookName);
                        return found;
                    }
                    //MyExceptions.exceptions.Add(new Exception($"[{bookName}]....그런 책은 검색해보니 없네요"));
                    //return null;
                    throw new NoResultsException();
                    
                }
                catch
                {
                    MyExceptions.exceptions.Add(new NoResultsException());
                    return null; 
                }
            }

        }
        public static void PrintAllAvailableBooks()
        {
            int count = 1;
            Console.WriteLine("======빌릴 수 있는 책 목록=======");
            foreach (Book book in GetAllAvailableBooks())
            {
                Console.WriteLine($"[{count}]. {book.bookName}");
                count++;
            }
            Console.WriteLine("===============================");
        }

        public static IEnumerable<Book> GetAllAvailableBooks()
        {
            foreach (Book book in availableBooks)
            {
                yield return book;
            }
        }

        
    }
    internal class _0609_practice_5_hard
    {
        static void Main(string[] args)
        {
            
            User u = new User("성준");
            Book b1 = new Book("Clean Code", "Robert Martin");
            Book b2 = new Book("The Pragmatic Programmer", "Andy Hunt");
            Book b3 = new Book("Clean Architecture", "Robert Martin");
            List<Book> createdBooks = new List<Book>();
            createdBooks.Add(b1);
            createdBooks.Add(b2);
            createdBooks.Add(b3);
            int currentBookCount = 3;
            bool end = false;
            Console.WriteLine($"{u.userName}님 안녕하세요");

            while (end == false)
            {
                try
                {
                    Console.WriteLine("무엇을 할건가요?");
                    Console.WriteLine("1.[책 추가] 2.[책 대여] 3.[책 반납] 4.[대여 가능한 책 출력] 5.[책 저자 비교] 6.[종료]");
                    int menuChoice = int.Parse(Console.ReadLine());
                    if (menuChoice < 1 || menuChoice > 6)
                    {
                        MyExceptions.exceptions.Add(new SelectedOutOfChoiceException());
                        throw new SelectedOutOfChoiceException();
                    }
                    switch (menuChoice)
                    {
                        case 1:
                            Console.Write("책 이름 입력 : ");
                            string bookName = Console.ReadLine();
                            Console.Write("책 저자 입력 : ");
                            string author = Console.ReadLine();
                            createdBooks.Add(new Book(bookName, author));
                            Console.WriteLine("책 추가 완료");
                            currentBookCount++;
                            break;
                        case 2:
                            Console.WriteLine("어떤 책을 빌릴까요?");
                            Library.PrintAllAvailableBooks();
                            int bookChoice = (int.TryParse(Console.ReadLine(), out int result )) ? result : -1;
                            if(bookChoice == -1 || bookChoice>Library.availableBooks.Count + 1)
                            {
                                MyExceptions.exceptions.Add(new SelectedOutOfChoiceException());
                                throw new SelectedOutOfChoiceException();
                            }
                            else
                            {
                                u.BorrowBook(Library.availableBooks[bookChoice-1]);
                            }
                            break;
                        case 3:
                            Console.WriteLine("어떤 책을 반납할까요?");
                            u.PrintAllBookInMain(createdBooks);
                            int bookChoice2 = (int.TryParse(Console.ReadLine(), out int result2)) ? result2 : -1;
                            if (bookChoice2 == -1 || bookChoice2 > createdBooks.Count + 1)
                            {
                                MyExceptions.exceptions.Add(new SelectedOutOfChoiceException());
                                throw new SelectedOutOfChoiceException();
                            }
                            else
                            {
                                u.ReturnBook(createdBooks[bookChoice2 - 1]);
                            }
                            break;
                        case 4:
                            Library.PrintAllAvailableBooks();
                            break;
                        case 5:
                            Console.WriteLine("비교할 책을 고르세요");
                            u.PrintAllBookInMain(createdBooks);
                            int bookChoice3 = (int.TryParse(Console.ReadLine(), out int result3)) ? result3 : -1;
                            Book selectedToCompare;
                            if (bookChoice3 == -1 || bookChoice3 > createdBooks.Count + 1)
                            {
                                MyExceptions.exceptions.Add(new SelectedOutOfChoiceException());
                                throw new SelectedOutOfChoiceException();
                            }
                            else
                            {
                                selectedToCompare = createdBooks[bookChoice3 - 1];
                            }
                            Console.WriteLine("비교하고싶은 제목이나 저자를 입력하세요");
                            string stringToCompare = Console.ReadLine();
                            if(selectedToCompare.IsSameAuthor(stringToCompare)== true)
                            {
                                Console.WriteLine("제목이나 저자가 같습니다.");
                            }
                            else
                            {
                                Console.WriteLine("다릅니다");
                            }
                            break;
                        case 6:
                            end = true;
                            break;


                    }
                }
                catch
                {
                   // MyExceptions.exceptions.Add(new SelectedOutOfChoiceException());
                    continue;
                }
                finally
                {
                    /*
                    foreach(Exception ex in MyExceptions.exceptions)
                    {
                        Console.WriteLine(ex.Message);
                    }*/
                    if (end)
                    {
                        MyExceptions.PrintAllExceptions();
                    }
                }

                
            }/*
            foreach (Book b in Library.availableBooks)
            {
                Console.WriteLine(b.bookName);
            }
            try
            {
                Console.WriteLine(Library.SearchBookInLibrary("Clean Code").author);
            }
            catch
            {

            }
            Console.WriteLine();

            u.BorrowBook(b1, b2);
            foreach (Book b in Library.availableBooks)
            {
                Console.WriteLine(b.bookName);
            }
            Console.WriteLine();
            u.ReturnBook(b1);
            foreach (Book b in Library.availableBooks)
            {
                Console.WriteLine(b.bookName);
            }
            u.ReturnBook(b1);

            u.BorrowBook(b2);





            foreach(Exception ex in MyExceptions.exceptions)
            {
                Console.WriteLine(ex.Message);
            }*/
        }
    }
}
