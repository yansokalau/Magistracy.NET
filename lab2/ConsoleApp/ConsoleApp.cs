using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class ConsoleApp
    {

        private static IStorable<StudentData> storage;

        private static int minMark = 0;
        private static int maxMark = 10;

        private static string testName = "ALL";

        private static int limit = 100;

        private static bool sortByDate;
        private static bool ascending = true;

        public static void Main(string[] args)
        {
            storage = new StudentsBinaryTreeStorage();

            MainScreen();
        }    

        private static void MainScreen()
        {
            var tempList = GetFilteredList();
            
            Console.Clear();
            Console.WriteLine("Students:\n");
            foreach (var item in tempList)
            {
                Console.WriteLine(item.ToString()+"\n");
            }
            Console.WriteLine("=================================================");
            Console.WriteLine($"\nFilter: marks range({minMark}-{maxMark}), test name: {testName.ToUpper()}, limit: {limit}");
            if (sortByDate)
            {
                Console.WriteLine($"Sort by: Test Date, ascending: {ascending}");
            }

            Console.WriteLine("\nCommands:");
            Console.WriteLine("\nC - to create student");
            Console.WriteLine("\nM - to set min mark");
            Console.WriteLine("N - to set max mark");
            Console.WriteLine("T - to set test name");
            Console.WriteLine("L - to set limit");
            Console.WriteLine("\nS - to sort by date");
            Console.WriteLine("\nR - to reset filters");

            ShowCommands();
        }

        private static void ShowCommands()
        {
            var result = Console.ReadLine();
            switch (result.ToLower())
            {
                case "c":
                    ShowCreateStudent();
                    MainScreen();
                    break;
                case "m":
                    Console.WriteLine("Min mark:");
                    minMark = int.Parse(Console.ReadLine());
                    MainScreen();
                    break;
                case "n":
                    Console.WriteLine("Max mark:");
                    maxMark = int.Parse(Console.ReadLine());
                    MainScreen();
                    break;
                case "t":
                    Console.WriteLine("Test Name:");
                    testName = Console.ReadLine();
                    MainScreen();
                    break;
                case "l":
                    Console.WriteLine("Limit:");
                    limit = int.Parse(Console.ReadLine());
                    MainScreen();
                    break;
                case "s":
                    if (sortByDate) {
                        ascending = !ascending;
                    }
                    sortByDate = true;             
                    MainScreen();
                    break;
                case "r":
                    minMark = 0;
                    maxMark = 10;
                    testName = "ALL";
                    limit = 100;
                    sortByDate = false;
                    ascending = true;

                    MainScreen();
                    break;

                default:
                    MainScreen();
                    break;
            }
        }

        private static void ShowCreateStudent()
        {
            Console.Clear();
            Console.WriteLine("First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Test name:");
            string testName = Console.ReadLine();
            Console.WriteLine("Mark:");
            int testMark = int.Parse(Console.ReadLine());
            Console.WriteLine("Date:");
            var testDate = DateTime.Parse(Console.ReadLine());

            storage.AddAndSaveItem(new StudentData() {
                firstName = firstName,
                lastName = lastName,
                testName = testName,
                testDate = testDate,
                testMark = testMark
            });
        }

        private static IEnumerable<StudentData> GetFilteredList()
        {
            IEnumerable<StudentData> filteredList =
                    (from student in storage.GetList()
                     where minMark <= student.testMark && maxMark >= student.testMark &&
                          (testName.ToUpper() == "ALL" || testName.ToUpper() == student.testName.ToUpper())
                     orderby (sortByDate ? student.testDate : new DateTime())
                     select student).Take(limit);

            return ascending ? filteredList : filteredList.Reverse();
        }
    }
}