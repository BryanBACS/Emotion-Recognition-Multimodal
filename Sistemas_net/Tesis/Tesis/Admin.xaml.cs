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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private SqliteConnection sqlite_conn;
        public Admin()
        {
            InitializeComponent();
            sqlite_conn = new SqliteConnection("Data Source=db.db;");
            sqlite_conn.Open();
            Console.WriteLine("Conexión abierta correctamente.");
            CreateQuestionsTableIfNotExists();
        }
        private void CreateQuestionsTableIfNotExists()
        {
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Questions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    QuestionText TEXT NOT NULL,
                    Puntaje INTEGER NOT NULL
                );";


            using (SqliteCommand cmd = new SqliteCommand(createTableQuery, sqlite_conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            string questionText = txtQuestion.Text;
            if (!string.IsNullOrWhiteSpace(questionText))
            {
                int puntaje = (int)sliderPuntaje.Value;
                string query = "INSERT INTO Questions (QuestionText,Puntaje) VALUES (@QuestionText, @Puntaje)";
                using (SqliteCommand cmd = new SqliteCommand(query, sqlite_conn))
                {
                    cmd.Parameters.AddWithValue("@QuestionText", questionText);
                    cmd.Parameters.AddWithValue("@Puntaje", puntaje);
                    cmd.ExecuteNonQuery();
                }
                txtQuestion.Clear();
                MessageBox.Show("Pregunta agregada correctamente");
            }
            else
            {
                MessageBox.Show("Ingresar pregunta");
            }
        }
        private void btnGoStudent_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnCRUD_ADMIN_Click(object sender, RoutedEventArgs e)
        {
            AdminHome crud = new AdminHome();
            crud.Show();
            this.Close();
        }
    }
}
