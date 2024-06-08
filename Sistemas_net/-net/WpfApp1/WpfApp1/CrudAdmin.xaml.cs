using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class CrudAdmin : Window
    {
        private SQLiteConnection conn;
        private List<QuestionItem> questionsList = new List<QuestionItem>();

        public CrudAdmin()
        {
            InitializeComponent();
            conn = new SQLiteConnection("Data Source=db.db; Version=3;");
            conn.Open();
            Console.WriteLine("Conexión exitosa");
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            questionsList = GetQuestions();
            lstQuestions.ItemsSource = questionsList;
        }

        private List<QuestionItem> GetQuestions()
        {
            List<QuestionItem> questions = new List<QuestionItem>();
            string query = "SELECT * FROM Questions";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
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
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
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
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
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
            AdminEmotionsStudentsxaml student = new AdminEmotionsStudentsxaml();
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

