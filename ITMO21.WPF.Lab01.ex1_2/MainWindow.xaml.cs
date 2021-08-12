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

namespace ITMO21.WPF.Lab01.ex1_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isDataDirty = false;
        public MyWindow myWin { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            lbl.Content = "Добрый день!";
            setBut.IsEnabled = false;
            retBut.IsEnabled = false;
            Top = 25;
            Left = 25;
        }

        private void setBut_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("C:\\Users\\kasyu\\source\\repos\\ITMO21.WPF\\ITMO21.WPF\\username.txt");
                sw.WriteLine(setText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }

            retBut.IsEnabled = true;
            isDataDirty = false;
        }

        private void retBut_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = null;
            try
            {
                using (sr = new StreamReader("C:\\Users\\kasyu\\source\\repos\\ITMO21.WPF\\ITMO21.WPF\\username.txt"))
                    retLabel.Content = "Приветствую Вас, уважаемый {0}" + sr.ReadToEnd() + "!!!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        private void setText_TextChanged(object sender, TextChangedEventArgs e)
        {
            setBut.IsEnabled = true;
            isDataDirty = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.isDataDirty)
            {
                string msg = "Данные были изменены, но не сохранены!!! \n" +
                    "Закрыть окно без сохранения?";
                MessageBoxResult result = MessageBox.Show(msg, "Контроль данных", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;

                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void New_Win_Click(object sender, RoutedEventArgs e)
        {
            if (myWin == null)
            {
                myWin = new MyWindow();
            }
            myWin.Owner = this;
            myWin.Top = this.Top;
            myWin.Left = this.Left + this.Width;
            //var location = New_Win.PointToScreen(new Point(0, 0));
            //myWin.Left = location.X + New_Win.Width;
            //myWin.Top = location.Y;
            myWin.Show();
        }
    }
}