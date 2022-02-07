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

namespace WordCounter.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для Word.xaml
    /// </summary>
    public partial class Word : UserControl
    {
        public Word(Lib.Word word)
        {
            InitializeComponent();
            WordValueLb.Content = word.Value;
            WordCountLb.Content = word.Count;
        }
    }
}
