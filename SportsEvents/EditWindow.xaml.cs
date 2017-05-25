﻿using System;
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
    public partial class EditWindow : Window
    {
        Event _event;

        public Event Event
        {
            get
            {
                return _event;
            }
        }
        List<Event> _Events = new List<Event>();
        public EditWindow(Event Event, List<Event> events)
        {
            _event = Event;
            _Events = events;
            InitializeComponent();
            textBoxName.Text = Event.Name;
            textBoxPrice.Text = Event.Price.ToString();
            textBoxCountry.Text = Event.Country;
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            foreach (var _event in _Events)
            {
                if (_event == Event)
                {
                    _event.Name = textBoxName.Text;
                    _event.Price = int.Parse(textBoxPrice.Text);
                    _event.Country = textBoxCountry.Text;
                }
            }
            DialogResult = true;
        }
    }
}
