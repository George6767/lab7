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

namespace lab7_2
{
    /// <summary>
    /// Логика взаимодействия для WindowPerson.xaml
    /// </summary>
    public partial class WindowPerson : Window
    {
        public WindowPerson(Person person)
        {
            InitializeComponent();
            grid.DataContext = person;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
