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

namespace SportsEvents
{
    public partial class NewMainWindow : Window
    {
        public NewMainWindow()
        {
            InitializeComponent();
        }

        Event _NewEvent;

        public Event NewEvent
        {
            get
            {
                return _NewEvent;
            }
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            int price;
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Необходимо ввести название события");
                textBoxName.Focus();
                return;
            }
            if (!int.TryParse(textBoxPrice.Text, out price))
            {
                MessageBox.Show("Некорректное значение цены");
                textBoxPrice.Focus();
                return;
            }
            if (price < 0)
            {
                MessageBox.Show("Цена должна быть положительной");
                textBoxPrice.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxCountry.Text))
            {
                MessageBox.Show("Необходимо ввести название страны");
                textBoxCountry.Focus();
                return;
            }

            _NewEvent = new Event(textBoxName.Text, price, textBoxCountry.Text);
            DialogResult = true;
        }
    }
}
