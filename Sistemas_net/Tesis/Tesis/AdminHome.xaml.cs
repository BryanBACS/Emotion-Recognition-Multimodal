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
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Window
    {
        private SqliteConnection conn;
        private List<QuestionItem> questionsList = new List<QuestionItem>();
        public AdminHome()
        {
            InitializeComponent();
            conn = new SqliteConnection("Data Source=db.db;");
            conn.Open();
            Console.WriteLine("Conexión exitosa");
            LoadQuestions();
        }
        private void LoadQuestions()
        {
            CreateTableQuestions();
            questionsList = GetQuestions();
            lstQuestions.ItemsSource = questionsList;
        }
        private void CreateTableQuestions()
        {
            string query = @"CREATE TABLE IF NOT EXISTS Questions(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            QuestionText TEXT NOT NULL,
                            Puntaje INTEGER NOT NULL);";
            using (SqliteCommand command = new SqliteCommand(query, conn))
            {
                command.ExecuteNonQuery();
                Console.Write("Question create");
            }
        }

        private List<QuestionItem> GetQuestions()
        {
            List<QuestionItem> questions = new List<QuestionItem>();
            string query = "SELECT * FROM Questions";
            using (SqliteCommand cmd = new SqliteCommand(query, conn))
            {
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questions.Add(new QuestionItem
                        {
                            Id = reader.GetInt32(0),
                            QuestionText = reader.GetString(1),
                            IsEditing = false // Asegurarse de que IsEditing esté en false
                        });
                    }
                }
            }
            return questions;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var questionItem = button?.DataContext as QuestionItem;
            if (questionItem != null)
            {
                questionItem.IsEditing = true;
                lstQuestions.Items.Refresh();
            }
        }

        private void btnSaveChange_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var questionItem = button?.DataContext as QuestionItem;
            if (questionItem != null)
            {
                questionItem.IsEditing = false;
                UpdateQuestion(questionItem);
                lstQuestions.Items.Refresh();
            }
        }

        private void UpdateQuestion(QuestionItem questionItem)
        {
            string query = "UPDATE Questions SET QuestionText = @QuestionText WHERE Id = @Id ";
            using (SqliteCommand command = new SqliteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@QuestionText", questionItem.QuestionText);
                command.Parameters.AddWithValue("@Id", questionItem.Id);
                command.ExecuteNonQuery();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var questionItem = button?.DataContext as QuestionItem;
            if (questionItem != null)
            {
                DeleteQuestion(questionItem.Id);
                LoadQuestions();
            }
        }

        private void DeleteQuestion(int id)
        {
            string query = "DELETE FROM Questions WHERE Id = @Id";
            using (SqliteCommand command = new SqliteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnCreateQuestion_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }
        private void btnEmotionsStudents_Click(object sender, RoutedEventArgs e)
        {
            AdminEmotionsStudents student = new AdminEmotionsStudents();
            student.Show();
            this.Close();

        }
    }
    public class QuestionItem
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public bool IsEditing { get; set; }
    }
}
