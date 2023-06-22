using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.ObjectModel;
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

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person;
        ObservableCollection<Person> people = new ObservableCollection<Person>(); 
        public MainWindow()
        {
            InitializeComponent();
            person = new Person();
            stackpanelPerson.DataContext = person;
            listBox.DataContext = people;
            Filldata();
        }
        private void Filldata()
        {
            people.Clear();
            foreach(Person person in Person.getAllPersons())
            {
                people.Add(person);
            }
        }

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
