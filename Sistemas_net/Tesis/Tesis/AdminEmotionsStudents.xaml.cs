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
    /// Interaction logic for AdminEmotionsStudents.xaml
    /// </summary>
    public partial class AdminEmotionsStudents : Window
    {
        private SqliteConnection connection;
        private List<EmotionItems> emocionesData = new List<EmotionItems>();
        public AdminEmotionsStudents()
        {
            InitializeComponent();
            connection = new SqliteConnection("Data Source=db.db;");
            connection.Open();
            Console.WriteLine("Conexión realizada");
            LoadEmotionsStudents();
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
            using (SqliteCommand cmd = new SqliteCommand(query, connection))
            {
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        emociones.Add(new EmotionItems
                        {
                            Id = reader.GetInt32(0),
                            QuestionId = reader.GetInt32(1),
                            IdStudent = reader.GetInt32(2),
                            Response = reader.GetString(3),
                            Emotion = reader.GetString(4)
                        });
                    }
                }
            }
            return emociones;
        }
        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            AdminHome adminHome = new AdminHome();
            adminHome.Show();
            this.Close();
        }
    }
    public class EmotionItems
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int IdStudent { get; set; }
        public string Response { get; set; }
        public string Emotion { get; set; }
    }
}
