using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laczenie_z_baza_wpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void CreateMySqlDataReader(string mySelectQuery, MySqlConnection myConnection)
        {
            myConnection.ConnectionString = "Persist Security Info=False; database=sakila; server=localhost; Connect Timeout=10; user id=root; pass=";
            MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
            myConnection.Open();
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            try
            {
                while (myReader.Read())
                {
                    Console.Write(myReader.GetInt64(0) + ", ");
                    Console.Write(myReader.GetString(1) + ", ");
                    Console.WriteLine(myReader.GetString(2));
                }
            }
            finally
            {
                myReader.Close();
                myConnection.Close();
            }
        }

        private void MySqlInsert(string mySelectQuery)
        {
            MySqlConnection myConnection = new MySqlConnection();
            myConnection.ConnectionString = "Persist Security Info=False; database=sakila; server=localhost; Connect Timeout=10; user id=root; pass=";
            MySqlCommand sqlCommand = new MySqlCommand(mySelectQuery, myConnection);
            myConnection.Open();
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception blad) { Console.WriteLine(blad.Message); }
            finally { myConnection.Close(); }
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            string imie = txt_imie.Text, nazwisko = txt_nazwisko.Text;
            MySqlConnection conn = new MySqlConnection();
            MySqlInsert($"INSERT INTO actor (first_name, last_name) VALUES ('{imie}', '{nazwisko}');");
        }
    }
}
