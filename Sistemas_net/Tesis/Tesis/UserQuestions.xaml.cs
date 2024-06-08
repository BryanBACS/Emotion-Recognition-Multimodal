using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using Microsoft.Data.Sqlite;

namespace Tesis
{
    /// <summary>
    /// Interaction logic for UserQuestions.xaml
    /// </summary>
    public partial class UserQuestions : Window
    {
        private SqliteConnection conn;
        public int studentId;
        private static readonly HttpClient client = new HttpClient();
        public UserQuestions()
        {
            InitializeComponent();
            this.studentId = studentId;
            conn = new SqliteConnection("Data Source=db.db;");
            conn.Open();
            Console.WriteLine("Conexión exitosa");
            CreateTableEmotions();
            ShowQuestion();
        }
        private void CreateTableEmotions()
        {
            string query = @"CREATE TABLE IF NOT EXISTS Emotions(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            QuestionId INTEGER NOT NULL,
                            IdStudent INTEGER NOT NULL,
                            Response TEXT NOT NULL,
                            Emotion TEXT NOT NULL,
                            FOREIGN KEY (QuestionId) REFERENCES Questions(Id),
                            FOREIGN KEY (IdStudent) REFERENCES Students(Id));";
            using (SqliteCommand command = new SqliteCommand(query, conn))
            {
                command.ExecuteNonQuery();
                Console.Write("Emotions create");
            }
        }
        
        private void ShowQuestion()
        {
            string query = "SELECT * FROM Questions ORDER BY RANDOM() LIMIT 1";
            using (SqliteCommand cmd = new SqliteCommand(query, conn))
            {
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        TxtPregunta.Text = reader["QuestionText"].ToString();
                        TxtPregunta.Tag = reader["Id"];
                    }
                    else
                    {
                        TxtPregunta.Text = "Felicidades, no hay más preguntas.";
                    }
                }
            }


        }

        private async void btnPredictEmotion_Click(object sender, RoutedEventArgs e)
        {
            string ResponseText = TextResponse.Text;
            if (!string.IsNullOrWhiteSpace(ResponseText))
            {
                string emotion = await predictEmotionAPI(ResponseText);
                string query = "INSERT INTO Emotions (QuestionId,IdStudent, Response, Emotion) VALUES (@QuestionId, @IdStudent, @ResponseText, @Emotion)";
                using (SqliteCommand cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuestionId", TxtPregunta.Tag);
                    cmd.Parameters.AddWithValue("@IdStudent", studentId);
                    cmd.Parameters.AddWithValue("@ResponseText", ResponseText);
                    cmd.Parameters.AddWithValue("@Emotion", emotion);
                    cmd.ExecuteNonQuery();
                }
                TextResponse.Clear();
                ShowQuestion();
                MessageBox.Show("Enviado" + emotion);


            }
            else
            {
                MessageBox.Show("Ingresar respuesta");
            }
        }
        private async Task<string> predictEmotionAPI(string response)
        {
            var content = new { text = response };
            var result = await client.PostAsJsonAsync("http://localhost:5000/predict", content);
            var emotionResult = await result.Content.ReadAsStringAsync();
            return emotionResult.ToString();

        }
    }
}
