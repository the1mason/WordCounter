using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WordCounter.WPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void CountBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(SourceTb.Text))
                {
                    MessageBox.Show("Fill the source field by attaching a file or entering URL");
                    return;
                }
                WordsSp.Children.Clear();
                List<Lib.Word> words = Service.CounterService.GetHtmlCount(SourceTb.Text);
                words = words.OrderByDescending(x => x.Count).ToList();
                words.ForEach(x => WordsSp.Children.Add(new Views.Word(x)));

                UniqueWordsLb.Content = words.Count;

                int totalWords = 0;
                foreach (Lib.Word word in words)
                {
                    totalWords += word.Count;
                }
                TotalLb.Content = totalWords;


                Service.StatisticsService.SendStatistics(words);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nStack trace: \n" + ex.StackTrace);
            }


        }

        private async void StatisticsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                WordsSp.Children.Clear();
                List<Lib.Word> words = Service.StatisticsService.GetStatistics();
                words = words.OrderByDescending(x => x.Count).ToList();
                words.ForEach(x => WordsSp.Children.Add(new Views.Word(x)));

                UniqueWordsLb.Content = words.Count;

                int totalWords = 0;
                foreach (Lib.Word word in words)
                {
                    totalWords += word.Count;
                }
                TotalLb.Content = totalWords;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nStack trace: \n" + ex.StackTrace);
            }


        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            WordsSp.Children.Clear();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "HTML files (*.html)|*.html|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                SourceTb.Text = openFileDialog.FileName;
        }
    }
}
