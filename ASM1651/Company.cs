using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{
    public class Company : ILogin
    {
        List<Employee> employees = new List<Employee>();
        List<Project> projects = new List<Project>();

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public List<Project> Projects
        {
            get => projects; set => projects = value;
        }


        public Company()
        {

        }
        public bool Login(string usernameToCheck, string passwordToCheck)
        {
            string usernameCorrect = "Company";
            string passwordCorrect = "Company";
            if (usernameToCheck == usernameCorrect && passwordToCheck == passwordCorrect)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddProject(Project projects)
        {
            Projects.Add(projects);
        }
        public void AddInformationEmployee()
        {
            Employee newEmployee = new Employee();

            int newEmployeeID;
            bool isUniqueID = false;

            //Check if ID exists use while loop
            while (!isUniqueID)
            {
                newEmployeeID = EmployeeManager.EnterEmployeeID();

                if (!employees.Any(employee => employee.ID == newEmployeeID))
                {
                    isUniqueID = true;
                    newEmployee.ID = newEmployeeID;
                }
                else
                {
                    Console.WriteLine("Employee with the same ID already exists.");
                }
            }

            newEmployee.InputInfor();
            employees.Add(newEmployee);

        }
        public void PrintInformationOfEmployee()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                   Company-List                   ");
            foreach (var employee in employees)
            {
                Console.WriteLine("EmployeeID: "
                    + employee.ID + " " +"Name: "
                    + employee.Name + " " + "Age: "
                    + employee.Age + " " + "Adress:  "
                    + employee.Adress + " " + "PhoneNumber: "
                    + employee.PhoneNumber);
            }

            Console.ForegroundColor = ConsoleColor.White;

        }
        public void PrintInformationOfProject()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("               Project-List               ");
            foreach (var project in Projects)
            {
                Console.WriteLine("Project ID: " 
                    + project.ProjectId +" Employee Name: " 
                    + project.Employee.Name +" Name of Project: " 
                    + project.NamePro +" Details: " 
                    + project.Details);

            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool DeleteProjectByID(int idProjectToDelete)
        {
            var projectInList = Projects.FirstOrDefault(n => n.ProjectId.Equals(idProjectToDelete));
            Projects.Remove(projectInList);
            return true;
        }
        public bool DeleteEmployeeByID(int idEmployeeToDelete)
        {
            var employeesInList = employees.FirstOrDefault(n => n.ID.Equals(idEmployeeToDelete));
            employees.Remove(employeesInList);
            return true;
        }



        public bool SearchEmployeeID(int idEmployeeToSearch)
        {
            var employeeInList = employees.FirstOrDefault(n => n.ID.Equals(idEmployeeToSearch));
            if (employeeInList == null)
            {
                return false;
            }
            return true;
        }


        public bool SearchProjectID(int idProjectToSearch)
        {
            var projectInList = Projects.FirstOrDefault(n => n.ProjectId.Equals(idProjectToSearch));
            if (projectInList == null)
            {
                return false;
            }
            return true;
        }

        public Employee SearchEmployeeObj(int idEmployeeToSearch)
        {
            var employeeInList = employees.FirstOrDefault(n => n.ID.Equals(idEmployeeToSearch));
            return employeeInList;
        }

        public Project GetProjectByID(int idProjectToSearch)
        {
            var projectInList = Projects.FirstOrDefault(x => x.ProjectId.Equals(idProjectToSearch));
            return projectInList;
        }
        public Employee GetEmployeeByID(int idEmployeeToSearch)
        {
            var employeeInList = employees.FirstOrDefault(x => x.ID.Equals(idEmployeeToSearch));
            return employeeInList;
        }
    }
}
