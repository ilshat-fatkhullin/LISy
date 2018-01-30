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

namespace LISy
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            if(checkBox.IsChecked == true)
            {
                MessageBox.Show("dcscsc");
            }
        }

        private void button_register_Click(object sender, RoutedEventArgs e)
        {
            WorkWindow work = new WorkWindow();
            work.Show();
            this.Close();
        }
    }
}
