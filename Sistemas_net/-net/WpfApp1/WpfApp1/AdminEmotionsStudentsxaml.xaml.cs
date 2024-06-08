using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
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
using static WpfApp1.AdminEmotionsStudentsxaml;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AdminEmotionsStudentsxaml.xaml
    /// </summary>
    public partial class AdminEmotionsStudentsxaml : Window
    {
        private SQLiteConnection connection;
        private List<EmotionItems> emocionesData = new List<EmotionItems>();
        public AdminEmotionsStudentsxaml()
        {
            InitializeComponent();
            connection = new SQLiteConnection("Data Source=db.db; Version=3;");
            connection.Open();
            Console.WriteLine("Conexión realizada");
            CreateTableEmotions();
            LoadEmotionsStudents();
        }
        private void CreateTableEmotions()
        {
            string query = @"CREATE TABLE IF NOT EXISTS Emotions(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                QuestionId INTEGER NOT NULL,
                ResponseText TEXT NOT NULL,
                Emotion TEXT NOT NULL,
                FOREIGN KEY(QuestionId) REFERENCES Questions(Id)  
            );";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private void LoadEmotionsStudents()
        {

            emocionesData = GetEmotionsStudents();
            //Update list
            lsEmotions.ItemsSource = emocionesData;


        }
        private List<EmotionItems> GetEmotionsStudents()
        {
            List<EmotionItems> emociones = new List<EmotionItems>();
            string query = "SELECT * FROM Emotions";
            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        emociones.Add(new EmotionItems
                        {
                            Id = reader.GetInt32(0),
                            QuestionId = reader.GetInt32(1),
                            Response = reader.GetString(2),
                            Emotion = reader.GetString(3)
                        });
                    }
                }
            }
            return emocionesData;
        }
    }
    public class EmotionItems
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Response { get; set; }
        public string Emotion { get; set; }
    }
}
