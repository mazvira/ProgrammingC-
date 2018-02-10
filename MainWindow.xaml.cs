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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FontAwesome.WPF;
namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(UpdateResult, ShowLoader);
        }

        private void UpdateResult()
        {
            ((MainWindowViewModel)DataContext).Age = ((MainWindowViewModel)DataContext).Age + " years of old";
           ((MainWindowViewModel)DataContext).WestHoroscope = ((MainWindowViewModel)DataContext).WestHoroscope + " west Horoscope";
            ((MainWindowViewModel)DataContext).ChineseHoroscope = ((MainWindowViewModel)DataContext).ChineseHoroscope + " chinese Horoscope";
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(MainGrid, ref _loader, isShow);
        }
    }
}
