using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private SQLiteConnection sqlite_conn;
        public Admin()
        {
            InitializeComponent();
            sqlite_conn = new SQLiteConnection("Data Source=db.db; Version=3;");
            sqlite_conn.Open();
            Console.WriteLine("Conexión abierta correctamente.");
            CreateQuestionsTableIfNotExists();
        }
        private void CreateQuestionsTableIfNotExists()
        {
            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Questions (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                QuestionText TEXT NOT NULL
            );";

            using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, sqlite_conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            string questionText = txtQuestion.Text;
            if (!string.IsNullOrWhiteSpace(questionText)) {
                string query = "INSERT INTO Questions (QuestionText) VALUES (@QuestionText)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, sqlite_conn))
                {
                    cmd.Parameters.AddWithValue("@QuestionText", questionText);
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
            Main main = new Main();
            main.Show();
            this.Close();
        }
        
        private void btnCRUD_ADMIN_Click(object sender, RoutedEventArgs e)
        {
            CrudAdmin crud = new CrudAdmin();
            crud.Show();
            this.Close();
        }
    }
}
