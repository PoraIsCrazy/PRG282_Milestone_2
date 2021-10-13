using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG282_Milestone_2.Data_Access_Layer;

namespace PRG282_Milestone_2.Business_Logic_Layer
{
    class Student
    {
        private string studentNr;
        private string name;
        private string surname;
        private string birthDate;
        private string gender;
        private string phone;
        private string address;
        private string moduleCode;

        public string StudentNr { get => studentNr; set => studentNr = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string BirthDate { get => birthDate; set => birthDate = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string ModuleCode { get => moduleCode; set => moduleCode = value; }

        public Student(string studentNr, string name, string surname, string birthDate, string gender, string phone, string address, string moduleCode)
        {
            this.StudentNr = studentNr;
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthDate;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
            this.ModuleCode = moduleCode;


        }

        public Student()
        {
            


        }

        public List<Student> getStudentByNumber(string studentNr)
        {
            FileHandler fh = new FileHandler();
            return fh.Search(studentNr);
        }

        public void deleteStudent(string studentNr)
        {
            FileHandler fh = new FileHandler();
            fh.deleteStudent(studentNr);
        }

        public void Update(string studentNr, string name, string surname, string birthDate, string gender, int phone, string address, string moduleCode)
        {
            FileHandler fh = new FileHandler();
            fh.Update(studentNr, name, surname, birthDate, gender, phone, address, moduleCode);
            
        }

        public void CreateStudent(string studentNr, string name, string surname, string birthDate, string gender, int phone, string address, string moduleCode)
        {
            FileHandler fh = new FileHandler();
            fh.CreateStudent(studentNr, name, surname, birthDate, gender, phone, address, moduleCode);

        }
    }


}
