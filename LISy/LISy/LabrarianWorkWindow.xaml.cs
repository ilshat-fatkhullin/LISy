using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для LabrarianWorkWindow.xaml
    /// </summary>
    public partial class LabrarianWorkWindow : Window
    {
        public LabrarianWorkWindow()
        {
            InitializeComponent();
        }

        private void LabrarianWorkWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
           
            SqlConnection connection = null;
            try
            {
               

                // установка команды на добавление для вызова хранимой процедуры

                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        private void UpdateDB()
        {
          
        }
       
        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void button_search_db_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
   
}
