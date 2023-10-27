using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{
    internal class EmployeeManager
    {
        internal static int EnterEmployeeID()
        {
            while (true)
            {
                Console.WriteLine("Enter ID of Employee");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int id))
                {
                    return id;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid ID (a number).");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }

        internal static string EnterEmployeePhoneNumber()
        {
            string phoneNumber;
            while (true)
            {
                Console.WriteLine("Enter Phone number of Employee (10 digits only): ");
                phoneNumber = Console.ReadLine();

                if (phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit))
                {
                    return phoneNumber;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid 10-digit phone number.");
                    Console.ResetColor();
                }
            }
        }

        internal static int EnterEmployeeAge()
        {
            while (true)
            {
                Console.WriteLine("Enter Age of Employee");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int age) && age >= 18 && age <= 60)
                {
                    return age;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid age (18 to 60).");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        internal static string EnterEmployeeAdress()
        {
            while (true)
            {
                Console.WriteLine("Enter Adress of Employee");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid address.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        internal static string EnterEmployeeName()
        {
            while (true)
            {
                Console.WriteLine("Enter Name of Employee: ");
                string name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name) && !name.Any(char.IsDigit))
                {
                    return name;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid name.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static void Title()
        {
            Console.WriteLine();
            Console.WriteLine(".............Welcom to Employee Management System.............");
            Console.WriteLine("This is a program for employee management, thank you for using the application");
            Console.WriteLine();
        }

        internal static void MenuForLogin()
        {
            Console.WriteLine();
            Console.WriteLine("1. You are logged in as a company");
            Console.WriteLine("2. You are logged in as a employee");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
        }

        internal static void MenuForCompany()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Project");
            Console.WriteLine("3. View Employee");
            Console.WriteLine("4. View Project");
            Console.WriteLine("5. DeleteEmployeeID");
            Console.WriteLine("6. DeleteProjectID");
            Console.WriteLine("7. SearchEmployeeByID");
            Console.WriteLine("8. SearchProjectByID");
            Console.WriteLine("9. Logout");
            Console.WriteLine();
            Console.WriteLine("Please choose your option: ");
        }

        internal static void AddSuccessful()
        {
            Console.WriteLine("Add Successful...");
        }
        internal static void MenuForEmployee()
        {
            Console.WriteLine();
            Console.WriteLine("1. View Employee");
            Console.WriteLine("2. View Project");
            Console.WriteLine("3. Logout");
            Console.WriteLine();
            Console.WriteLine("Please choose your option: ");
        }

        internal static int EnterProjectID()
        {
            Console.Write("Enter Project ID: ");
            return int.Parse(Console.ReadLine());
        }

        internal static void DeleteFail()
        {
            Console.WriteLine("Delete fail...");
            Console.WriteLine("Pls Try again...");
        }

        internal static void DeleteSuccessful()
        {
            Console.WriteLine("Delete Successful...");
        }

        internal static void SearchSuccessful()
        {
            Console.WriteLine("Search Successful");
        }
    }
}
