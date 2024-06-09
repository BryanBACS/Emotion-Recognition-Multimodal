using Microsoft.Data.Sqlite;
using System.Data.Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Linq;


namespace Tesis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqliteConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            CreateDatabaseIfNotExists("db.db");
            conn = new SqliteConnection("Data Source=db.db;");
            conn.Open();
            Console.WriteLine("Conexión exitosa db");
        }
        private void CreateDatabaseIfNotExists(string dbname)
        {
            string connectionString = $"Data Source={dbname};";
            try
            {
                if (!File.Exists(dbname))
                {
                    // Crear la base de datos simplemente abriendo una conexión
                    using (var connection = new SqliteConnection($"Data Source={dbname}"))
                    {
                        connection.Open();
                        CreateTableDocente();
                        CreateTableStudents();
                        CreateTableQuestions();
                        CreateTableEmotions();
                    }
                }
                conn = new SqliteConnection(connectionString);
                conn.Open();
                Console.WriteLine("Conexión exitosa db");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la base de datos: {ex.Message}");
            }

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
        private void CreateTableEmotions()
        {
            string query = @"CREATE TABLE IF NOT EXISTS Emotions(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            QuestionId TEXT NOT NULL,
                            IdStudent INTEGER NOT NULL,
                            Response TEXT NOT NULL,
                            Emotion TEXT NOT NULL,
                            FOREIGN KEY (QuestionId) REFERENCES Questions(Id),
                            FOREIGN KEY (IdStudent) REFERENCES Students(Id);";
            using (SqliteCommand command = new SqliteCommand(query, conn))
            {
                command.ExecuteNonQuery();
                Console.Write("Emotions create");
            }
        }
        private void OpenAdminPanel_Click(object sender, RoutedEventArgs e)
        {
            CreateDatabaseIfNotExists("db.db");
            AdminLogeo logeo = new AdminLogeo();
            logeo.Show();
            this.Close(); //Se cierra la ventana principal
        }

        private void OpenStudentPanel_Click(object sender, RoutedEventArgs e)
        {
            CreateDatabaseIfNotExists("db.db");
            UserPanel_Home panelWindow = new UserPanel_Home();
            panelWindow.Show();
            this.Close();
        }
    }
}