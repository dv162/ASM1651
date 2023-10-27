using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{
    public abstract class Person
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private int age;
        public int Age { get { return age; } set { age = value; } }
        private string adress;
        public string Adress { get { return adress; } set { adress = value; } }
        private int phoneNumber;
        public int PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public Person()
        {
        }

        protected Person(string name, int age, string adress, int phoneNumber)
        {
            Name = name;
            Age = age;
            Adress = adress;
            PhoneNumber = phoneNumber;
        }

        public abstract void InputInfor();
    }
}
