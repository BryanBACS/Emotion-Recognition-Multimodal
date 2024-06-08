using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private SQLiteConnection conn;
        private static readonly HttpClient client = new HttpClient();
        public UserWindow()
        {
            InitializeComponent();
            conn = new SQLiteConnection("Data Source=db.db; Version=3;");
            conn.Open();
            Console.WriteLine("Conexión exitosa");
            CreateEmotionsTableIfNoExists();
            ShowQuestion();
        }
        private void CreateEmotionsTableIfNoExists()
        {
            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Emotions(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                QuestionId INTEGER NOT NULL,
                ResponseText TEXT NOT NULL,
                Emotion TEXT NOT NULL,
                FOREIGN KEY(QuestionId) REFERENCES Questions(Id)  
            );";
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, conn))
            {
                command.ExecuteNonQuery();
            }
        }
        private void ShowQuestion()
        {
            string query = "SELECT * FROM Questions ORDER BY RANDOM() LIMIT 1";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) {
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
                string query = "INSERT INTO Emotions (QuestionId, ResponseText, Emotion) VALUES (@QuestionId, @ResponseText, @Emotion)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuestionId", TxtPregunta.Tag);
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
