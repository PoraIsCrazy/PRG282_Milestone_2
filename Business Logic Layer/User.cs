using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG282_Milestone_2.Data_Access_Layer;
using System.Windows.Forms;

namespace PRG282_Milestone_2.Business_Logic_Layer
{
    class User
    {
        private string username;
        private string password;
        private string name;
        private string surname;
        private string title;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Title { get => title; set => title = value; }

        public User(string username, string password, string name, string surname, string title)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.title = title;
        }

        public User()
        {
            
        }

        public bool login(string username, string password)
        {
            FileHandler fh = new FileHandler();

            if (fh.checkLogin(username, password))
            {
                User temp = new User();
                temp = fh.getUser(username, password);
                this.username = temp.username;
                this.password = temp.password;
                this.name = temp.name;
                this.surname = temp.surname;
                this.title = temp.title;
                return true;
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
                return false;
            }
        }

    }
}
