using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine("Sum of numbers in the array");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine($"\n");

            Console.WriteLine("Average of numbers in the array");
            Console.WriteLine(numbers.Average());
            Console.WriteLine($"\n");

            //Order numbers in ascending order and decsending order. Print each to console.

            Console.WriteLine("Ascending");
            foreach (int value in numbers.OrderBy(value => value))
            {
                Console.WriteLine(value);
            }
            Console.WriteLine($"\n");

            Console.WriteLine("Descending");
            foreach (int value in numbers.OrderByDescending(value => value))
            {
                Console.WriteLine(value);
            }
            Console.WriteLine($"\n");


            //Print to the console only the numbers greater than 6

            Console.WriteLine("Greater than 6");
            foreach (int value in numbers.Where(value => value > 6))
            {
                Console.WriteLine(value);
            }
            Console.WriteLine($"\n");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("4 taken descending");
            foreach (int value in numbers.OrderByDescending(value => value).Take(4))
            {
                Console.WriteLine(value);
            }
            Console.WriteLine($"\n");

            //Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 35;
            Console.WriteLine("Descending with my age");
            foreach (int value in numbers.OrderByDescending(value => value))
            {
                Console.WriteLine(value);
            }
            Console.WriteLine($"\n");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            Console.WriteLine("Employees alphabetical by firt name beginning with C or S");
            foreach(var employee in employees.OrderBy(value => value.FirstName).Where(value => value.FirstName.StartsWith("C") || value.FirstName.StartsWith("S")))
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine($"\n");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            Console.WriteLine("Over 26, ordered by age then first name");
            foreach (var employee in employees.OrderBy(value => value.Age).ThenBy(value => value.FirstName).Where(value => value.Age > 26))
            {
                Console.WriteLine($"{employee.FullName} {employee.Age}");
            }
            Console.WriteLine($"\n");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35


            Console.WriteLine("Sum of employees experience who are older than 35 and have less than 10 years of experience");
            Console.WriteLine(employees.Where(value => value.Age > 35 && value.YearsOfExperience <= 10).Sum(value => value.YearsOfExperience));
            Console.WriteLine($"\n");

            Console.WriteLine("Average of employees experience who are older than 35 and have less than 10 years of experience");
            Console.WriteLine(employees.Where(value => value.Age > 35 && value.YearsOfExperience <= 10).Average(value => value.YearsOfExperience));
            Console.WriteLine($"\n");

            //Add an employee to the end of the list without using employees.Add()

            Console.WriteLine("Add myself to the list of employees as a new employee");
            employees = employees.Append(new Employee("Joey", "Stilley", 35, 0)).ToList();
            
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
