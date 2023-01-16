﻿using MaterialDesignThemes.Wpf;
using System;
using System.Windows;

namespace EmojiVotoWPF.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IMainWindowViewModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}