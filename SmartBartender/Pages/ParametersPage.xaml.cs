﻿using SmartBartender.Data.Classes;
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
using SmartBartender.Data.Model;

namespace SmartBartender.Pages
{
    /// <summary>
    /// Логика взаимодействия для ParametersPage.xaml
    /// </summary>
    public partial class ParametersPage : Page
    {
        public ParametersPage()
        {
            InitializeComponent();
            itemsControl.ItemsSource = DataBaseConnection.connection.Parameters.ToList();
        }
    }
}
