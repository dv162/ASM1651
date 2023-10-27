using ASM1651;
using System;
using System.Drawing;

internal class Program
{
    private static Company company = new Company();
    private static Employee employee = new Employee();

    private static char isEndApp;

    static void Main(string[] args)
    {
        ILogin login;
        do
        {
            EmployeeManager.Title();
        MenuCommand:
            EmployeeManager.MenuForLogin();
            try
            {
                int optionForLogin;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out optionForLogin))
                    {
                        Console.WriteLine("Choose 1 of 3 options 1,2 and 3.");
                        continue;
                    }
                    switch (optionForLogin)
                    {
                        case 1:
                            do
                            {
                                login = new Company();
                                //Login Company
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Company Login");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Enter Username of Company: ");
                                string EnterUserName = Console.ReadLine();
                                Console.Write("Enter Password of Company: ");
                                string EnterPassword = Console.ReadLine();
                                if (company.Login(EnterUserName, EnterPassword))
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Login Successfully");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    EmployeeManager.MenuForCompany();
                                    do
                                    {
                                        int optionForMenuCompany;
                                        if (!int.TryParse(Console.ReadLine(), out optionForMenuCompany))
                                        {
                                            Console.WriteLine("Please enter a valid number 1 and 9.");
                                            continue;
                                        }
                                        switch (optionForMenuCompany)
                                        {
                                            case 1:

                                                // Add Employee
                                                company.AddInformationEmployee();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                EmployeeManager.AddSuccessful();
                                                Console.ForegroundColor = ConsoleColor.White;
                                                EmployeeManager.MenuForCompany();
                                                break;

                                            case 2:
                                                // Add Project
                                                try
                                                {
                                                    // Not genarate ID
                                                    Console.WriteLine("Enter Project ID: ");
                                                    int projectID = int.Parse(Console.ReadLine());

                                                    // Enter Employee ID
                                                    Employee newEmployee = new Employee();
                                                    newEmployee.ID = EmployeeManager.EnterEmployeeID();

                                                    while (!company.SearchEmployeeID(newEmployee.ID))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Employee ID not Exist. Please Enter Employee ID again");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        newEmployee.ID = EmployeeManager.EnterEmployeeID();
                                                    }

                                                    Employee employeeObj = company.SearchEmployeeObj(newEmployee.ID);


                                                    // Enter the rest of info

                                                    Console.WriteLine("Enter name project: ");
                                                    string namePro = Console.ReadLine();
                                                    Console.WriteLine("Enter details of project: ");
                                                    string details = Console.ReadLine();
                                                    Project newProject = new Project(projectID, employeeObj, namePro, details);


                                                    // Add new project to project list in employee
                                                    company.Projects.Add(newProject);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    EmployeeManager.AddSuccessful();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    EmployeeManager.MenuForCompany();

                                                }
                                                catch (FormatException ex)
                                                {
                                                    Console.WriteLine("Please enter the number\n" + ex.Message);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error " + ex.Message);
                                                }
                                                break;

                                            case 3:
                                                // View Employee
                                                company.PrintInformationOfEmployee();
                                                EmployeeManager.MenuForCompany();
                                                break;
                                            case 4:
                                                // View Project
                                                company.PrintInformationOfProject();
                                                EmployeeManager.MenuForCompany();
                                                break;
                                            case 5:
                                                // Delete Employee
                                                try
                                                {
                                                    int idToDelete = EmployeeManager.EnterEmployeeID();
                                                    while (!company.SearchEmployeeID(idToDelete))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        EmployeeManager.DeleteFail();
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        idToDelete = EmployeeManager.EnterEmployeeID();
                                                    }
                                                    company.DeleteEmployeeByID(idToDelete);

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    EmployeeManager.DeleteSuccessful();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    EmployeeManager.MenuForCompany();
                                                }
                                                catch (FormatException ex)
                                                {
                                                    Console.WriteLine("Please enter again\n" + ex.Message);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error " + ex.Message);
                                                }
                                                break;
                                            case 6:
                                                // Delete Project
                                                try
                                                {
                                                    int idToDelete = EmployeeManager.EnterProjectID();
                                                    while (!company.SearchProjectID(idToDelete))
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        EmployeeManager.DeleteFail();
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        idToDelete = EmployeeManager.EnterProjectID();
                                                    }
                                                    company.DeleteProjectByID(idToDelete);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    EmployeeManager.DeleteSuccessful();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    EmployeeManager.MenuForCompany();
                                                }
                                                catch (FormatException ex)
                                                {
                                                    Console.WriteLine("Please enter again\n" + ex.Message);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error " + ex.Message);
                                                }
                                                break;
                                            case 7:
                                                //Search Employee
                                                try
                                                {
                                                    int enterID = EmployeeManager.EnterEmployeeID();
                                                    var employeeInListBorrow = company.GetEmployeeByID(enterID);

                                                    if (employeeInListBorrow != null)
                                                    {
                                                        Console.WriteLine(employeeInListBorrow.ToString());
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        EmployeeManager.SearchSuccessful();
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        EmployeeManager.MenuForCompany();
                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Employee with ID " + enterID + " not found.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        EmployeeManager.MenuForCompany();
                                                    }
                                                }
                                                catch (FormatException ex)
                                                {
                                                    Console.WriteLine("Please enter a valid number\n" + ex.Message);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error: " + ex.Message);
                                                }
                                                break;

                                            case 8:
                                                //Search Project
                                                try
                                                {
                                                    int enterprojectID = EmployeeManager.EnterEmployeeID();
                                                    var projectInListBorrow = company.GetProjectByID(enterprojectID);

                                                    if (projectInListBorrow != null)
                                                    {
                                                        Console.WriteLine(projectInListBorrow.ToString());
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        EmployeeManager.SearchSuccessful();
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        EmployeeManager.MenuForCompany();
                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Employee with ID " + enterprojectID + " not found.");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        EmployeeManager.MenuForCompany();
                                                    }
                                                }
                                                catch (FormatException ex)
                                                {
                                                    Console.WriteLine("Please enter a vaild number\n" + ex.Message);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Error " + ex.Message);
                                                }
                                                break;

                                            case 9:
                                                goto MenuCommand;
                                            default:
                                                Console.WriteLine("Please enter a number between 1 and 9.");
                                                break;
                                        }
                                    } while (true);
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Login Fail\n Please Login again...");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    EmployeeManager.MenuForLogin();
                                }
                            }
                            while (optionForLogin != 3);
                            break;
                        case 2:
                            do
                            {
                                login = new Employee();
                                //Login Employee
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Employee Login");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Enter Username of Employee: ");
                                string EnterUserName = Console.ReadLine();
                                Console.Write("Enter Password of Employee: ");
                                string EnterPassword = Console.ReadLine();
                                employee.Login(EnterUserName, EnterPassword);
                                if (employee.Login(EnterUserName, EnterPassword))
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Login Successfully");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    EmployeeManager.MenuForEmployee();
                                    do
                                    {
                                        int optionForMenuEmployee;
                                        if (!int.TryParse(Console.ReadLine(), out optionForMenuEmployee))
                                        {
                                            Console.WriteLine("Choose 1 of 3 options 1,2 and 3.");
                                            continue;
                                        }
                                        switch (optionForMenuEmployee)
                                        {
                                            case 1:
                                                //View Employee
                                                company.PrintInformationOfEmployee();
                                                EmployeeManager.MenuForEmployee();
                                                break;

                                            case 2:
                                                // View Project
                                                company.PrintInformationOfProject();
                                                EmployeeManager.MenuForEmployee();
                                                break;
                                            case 3:
                                                goto MenuCommand;
                                            default:
                                                Console.WriteLine("Please enter 1, 2, or 3.");
                                                break;
                                        }
                                    }
                                    while (true);
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Login Fail\nPlease try again");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    EmployeeManager.MenuForLogin();
                                }
                            }
                            while (optionForLogin != 3);
                            break;
                        case 3:
                            Console.WriteLine("Thank you for using Empoyee Management");
                            break;
                        default:
                            Console.WriteLine("Choose 1 of 3 options 1,2 and 3.");
                            break;
                    }
                }
                while (optionForLogin != 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
            Console.ReadLine();
        } while (isEndApp == 'Y' || isEndApp == 'y');
        Console.WriteLine("Goood Bye!!!");
    }
}
