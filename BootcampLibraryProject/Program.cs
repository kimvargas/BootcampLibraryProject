using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampLibraryProject
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Strings and things I will use later... trying to clean up my code.
                string menu = "\n\nMENU\n\n(Please type a number.)" +
                    "\n\n1. View Students\n2. View Available Resources\n" +
                    "3. View Student Accounts\n4. Checkout Item\n5. Return Item" +
                    "\n6. Exit\n";
                string menu1 = "\nLIST OF STUDENT NAMES\n\n";
                string menu2 = "\nAVAILABLE RESOURCES\n\n";
                string menu3 = "\nSTUDENT ACCOUNTS\n\n";
                string menu4 = "\nITEM CHECKOUT\n\n";
                string menu5 = "\nITEM RETURN\n\n";
                string errorNum = "Please type a number.";
                string userRequest;
                string bookRequest;
                string bookReturn;


                //Arrays
                string[] studentNames = { "Quinn Bennett", "Imari Childress", "Jennifer Evans", "Richard Raponi", "Cameron Robinson", "Krista Scholdberg", "Ashley Stewart", "Cadale Thomas", "Kim Vargas", "Mary Winkelman", "Sirahn Butler" };
                //uppercase to compare
                string[] studentNamesUp = new string[studentNames.Length];
                int j = 0;
                foreach (string studentName in studentNames)
                {
                    studentNamesUp[j] = studentName.ToUpper();
                    j++;
                }

                string[] bookNames = { "book2", "book3", "b1", "b2", "b3", "Programming Interviews Exposed", "Killer Game Programming", "Head First C#", "A Smarter Way to Learn JavaScript", "Implementing Responsive Design", "C# 5.0 For Dummies", "Assembly Language Tutor", "Mastering C Pointers", "Javascritpt For Kids", "Essential C# 6.0", "ASP.NET MVC 5", "book" };
                string[] bookNamesUp = new string[bookNames.Length];
                int k = 0;
                foreach (string bookName in bookNames)
                {
                    bookNamesUp[k] = bookName.ToUpper();
                    k++;
                }
                string[] booksCheckedOut = new string[bookNamesUp.Length];
                string[] booksCheckedOutTempArray = new string[bookNamesUp.Length];
                string[] booksAvailable = new string[100];
                string[] checkOut = new string[20];
                string[] books = new string[3];
                string[] studentInfo = new string[20];
                string[] studentBooks = new string[3];

                string studentInfoString;
                string[] studentInfoArray;
                string studentInfoName;
                string[] studentInfoBooks;


                //Ints
                int menuChoice;
                int check;
                int checkAnother;
                int n;
                int p = 0;
                bool userHasBooks = false;

                int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
                int i = 0;
                Array.Sort(studentNames);
                Array.Sort(studentNamesUp);
                Array.Sort(bookNames);
                Array.Sort(bookNamesUp);




                //Application Name
                string title = "********************* BootCamp Lending Library Checkout *********************";
                while (true)
                {
                    Console.WriteLine(title);
                    Console.WriteLine(menu);
                    bool menuNAN = int.TryParse(Console.ReadLine(), out menuChoice);
                    while (!menuNAN)
                    {
                        Console.Clear();
                        Console.WriteLine(title);
                        Console.WriteLine(menu);
                        Console.WriteLine("\n" + errorNum);
                        menuNAN = int.TryParse(Console.ReadLine(), out menuChoice);
                    }

                    switch (menuChoice)
                    {
                        //STUDENT LIST
                        case 1:
                            Console.Clear();
                            Console.WriteLine(title);
                            Console.WriteLine(menu1);
                            i = 0;
                            foreach (string studentName in studentNames)
                            {
                                Console.Write(numbers[i] + ". ");
                                Console.WriteLine(studentName);
                                i++;
                            }
                            Console.WriteLine("\n\nHit any key to return to menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        //RESOURCE LIST
                        case 2:
                            Console.Clear();
                            Console.WriteLine(title);
                            Console.WriteLine(menu2);
                            for (int x = 0; x < bookNamesUp.Length; x++)
                            {
                                Array.Sort(bookNamesUp);
                                if (bookNamesUp != null && !bookNamesUp.Equals(""))
                                {
                                    Console.WriteLine(bookNamesUp[x]);
                                }
                            }
                            Console.WriteLine("\n\nHit any key to return to menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;


                        //STUDENT ACCOUNTS
                        case 3:
                            Console.Clear();
                            Console.WriteLine(title);
                            Console.WriteLine(menu3);
                            Console.WriteLine("\n\nEnter student name:" + "\n-Type \"Help\" to see list of students.");
                            userRequest = Console.ReadLine().ToUpper();
                            if (userRequest.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                            {
                                i = 0;
                                foreach (string studentName in studentNames)
                                {
                                    Console.Write(numbers[i] + ". ");
                                    Console.WriteLine(studentName);
                                    i++;
                                }
                                Console.WriteLine("\n\nEnter student name:");
                                userRequest = Console.ReadLine().ToUpper();
                            }
                            while (!studentNamesUp.Contains(userRequest.ToUpper()))
                            {
                                Console.Clear();
                                Console.WriteLine(title);
                                Console.WriteLine(menu3);
                                Console.WriteLine("\aError: Request Unavailable");
                                Console.WriteLine("\n\nEnter student name:" + "\n-Type \"Help\" to see list of students.");
                                userRequest = Console.ReadLine().ToUpper();
                                if (userRequest.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    i = 0;
                                    foreach (string studentName in studentNames)
                                    {
                                        Console.Write(numbers[i] + ". ");
                                        Console.WriteLine(studentName);
                                        i++;
                                    }
                                    Console.WriteLine("\n\nEnter student name:");
                                    userRequest = Console.ReadLine().ToUpper();
                                }
                            }
                            //STUDENT ACCOUNTS continued
                            for (n = 0; n <= checkOut.Length - 1; n++)
                            {

                                if (checkOut[n] == null || checkOut[n] == "")
                                {
                                    break;
                                }
                                else if (checkOut[n].Contains(userRequest))
                                {
                                    userHasBooks = true;
                                    studentInfoString = checkOut[n];
                                    studentInfoArray = studentInfoString.Split('&');
                                    studentInfoName = studentInfoArray[0];
                                    studentInfoBooks = studentInfoArray[1].Split('@');
                                    Console.Clear();
                                    Console.WriteLine(title);
                                    Console.WriteLine(menu3);
                                    Console.WriteLine("\n\n" + studentInfoName + " has the following books: \n");
                                    foreach (string book in studentInfoBooks)
                                    {
                                        Console.WriteLine(book);
                                    }
                                }
                            }
                            if (userHasBooks == false)
                            {
                                Console.WriteLine("\n\nStudent Account Information for: " + userRequest.ToUpper() + "\n");
                                Console.WriteLine("There are no materials checked out to this account.\n\n");
                            }


                            Console.WriteLine("\n\nHit any key to return to menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        //Checkout
                        case 4:
                            Console.Clear();
                            Console.WriteLine(title);
                            Console.WriteLine(menu4);
                            Console.WriteLine("\n\nEnter student name:" /*+ "\n--Type \"Help\" to see list of students."*/);
                            userRequest = Console.ReadLine();
                            while (!studentNamesUp.Contains(userRequest.ToUpper()))
                            {
                                Console.Clear();
                                Console.WriteLine(title);
                                Console.WriteLine(menu4);
                                Console.WriteLine("\aError: Request Unavailable");
                                Console.WriteLine("\n\nEnter student name:" /*+ "\n--Type \"Help\" to see list of students."*/);
                                userRequest = Console.ReadLine();
                            }

                            Console.Clear();
                            Console.WriteLine(title);
                            Console.WriteLine(menu4);
                            Console.WriteLine("Check Out for " + userRequest.ToUpper() + "\n\n");

                            bool checkoutAnotherBook = true;
                            while (checkoutAnotherBook)
                            {
                                bool foundUserCheckout = false;
                                bool maxReached = false;
                                for (int z = 0; z < checkOut.Length; z++)
                                {
                                    if (checkOut[z] != null && checkOut[z].Contains(userRequest.ToUpper()))
                                    {
                                        foundUserCheckout = true;
                                        string[] userInfoArray = checkOut[z].Split('&'); //split the string
                                        string[] booksArray = userInfoArray[1].Split('@'); //get the books
                                        int bookCounter = 0;
                                        for (int x = 0; x < booksArray.Length; x++)
                                        {
                                            if (booksArray != null && !booksArray[x].Equals(""))
                                            {
                                                bookCounter++;
                                            }
                                        }

                                        if (bookCounter >= 3)
                                        { //if 3 or more books are out
                                            Console.WriteLine("\aError: Request Unavailable: Max books already checked out");
                                            maxReached = true;
                                            checkoutAnotherBook = false;

                                        }
                                        else
                                        {
                                            Console.WriteLine("\n\nEnter material to check out:" /*+ "\n--Type \"Help\" to see list of resources."*/);
                                            bookRequest = Console.ReadLine();
                                            while (!bookNamesUp.Contains(bookRequest.ToUpper()))
                                            {
                                                Console.Clear();
                                                Console.WriteLine(title);
                                                Console.WriteLine(menu3);
                                                Console.WriteLine("Check Out for " + userRequest.ToUpper() + "\n\n");
                                                Console.WriteLine("\aError: Request Unavailable");
                                                Console.WriteLine("\n\nEnter material to check out:" /*+ "\n--Type \"Help\" to see list of resources."*/);
                                                bookRequest = Console.ReadLine();
                                            }
                                            //save the book
                                            checkOut[z] = checkOut[z] + bookRequest.ToUpper() + "@"; //append the book to the user's list
                                                                                                     //clear out the book from bookNamesUp
                                            for (int y = 0; y < bookNamesUp.Length; y++)
                                            {
                                                if (bookNamesUp[y].Equals(bookRequest.ToUpper()))
                                                {
                                                    bookNamesUp[y] = "";
                                                    break;
                                                }
                                            }

                                        }
                                    }
                                }

                                if (foundUserCheckout == false)
                                {
                                    Console.WriteLine("\n\nEnter material to check out:" /*+ "\n--Type \"Help\" to see list of resources."*/);
                                    bookRequest = Console.ReadLine();
                                    for (int y = 0; y < bookNamesUp.Length; y++)
                                    {
                                        if (bookNamesUp[y].Equals(bookRequest.ToUpper()))
                                        {
                                            bookNamesUp[y] = "";
                                            break;
                                        }
                                    }
                                    for (int v = 0; v < checkOut.Length; v++)
                                    {

                                        if (checkOut[v] == null || checkOut[v].Equals(""))
                                        {
                                            checkOut[v] = userRequest.ToUpper() + "&" + bookRequest.ToUpper() + "@";

                                            break;
                                        }
                                    }
                                }
                                if (checkoutAnotherBook == true && maxReached == false)
                                {
                                    Console.WriteLine("\n\nCheck out another book? \n\nY or N");
                                    if (Console.ReadLine().Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        Console.Clear();
                                        Console.WriteLine(title);
                                        Console.WriteLine(menu4);
                                        Console.WriteLine("Check Out for " + userRequest.ToUpper() + "\n\n");
                                        checkoutAnotherBook = true;
                                    }
                                    else {
                                        checkoutAnotherBook = false;
                                    }
                                }
                            }

                            Console.WriteLine("\n\nHit any key to return to menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        //RETURNS
                        case 5:
                            Console.Clear();
                            Console.WriteLine(title);
                            Console.WriteLine(menu5);

                            Console.WriteLine("\n\nEnter student name:" /*+ "\n--Type \"Help\" to see list of students."*/);
                            userRequest = Console.ReadLine();
                            while (!studentNamesUp.Contains(userRequest.ToUpper()))
                            {
                                Console.Clear();
                                Console.WriteLine(title);
                                Console.WriteLine(menu5);
                                Console.WriteLine("\aError: Request Unavailable");
                                Console.WriteLine("\n\nEnter student name:" /*+ "\n--Type \"Help\" to see list of students."*/);
                                userRequest = Console.ReadLine();
                            }

                            Console.Clear();
                            Console.WriteLine(title);
                            Console.WriteLine(menu5);
                            Console.WriteLine("Returns for " + userRequest.ToUpper() + "\n\n");


                            Console.WriteLine("\n\nEnter material to return:" /*+ "\n--Type \"Help\" to see list of resources."*/);
                            bookReturn = Console.ReadLine();
                            bool foundUserReturns = false;
                            bool returnAnotherBook = true;
                            while (returnAnotherBook)
                            {

                                for (int z = 0; z < checkOut.Length; z++)
                                {
                                    if (checkOut[z] != null && checkOut[z].Contains(userRequest.ToUpper()))
                                    {
                                        foundUserReturns = true;
                                        string[] userInfoArray = checkOut[z].Split('&'); //split the string
                                        string[] booksArray = userInfoArray[1].Split('@'); //get the books
                                        bool bookRemoved = false;
                                        string newRecord = userInfoArray[0] + "&";
                                        for (int x = 0; x < booksArray.Length; x++)
                                        {
                                            if (booksArray != null && !booksArray[x].Equals(bookReturn.ToUpper()))
                                            {
                                                newRecord = newRecord + booksArray[x] + "@";
                                            }
                                            else if (booksArray != null && booksArray[x].Equals(bookReturn.ToUpper()))
                                            {
                                                bookRemoved = true;
                                            }
                                        }
                                        checkOut[z] = newRecord;
                                        for (int y = 0; y < bookNamesUp.Length; y++)
                                        {
                                            if (bookNamesUp[y].Equals(""))
                                            {
                                                bookNamesUp[y] = bookReturn.ToUpper();
                                                break;
                                            }
                                        }
                                        Array.Sort(bookNamesUp);

                                        if (bookRemoved == false)
                                        {
                                            Console.WriteLine("\aError: Book was not checked out");
                                        }
                                    }
                                }

                                if (foundUserReturns == false)
                                {
                                    Console.WriteLine("\aError: Student has no books checked out");
                                    returnAnotherBook = false;
                                }

                                if (returnAnotherBook == true)
                                {
                                    Console.WriteLine("\n\nReturn another book? \n\nY or N");
                                    if (Console.ReadLine().Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        Console.Clear();
                                        Console.WriteLine(title);
                                        Console.WriteLine(menu5);
                                        Console.WriteLine("Returns for " + userRequest.ToUpper() + "\n\n");
                                        Console.WriteLine("\n\nEnter another material to return:" /*+ "\n--Type \"Help\" to see list of resources."*/);
                                        bookReturn = Console.ReadLine();

                                        returnAnotherBook = true;
                                    }
                                    else {
                                        returnAnotherBook = false;
                                    }

                                }
                            }
                            Console.WriteLine("\n\nHit any key to return to menu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                        default:
                            break;
                    }
                   
                    if (menuChoice.Equals(6))
                    {
                        Console.Clear();
                        Console.WriteLine(title);
                        Console.WriteLine("\n\n\n\n\nGoodbye!");
                        Console.ReadKey();
                        return;
                    }



                }
            }
        }
    }
