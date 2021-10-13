using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using PRG282_Milestone_2.Business_Logic_Layer;

namespace PRG282_Milestone_2.Data_Access_Layer
{
    class FileHandler
    {
        public FileHandler()
        {
        }

        


        //Set connection string
        string connect = "Data Source=,;Initial Catalog=Student_info;Integrated Security=True";
        SqlConnection conn;
        SqlConnection conn2;
        SqlConnection conn3;

        SqlCommand command;
        SqlCommand command2;
        SqlCommand command3;

        SqlDataReader reader;
        SqlDataReader reader2;
        SqlDataReader reader3;

        //deletes student data
        public void deleteStudent(string studentNr)
        {
            string query = @"DELETE FROM Student WHERE StudentNr = ('" + studentNr + "')";

            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);

            try
            {
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                conn.Close();
            }

        }

        public void deleteModule(string moduleCode)
        {
            string query = @"DELETE FROM Module WHERE ModuleCode = ('" + moduleCode + "')";

            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);

            try
            {
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

        }


        //creates a user if needed
        public void createUser(string username, string password, string name, string surname, string title)
        {

            string query = @"INSERT INTO User (Username, Password) VALUES ( '" + username + "', '" + password + "', '" + name + "', '" + surname + "', '" + title + "' )";

            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);




            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("User Registered, Please log in!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("details of new User not saved: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //to check if the user already exists 
        public bool checkIfUserExists(string username)
        {

            bool usernameExist = false;
            string query = @"SELECT * FROM User WHERE Username = ('" + username + "')";


            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);


            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    usernameExist = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {

                conn.Close();

            }
            return usernameExist;
        }

        //to update student information
        public void Update(string studentNr, string name, string surname, string birthDate, string gender, int phone, string address, string moduleCode)
        {
            string query = @"UPDATE Student SET studentNr = ('" + studentNr + "'), name = ('" + name + "'), " +
                "surname= ('" + surname + "'), birthDate = ('" + birthDate + "'), gender = ('" + gender + "'), phone = ('"+phone+ "'),address = ('" + address + "'), moduleCode = ('" + moduleCode + "')  WHERE StudentID = ('" + studentNr + "')";

            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Details updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateModule(string moduleCode, string name, string description, string ytLinks)
        {
            string query = @"UPDATE Module SET moduleCode = ('" + moduleCode + "'), name = ('" + name + "'), " + "description = ('" + description + "'), ytLinks = ('" + ytLinks + "')";

            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Details updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        //search for a student

        Student studentObj = new Student();
        public List<Student> Search(string studentNr)
        {


            string query = @"SELECT * FROM STUDENT WHERE studentNr = ('" + studentNr + "')";


            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);
            List<Student> studentSearch = new List<Student>();


            try
            {

                reader = command.ExecuteReader();
                if (reader.Read())
                {

                    studentObj.StudentNr = (reader[0].ToString());
                    studentObj.Name = reader[1].ToString();
                    studentObj.Surname = reader[2].ToString();
                    studentObj.BirthDate = (reader[3].ToString());
                    studentObj.Gender = (reader[4].ToString());
                    studentObj.Phone = (reader[5].ToString());
                    studentObj.Address = (reader[6].ToString());
                    studentObj.ModuleCode = (reader[7].ToString());



                    studentSearch.Add(new Student(studentObj.StudentNr, studentObj.Name, studentObj.Surname, studentObj.BirthDate, studentObj.Gender, studentObj.Phone, studentObj.Address, studentObj.ModuleCode));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return studentSearch;
        }

        // check if user exists  
        public bool checkLogin(string username, string password)
        {
            string query = @"SELECT * FROM User WHERE UserUsername = ('" + username + "') AND UserPassword = ('" + password + "')";


            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);
            bool clientFound = false;

            try
            {

                reader = command.ExecuteReader();
                if (reader.Read())
                {

                    clientFound = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checkLogin: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return clientFound;
        }

        public User getUser(string username, string password)
        {
            string query = @"SELECT * FROM User WHERE UserUsername = ('" + username + "') AND UserPassword = ('" + password + "')";


            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);
            User loggedUser = new User();

            try
            {

                reader = command.ExecuteReader();
                if (reader.Read())
                {

                    loggedUser.Username = reader[0].ToString();
                    loggedUser.Password = reader[1].ToString();
                    loggedUser.Name = reader[2].ToString();
                    loggedUser.Surname = reader[3].ToString();
                    loggedUser.Title = reader[4].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getClient: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return loggedUser;
        }

        public void createModule(string moduleCode, string name, string description, string ytLinks)
        {

            string query = @"INSERT INTO Module VALUES ( '" + moduleCode + "', '" + name + "', '" + description + "', '" + ytLinks + "' )";

            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);




            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Module updated");

            }
            catch (Exception ex)
            {
                MessageBox.Show("module not updated " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void CreateStudent(string studentNr, string name, string surname, string birthDate, string gender, int phone, string address, string moduleCode)
        {

            string query = @"INSERT INTO Student  VALUES ( '" + studentNr + "', '" + name + "', '" + surname + "', '" + birthDate + "', '" + gender + "', '" + phone + "', '" + address + "', '" + moduleCode + "' )";

            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);




            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Student Created");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Student details not saved" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        Module moduleObj = new Module();
        public List<Module> SearchModule(string moduleCode)
        {


            string query = @"SELECT * FROM Module WHERE ModudleCode = ('" + moduleCode + "')";


            conn = new SqlConnection(connect);

            conn.Open();

            command = new SqlCommand(query, conn);
            List<Module> moduleSearch = new List<Module>();


            try
            {

                reader = command.ExecuteReader();
                if (reader.Read())
                {

                    moduleObj.ModuleCode = (reader[0].ToString());
                    moduleObj.Name = reader[1].ToString();
                    moduleObj.Description = reader[2].ToString();
                    moduleObj.YtLinks = (reader[3].ToString());




                    moduleSearch.Add(new Module(moduleObj.ModuleCode, moduleObj.Name, moduleObj.Description, moduleObj.YtLinks));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return moduleSearch;
        }

    }
}
