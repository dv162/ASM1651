using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{

    public class Project
    {
        private int projectId;
        public int ProjectId { get { return projectId; } set { projectId = value; } }
        private Employee employee;
        public Employee Employee { get { return employee; } set { employee = value; } }
        private string namePro;
        public string NamePro { get { return namePro; } set { namePro = value; } }
        private string details;
        public string Details { get { return details; } set { details = value; } }

        public Project()
        {
        }

        public Project(int projectId, Employee employee, string namePro, string details)
        {
            ProjectId = projectId;
            Employee = employee;
            NamePro = namePro;
            Details = details;
        }


        public override string ToString()
        {
            return "Project ID: " + ProjectId +
                "Employee : " + employee.Name +
                "Name Project: " + NamePro +
                "Details: " + Details;
        }
    }
}
