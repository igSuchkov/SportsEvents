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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace SportsEvents
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        const string FileName = "Events.txt";
        List<Event> _Events = new List<Event>();

        private void RefreshListBox()
        {
            listBoxEvents.ItemsSource = null;
            listBoxEvents.ItemsSource = _Events;
        }

        private void SaveData()
        {
            if (_Events.Count != 0)
            {
                using (var sw = new StreamWriter(FileName))
                {
                    foreach (var even in _Events)
                    {
                        sw.WriteLine($"{even.Name}:{even.Price}:{even.Country}");
                    }
                }
            }
        }
        private void LoadData()
        {
            try
            {
                using (var sr = new StreamReader(FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var parts = line.Split(':');
                        var Event = new Event(parts[0], int.Parse(parts[1]), parts[2]);
                        _Events.Add(Event);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файла не существует");
            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }
            RefreshListBox();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewMainWindow();
            if (window.ShowDialog().Value)
            {
                _Events.Add(window.NewEvent);
                SaveData();
                RefreshListBox();
            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            List<Event> events = _Events;
            var Event = _Events[listBoxEvents.SelectedIndex];
            var window = new EditWindow(Event, events);
            if (window.ShowDialog().Value)
            {
                SaveData();
                RefreshListBox();
            }
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEvents.SelectedIndex != -1)
            {
                _Events.RemoveAt(listBoxEvents.SelectedIndex);
                SaveData();
                RefreshListBox();
            }
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TextBoxSearch.Text;
            if(text == "")
            {
                listBoxEvents.ItemsSource = _Events;
            }
             else
            {
                listBoxEvents.ItemsSource = SearchEvent(text);
            }
        }

        public List<Event> SearchEvent(string input)
        {
            List<Event> tmp = new List<Event>();
            foreach(var item in _Events)
            {
                if(input == item.Name || input == item.Country)
                {
                    tmp.Add(item);
                }
            }
            return tmp;
        }
    }
}
