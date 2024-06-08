using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tesis
{
    /// <summary>
    /// Interaction logic for UserPanel_Home.xaml
    /// </summary>
    public partial class UserPanel_Home : Window
    {
        private SqliteConnection conn;
        public UserPanel_Home()
        {
            InitializeComponent();
            conn = new SqliteConnection("Data Source=db.db;");
            conn.Open();
            CreateTableStudents();
        }
        private void CreateTableStudents()
        {
            string query = @"CREATE TABLE IF NOT EXISTS Students(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            Apellido TEXT NOT NULL,
                            Rut TEXT NOT NULL);";
            using (SqliteCommand command = new SqliteCommand(query, conn))
            {
                command.ExecuteNonQuery();
                Console.Write("Student create");
            }
        }
        private void UserQuestions_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNombre.Text;
            string last_name = txtApellido.Text;
            string rut = txtRut.Text;
            string query = "INSERT INTO Students(Nombre, Apellido, Rut) VALUES(@name, @last_name, @rut)";
            using (SqliteCommand cmd = new SqliteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@rut", rut);
                cmd.ExecuteNonQuery();

                
                cmd.CommandText = "SELECT last_insert_rowid()";
                int studentId = Convert.ToInt32(cmd.ExecuteScalar());

                UserQuestions(studentId);
            }
            
        }
        private void UserQuestions(int id)
        {
            UserQuestions user = new UserQuestions();

            user.studentId = id;
            user.Show();
            this.Close();
        }
        private void _Click(object sender, RoutedEventArgs e)
        {
            Console.Write("Banner");
        }
    }
}
