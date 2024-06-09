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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace Tesis
{
    /// <summary>
    /// Interaction logic for AdminLogeo.xaml
    /// </summary>
    public partial class AdminLogeo : Window
    {
        private SqliteConnection conn;
        public AdminLogeo()
        {
            InitializeComponent();
            conn = new SqliteConnection("Data Source=db.db");
            conn.Open();
            CreateTableDocente();

        }
        private void CreateTableDocente()
        {
            string query = @"CREATE TABLE IF NOT EXISTS Docente(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            Rut TEXT NOT NULL,
                            Password TEXT NOT NULL);";
            using (SqliteCommand command = new SqliteCommand(query, conn))
            {
                command.ExecuteNonQuery();
                Console.Write("Docente create");
            }

        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            CreateTableDocente();
            string rut = txtRut.Text; 
            string password = txtPassword.Password;
            bool loginSuccessful = false; // Variable para controlar el estado del logeo

            if (!string.IsNullOrWhiteSpace(rut) && !string.IsNullOrWhiteSpace(password))
            {
                    string query = "SELECT * FROM Docente WHERE Rut=@rut AND Password = @password";
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rut", rut);
                        cmd.Parameters.AddWithValue("@password", password);


                        using (SqliteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("Logeo correcto");
                                loginSuccessful = true; 

                        }
                            else
                            {
                                MessageBox.Show("Credenciales incorrectas");
                            }
                        }
                    }
            }
            else
            {
                MessageBox.Show("Valores incorrectos");
            }
            if (loginSuccessful == true)
            {
                AdminHome adminhome = new AdminHome();
                adminhome.Show();
                this.Close();
            }


        }
    }
}
