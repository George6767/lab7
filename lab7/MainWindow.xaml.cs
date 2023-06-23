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
    /// <summary>/// Interaction logic for MainWindow.xaml
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
            foreach (Person person in Person.getAllPerson())
            {
                people.Add(person);
            }
        }

        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            Filldata();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            person.Insert();
            Filldata();
        }

        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {
            person = Person.Find(textBoxName.Text);
            if (person == null)
            {
                MessageBox.Show("нет такой записи");
            }
            else
            {
                MessageBox.Show(person.ToString());
            }
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Нет выбранной записи");
                return;
            }
            person.Id = ((Person)listBox.SelectedItem).Id;
            if(textBoxName.Text.Length > 0)
            {
                person.Name = textBoxName.Text;
            }
            else
            {
                person.Sum = ((Person)listBox.SelectedItem).Sum;
            }
            decimal d = Convert.ToDecimal(textBoxSum.Text);
            if(d != 0)
            {
                person.Sum = d;
            }
            else
            {
                person.Name = ((Person)listBox.SelectedItem).Name;
            }
            MessageBox.Show(person.ToString());
            person.Update();
            Filldata();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Нет выбранной записи");
                return;
            }
            var id = ((Person)listBox.SelectedItem).Id;
            Person.Delete(id);
            Filldata();
        }
    }
}
